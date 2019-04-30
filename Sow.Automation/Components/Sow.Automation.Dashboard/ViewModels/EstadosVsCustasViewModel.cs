using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Automation.Dashboard.ViewModels
{
    public class EstadosVsCustasViewModel
    {
        public long IdEstado { get;  set; }
        public string Estado { get; set; }
        public long De { get;  set; }
        public long Ate { get;  set; }
    }
}
