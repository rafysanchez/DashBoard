using Sow.Automation.Data.Entidades.ComandoContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Queries;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Queries.FiltrosParametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces
{
    public interface IRegrasForunsBairrosRepository : IRepository
    {
        RegrasForunsBairros ObtemRegraBairro(FiltroBairroCommand filtro);
        RegraBairroQueryResult ObtemRegraBairroDetalhado(FiltroBairroCommand filtro);
        IEnumerable<RegraBairroQueryResult> ObterTodosBairrosDetalhado();
        CommandResponse AdicionarRegraBairro(RegrasForunsBairros regra);
        CommandResponse RemoverRegraBairro(RegrasForunsBairros regra);
        CommandResponse AtualizarRegraBairro(RegrasForunsBairros regra);
    }
}
