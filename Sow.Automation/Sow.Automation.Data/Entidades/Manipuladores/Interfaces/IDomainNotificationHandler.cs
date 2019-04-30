using FluentValidation.Results;
using Sow.Automation.Data.Entidades.NotificacoesContexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.Manipuladores.Interfaces
{
    public interface IDomainNotificationHandler
    {
        bool HasNotifications();
        List<DomainNotification> GetNotifications();
        void AddNotification(DomainNotification message);
    }
}
