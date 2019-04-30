using Sow.Automation.Data.Entidades.ServicosRoboContexto.Enums;
using System;

namespace Sow.Automation.Dashboard.ViewModels
{
    public class AgendamentoExecucoesViewModel
    {
        public string IdExecucao { get;  set; }
        public string IdProcesso { get;  set; }
        public string MensagemStatus { get;  set; }
        public DateTime Inicio { get;  set; }
        public DateTime Fim { get;  set; }
        public EStatusAgendamento Status { get;  set; }
    }
}