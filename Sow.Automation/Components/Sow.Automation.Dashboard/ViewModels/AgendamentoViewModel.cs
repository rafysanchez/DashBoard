using Sow.Automation.Data.Entidades.ServicosRoboContexto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Automation.Dashboard.ViewModels
{
    public class AgendamentoViewModel
    {
        public string IdProcesso { get;  set; }
        public DateTime DataInicio { get;  set; }
        public DateTime DataProximaExecucao { get; set; }
        public DateTime DataUltimaExecucao { get; set; }
        public string Descricao { get;  set; }
        public string NomeAgente { get;  set; }
        public ETipoPeriodicidade Periodicidade { get;  set; }
        public int? FrequenciaPeriodicidade { get;  set; }
        public EStatusAgendamento StatusAgendamento { get;  set; }
        public int? HoraInicio { get;  set; }
        public int? MinutoInicio { get;  set; }
        public string AmPm { get;  set; }
        public bool Ativo { get;  set; }
        public bool DisparoManual { get;  set; }
        public EmailViewModel Email { get;  set; }
    }
}
