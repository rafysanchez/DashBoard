using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Enums;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces.ContextoPadrao;
using Sow.Automation.Data.Repositorios.ContextoPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Tdd.ComponenteBanco
{
  [TestClass]
  public  class AgendamentoRepositoryTeste
    {
        IAgendamentoRepository _repo;
        string id = new Guid().ToString();
        public AgendamentoRepositoryTeste()
        {
            _repo = new AgendamentoRepository(new Data.Contexto.DashBoardDbContext());
        }

        [TestMethod]
        public void ExecutarCrud()
        {
            ADeveInserirTodosItens();
           

        }

       
        public void ADeveInserirTodosItens()
        {
            for (int i = 0; i < 3; i++)
            {
                ETipoPeriodicidade peri = ETipoPeriodicidade.Horas;
                int freq = 0;
                if (i == 0) { peri = ETipoPeriodicidade.Minutos; freq = 1; }
                else if (i == 1) { peri = ETipoPeriodicidade.Minutos; freq = 1; }
                else if (i == 2) { peri = ETipoPeriodicidade.Minutos; freq = 1; }

                var ag = _repo.AdicionarAgendamento(new AgendamentoInfo(id, DateTime.Today, "Teste Agendamento_" + i, "Robo-01", peri, freq, EStatusAgendamento.Aguardando, 12, 53, "Am", true, false,
               new EmailInfo(id, "Teste Assunto", "felipe.rossetto@gmail.com", "felipe.rossetto@gmail.com")));
                var agnd = _repo.ObterTodosAgendamentos().ToList();
                agnd[0].IsValid();
                Assert.AreEqual(true,ag.Success);


            }
           
        }
        
        public void EDeveObterAgendamentos()
        {
            var t = _repo.ObterTodosAgendamentos();
            Assert.AreEqual(true, t.Count() >= 0);
            Assert.AreNotEqual(null, _repo.ObterAgendamento("eea751e2-cdc3-4a8c-8f23-2b5ca83af561"));
        }


        public void BDeveAtualizarAgendamento()
        {
            var email = new EmailInfo("eea751e2-cdc3-4a8c-8f23-2b5ca83af561", "Teste Assunto-Update", "felipe.rossetto@gmail.com", "felipe.rossetto@gmail.com");
            email.AtualizaDestinatario_CC("felipe.rossetto@gmail.com");
            email.AtualizaDestinatario_CO("felipe.rossetto@gmail.com");
            Assert.AreEqual(true, _repo.AtualizarAgendamentoInfoPorID(new AgendamentoInfo("eea751e2-cdc3-4a8c-8f23-2b5ca83af561", DateTime.Now, "Teste Agendamento-Update", "Robo-01-Update", ETipoPeriodicidade.Mensal,2, EStatusAgendamento.Aguardando, 14, 10, "Pm", true, false,email)).Success);
        }

  
        public void CDeveRemoverAgendamento()
        {
            Assert.AreEqual(true, _repo.RemoverAgendamentoInfoPorID(id).Success);
        }
    }
}
