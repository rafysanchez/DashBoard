using Sow.Automation.Data.Entidades.ComandoContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces
{
    public interface IRegrasForumRepository : IRepository
    {
        RegrasForunsBrasil ObterPorCidadeEComarca(string uf, string city, string comarca);
        RegraBrasilQueryResult ObterPorCidadeEComarcaDetalhado(string uf, string city, string comarca);
        IEnumerable<RegraBrasilQueryResult> ObterTodasRegrasDetalhado();
        CommandResponse AdicionarRegra(RegrasForunsBrasil regra);
        CommandResponse RemoverRegra(RegrasForunsBrasil regra);
        CommandResponse AtualizarRegra(RegrasForunsBrasil regra);

    }
}
