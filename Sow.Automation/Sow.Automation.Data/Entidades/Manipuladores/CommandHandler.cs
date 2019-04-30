using FluentValidation.Results;
using Sow.Automation.Data.Entidades.Manipuladores.Interfaces;
using Sow.Automation.Data.Entidades.NotificacoesContexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.Manipuladores
{
    public  class CommandHandler
    {
        protected readonly IDomainNotificationHandler _notifications;
        protected CommandHandler(IDomainNotificationHandler notifications)
        {
            _notifications = notifications;
        }
        protected void NotificarValidacoesErro(ValidationResult validarionResult)
        {

            foreach (var erro in validarionResult.Errors)
            {
                _notifications.AddNotification(new DomainNotification(erro.PropertyName, erro.ErrorMessage));
            }
        }

    }
}
