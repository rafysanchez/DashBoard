using Sow.Automation.Agendamento.Abstracao;
using Sow.Automation.Agendamento.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleService
{
    public partial class RPAScheduleService : ServiceBase
    {
        IExecutor age = new Agendamentos();
        public RPAScheduleService()
        {
            InitializeComponent();
            
        }

        protected override void OnStart(string[] args)
        {            
            age.InicializaAgendamentoLeituraAsyncrono();
            age.InicializaAgendamentoExecucoesAsyncrono();
        }

        protected override void OnStop()
        {
           age.FinalizaProcesso();
        }
    }
}
