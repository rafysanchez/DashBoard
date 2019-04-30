using Sow.Automation.Data.Entidades.Manipuladores.Interfaces;
using Sow.Automation.Data.Entidades.NotificacoesContexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.Manipuladores
{
    public class DomainNoticationHandler : IDomainNotificationHandler
    {
        private List<DomainNotification> _notifications;

        public DomainNoticationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public void AddNotification(DomainNotification message)
        {
            _notifications.Add(message);
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
