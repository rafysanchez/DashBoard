using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Automation.Dashboard.ViewModels
{
    public class EmailViewModel
    {
        public Guid IdProcesso { get;  set; }
        public string Assunto { get;  set; }
        public string Remetente { get;  set; }
        public string Destinatario { get;  set; }
        public string Destinatario_CC { get;  set; }
        public string Destinatario_CO { get;  set; }
    }
}
