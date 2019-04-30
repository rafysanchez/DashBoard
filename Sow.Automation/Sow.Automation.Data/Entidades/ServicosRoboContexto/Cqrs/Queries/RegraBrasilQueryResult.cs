using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Queries
{
    public class RegraBrasilQueryResult
    {
        public long IdEstado { get; set; }
        public long IdCidade { get; set; }
        public long IdComarca { get; set; }
        public string Estado { get; set; }
        public string Comarca { get; set; }
        public string Cidade { get; set; }
        public string Regra { get; set; }
        public string Status { get; set; }
    }
}
