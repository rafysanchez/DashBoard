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
    public class CustasCommandHandler : CommandHandler,
        IHandler<EstadosVsCustas>
    {
        private readonly ICustasRepository _repository;
        public CustasCommandHandler(IDomainNotificationHandler notifications, ICustasRepository repository) : base(notifications)
        {
            _repository = repository;
        }

        public void HandleDelete(EstadosVsCustas message)
        {

           var result =  _repository.RemoverCusta(message.IdEstado);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType,result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Custa Removida com Sucesso!"));
            }
            
        }

        public void HandleInsert(EstadosVsCustas message)
        {
            
            if (message != null)
            {
                if (!message.IsValid())
                {
                    NotificarValidacoesErro(message.ValidationResult);
                    return;
                }

                var result = _repository.AdicionarCusta(message);
                if (!result.Success)
                {
                    _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
                }
                else
                {
                    _notifications.AddNotification(new DomainNotification(message.MessageType, "Custa Adicionada com Sucesso!"));
                }
            }
            else
            {
                _notifications.AddNotification(new DomainNotification("", "Favor Preencher todos os campos"));
            }
            
        }

        public void HandleUpdate(EstadosVsCustas message)
        {

            if (message != null)
            {
                if (!message.IsValid())
                {
                    NotificarValidacoesErro(message.ValidationResult);
                    return;
                }

                var result = _repository.EditarCusta(message);
                if (!result.Success)
                {
                    _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
                }
                else
                {
                    _notifications.AddNotification(new DomainNotification(message.MessageType, "Custa Atualizada com Sucesso!"));
                }
            }
            else
            {
                _notifications.AddNotification(new DomainNotification("", "Favor Preencher todos os campos"));
            }

           
        }
    }
}
