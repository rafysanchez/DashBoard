using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Queries.FiltrosParametros
{
    public struct FiltroBairroCommand
    {
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Comarca { get; set; }
        public string Bairro { get; set; }
    }
}
