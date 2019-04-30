using Sow.Automation.Data.Entidades.ComandoContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces.ContextoPadrao
{
   public interface IAgendamentoExecucoesRepository
    {
        AgendamentoExecucao ObterExecucao(string Id);
        IEnumerable<AgendamentoExecucao> ObterTodasExecucoes(int? quantidade = null);
        CommandResponse AdicionarExecucao(AgendamentoExecucao obj);
    }
}
