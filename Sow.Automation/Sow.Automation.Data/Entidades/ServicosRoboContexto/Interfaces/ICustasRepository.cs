using Sow.Automation.Data.Entidades.ComandoContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces
{
   public interface ICustasRepository
    {
        IEnumerable<CustasQueryResult> ObterTodosDetalhado();
        CommandResponse AdicionarCusta(EstadosVsCustas custa);
        CommandResponse EditarCusta(EstadosVsCustas custa);
        CommandResponse RemoverCusta(long IdEstado);
    }
}
