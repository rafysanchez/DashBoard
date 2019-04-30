using Sow.Automation.Dashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Automation.Dashboard.Interfaces
{
  public  interface IAgendamentoAppService
    {
        IEnumerable<AgendamentoViewModel> ObterTabelaAgendamentos();
        IEnumerable<AgendamentoExecucoesViewModel> ObterTabelaExecucoes();
    }
}
