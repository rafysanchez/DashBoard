using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Agendamento.Abstracao
{
  public  interface IExecutor
    {
        Task InicializaAgendamentoLeituraAsyncrono();
        Task InicializaAgendamentoExecucoesAsyncrono();
        void FinalizaProcesso();
    }
}
