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
    public class BairroCommandHandler : CommandHandler,
         IHandler<Bairro>
        
    {
        IRepository _repository;
        public BairroCommandHandler(IRepository repository, IDomainNotificationHandler notifications) : base(notifications)
        {
            _repository = repository;
        }

       
        public void HandleDelete(Bairro message)
        {
            var regrasBairro = _repository.ObterTodos<RegrasForunsBairros>("RegrasForunsBairros").ToList().FindAll(a => a.IdBairro == message.Id);
            if (regrasBairro.Count > 0)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, $"Existem {regrasBairro.Count} foruns de bairros associados a esta comarca, favor remover ou desvincular estes foruns desta comarca!"));
                return;
            }

            var result = _repository.RemoverBairro(message.Id);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Bairro Removido com Sucesso"));
            }
        }

        public void HandleInsert(Bairro message)
        {            
            if (!message.IsValid())
            {
                NotificarValidacoesErro(message.ValidationResult);
                return;
            }

            var det = _repository.ObterTodos<Bairro>("Bairros")
                          .ToList().Find(a => a.IdCidade == message.IdCidade
                            && a.Descricao == message.Descricao);


            if (det != null)
            {
                var cidade = _repository.ObterTodasCidades().Where(a => a.IdCidade == det.IdCidade).FirstOrDefault();
                _notifications.AddNotification(new DomainNotification(message.MessageType, $"Ja existe um bairro com este nome :  {cidade.Estado} - {det.Descricao}, favor remover ou atualizar este bairro"));
                return;
            }

            var result = _repository.AdicionarBairro(message.IdCidade, message.Descricao);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Bairro Inserido com Sucesso"));
            }
        }

        public void HandleUpdate(Bairro message)
        {
            
            if (!message.IsValid())
            {
                NotificarValidacoesErro(message.ValidationResult);
                return;
            }


            var result = _repository.AtualizarBairro(message);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Bairro Atualizado com Sucesso"));
            }
        }
    }
}
