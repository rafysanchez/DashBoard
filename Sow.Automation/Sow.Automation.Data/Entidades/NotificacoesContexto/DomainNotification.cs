using Sow.Automation.Data.Entidades.NotificacoesContexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.NotificacoesContexto
{
    public class DomainNotification
    {
        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
            Version = 1;
            DomainNotificationId = Guid.NewGuid();
        }

        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }
        public Guid DomainNotificationId { get; private set; }
    }
}
