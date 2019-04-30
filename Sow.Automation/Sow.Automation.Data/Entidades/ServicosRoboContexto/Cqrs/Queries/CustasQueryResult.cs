using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Queries
{
  public  class CustasQueryResult
    {
        public long IdEstado { get; set; }
        public string Estado { get; set; }
        public long De { get; set; }
        public long Ate { get; set; }
    }
}
