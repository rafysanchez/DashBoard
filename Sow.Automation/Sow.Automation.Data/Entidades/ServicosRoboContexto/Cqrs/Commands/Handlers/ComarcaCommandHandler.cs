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
    public class ComarcaCommandHandler : CommandHandler,
       IHandler<Comarca>
    {
        private readonly IRepository _repository;



        public ComarcaCommandHandler(IRepository repository, IDomainNotificationHandler notifications) : base(notifications)
        {
            _repository = repository;
        }

      
        public void HandleDelete(Comarca message)
        {
            var cidades = _repository.ObterTodasCidades().ToList().FindAll(a => a.IdComarca == message.Id);
            if (cidades.Count > 0)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, $"Existem {cidades.Count} cidades associadas a esta comarca, favor remover ou desvincular estas cidades desta comarca!"));
                return;
            }

            var regras = _repository.ObterTodos<RegrasForunsBrasil>("RegrasForunsBrasil").ToList().FindAll(a => a.IdComarca == message.Id);
            if (regras.Count > 0)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, $"Existem {regras.Count} foruns associados a esta comarca, favor remover ou desvincular estes foruns desta comarca!"));
                return;
            }

            var regrasBairro = _repository.ObterTodos<RegrasForunsBrasil>("RegrasForunsBrasil").ToList().FindAll(a => a.IdComarca == message.Id);
            if (regrasBairro.Count > 0)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, $"Existem {regrasBairro.Count} foruns de bairros associados a esta comarca, favor remover ou desvincular estes foruns desta comarca!"));
                return;
            }

            var result = _repository.RemoverComarca(message.Id);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Comarca Removida com Sucesso"));
            }
        }

        public void HandleInsert(Comarca message)
        {

           
            if (!message.IsValid())
            {
                NotificarValidacoesErro(message.ValidationResult);
                return;
            }

            var det = _repository.ObterTodasComarca()
                           .ToList().Find(a => a.IdEstado == message.IdEstado
                             && a.Comarca == message.Descricao);

            if (det != null)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, $"Ja existe uma comarca com este nome :  {det.Estado} - {det.Comarca}, favor remover ou atualizar esta comarca"));
                return;
            }

            var result = _repository.AdicionarComarca(message.IdEstado, message.Descricao);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Comarca Inserida com Sucesso"));
            }
        }

        public void HandleUpdate(Comarca message)
        {
           
            if (!message.IsValid())
            {
                NotificarValidacoesErro(message.ValidationResult);
                return;
            }


            var result = _repository.AtualizarComarca(message);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Comarca Atualizada com Sucesso"));
            }
        }
    }
}
