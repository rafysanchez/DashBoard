using Sow.Automation.Data.Entidades.ComandoContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces.ContextoPadrao
{
   public interface IAgendamentoRepository
    {
        AgendamentoInfo ObterAgendamento(string Id);
        IEnumerable<AgendamentoInfo> ObterTodosAgendamentos(int? quantidade = null);
        IEnumerable<AgendamentoInfo> ObterTodosAgendamentosEnfileirar();
        CommandResponse AdicionarAgendamento(AgendamentoInfo obj);
        CommandResponse RemoverAgendamentoInfoPorID(string IdProcesso);
        CommandResponse AtualizarAgendamentoInfoPorID(AgendamentoInfo obj);
        CommandResponse AtualizarStatusAgendamento(AgendamentoInfo obj);
    }
}
