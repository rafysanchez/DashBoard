using Sow.Automation.Data.Entidades;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Agendamento.Abstracao
{
   public interface IAgendamento<T> where T : AgendamentoInfo
    {
        void RecuperaAgendamentos();
        void AtualizaDataProximaExecucao(T agendamento);
        void InsereAgendamento(T agendamento);
        void ProcessarLeituraAgendamentos();
        void ProcessarExecucaoAgendamentos();
        IEnumerable<T> FiltrarAgendamentosAExecutar(IEnumerable<T> agendamentos);
    }
}
