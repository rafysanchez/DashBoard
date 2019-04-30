using Sow.Automation.Data.Entidades.ComandoContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces
{
    public interface IRepository
    {
        IEnumerable<T> ObterTodos<T>(string nomeTabela) where T : EntidadeBase<T>;
        IEnumerable<RegraBairroQueryResult> ObterTodosLocais();
        IEnumerable<RegraBairroQueryResult> ObterTodasCidades();
        IEnumerable<RegraBairroQueryResult> ObterTodasComarca();
        CommandResponse AdicionarCidade(long idEstado, long idComarca, string cidade);
        CommandResponse AdicionarComarca(long idEstado, string comarca);
        CommandResponse RemoverCidade(long id);
        CommandResponse RemoverComarca(long id);
        CommandResponse AtualizarCidade(Cidade cidade);
        CommandResponse AtualizarComarca(Comarca comarca);
        CommandResponse AdicionarBairro(long idCidade, string bairro);
        CommandResponse RemoverBairro(long id);
        CommandResponse AtualizarBairro(Bairro bairro);

    }
}
