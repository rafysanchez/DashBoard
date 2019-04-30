using Sow.Automation.Data.Entidades.Manipuladores;
using Sow.Automation.Data.Entidades.Manipuladores.Interfaces;
using Sow.Automation.Data.Entidades.NotificacoesContexto;

using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Commands.Handlers
{
    public class CidadeCommandHandler : CommandHandler,
         IHandler<Cidade>
    {

        private readonly IRepository _repository;
        private readonly IRegrasForumRepository _regrasRepository;
        public CidadeCommandHandler(IRepository repository, IRegrasForumRepository regrasRepository, IDomainNotificationHandler notifications) : base(notifications)
        {
            _repository = repository;
            _regrasRepository = regrasRepository;
        }

    
        public void HandleDelete(Cidade message)
        {
            var regras = _repository.ObterTodos<RegrasForunsBrasil>("RegrasForunsBrasil").ToList().FindAll(a => a.IdCidade == message.Id);
            if (regras.Count > 0)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, $"Existem {regras.Count} foruns associados a esta comarca, favor remover ou desvincular estes foruns desta comarca!"));
                return;
            }

            var regrasBairro = _repository.ObterTodos<RegrasForunsBairros>("RegrasForunsBairros").ToList().FindAll(a => a.IdCidade == message.Id);
            if (regrasBairro.Count > 0)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, $"Existem {regrasBairro.Count} foruns de bairros associados a esta comarca, favor remover ou desvincular estes foruns desta comarca!"));
                return;
            }
            var result = _repository.RemoverCidade(message.Id);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Cidade Removida com Sucesso"));
            }
        }

        public void HandleInsert(Cidade message)
        {
    
            if (!message.IsValid())
            {
                NotificarValidacoesErro(message.ValidationResult);
                return;
            }

            var det = _repository.ObterTodasCidades()
                           .ToList().Find(a => a.IdEstado == message.IdEstado
                             && a.Cidade == message.Descricao);

            if (det != null)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, $"Ja existe uma cidade com este nome :  {det.Estado} - {det.Cidade}, favor remover ou atualizar esta cidade"));
                return;
            }

            var result = _repository.AdicionarCidade(message.IdEstado, message.IdComarca, message.Descricao);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Cidade inserida com Sucesso"));
            }
        }

        public void HandleUpdate(Cidade message)
        {
           
            if (!message.IsValid())
            {
                NotificarValidacoesErro(message.ValidationResult);
                return;
            }


            var result = _repository.AtualizarCidade(message);
            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Cidade Atualizada com Sucesso"));
            }
        }
    }
}
