using Ninject;
using Sow.Automation.Agendamento.Abstracao;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Enums;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces.ContextoPadrao;
using Sow.Automation.Orquestrador.Abstracao;
using Sow.Automation.Orquestrador.Ioc;
using System;
using System.Collections.Generic;

namespace Sow.Automation.Agendamento.Model
{
   public abstract class AgendamentoBase<T> : NinjectProgram where T : AgendamentoInfo
    {

        #region Construtores
        protected AgendamentoBase()
        {
            _repository = GetController<IAgendamentoRepository>();
            _service = GetController<IService<T>>();
            _jobRepository = GetController<IJobRepository<T>>();
        }
        #endregion

        #region Variaveis
        protected readonly IAgendamentoRepository _repository;
        protected readonly IJobRepository<T> _jobRepository;
        protected readonly IService<T> _service;
        protected Func<DateTime, int, DateTime> MinutoCorrido = (data, minutos) => DiaUltil(data.AddMinutes((minutos)));
        protected Func<DateTime, int, DateTime> HorasCorrida = (data, horas) => DiaUltil(data.AddHours((horas)));
        protected Func<DateTime, int, DateTime> MesCorrido = (data, dias) => DiaUltil(data.AddDays(QuantidadeDiasDoMes(data, dias)));
        protected Func<DateTime, int, DateTime> DiaCorrido = (data, dias) => DiaUltil(data.AddDays(dias), dias);
        protected Func<DateTime, int, DateTime> SemanaCorrida = (data, dias) => data.AddDays(QuantidadeDiasDaSemana(data, dias));
        protected bool agendamento = true;
        #endregion

     
        #region Metodos Privados
        private static  bool Feriados(DateTime data)
        {
            //Implementar JSON ou Cadastro de Feriados no Banco
            List<string> ListaFeriados = new List<string>()
            {
                "",
                "",
                ""
            };
            return (ListaFeriados.FindAll(a => a.Contains(data.ToString("dd/MM/yyyy"))).Count > 0);
        }
        private static DateTime DiaUltil(DateTime data,int dias = 0)
        {
            data.AddDays(dias);

            while (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday || Feriados(data))
                data = data.AddDays(1);
             
            return data;
        }
        private static int QuantidadeDiasDoMes(DateTime data,int quantidade)
        {
            int dias = 0;
            for (int i = 0; i < quantidade; i++)
            {
                data = data.AddMonths(i);
                dias += DateTime.DaysInMonth(data.Year, data.Month);
            }

            return dias;
        }
        private static int QuantidadeDiasDaSemana(DateTime data, int quantidade)
        {
            int dias = 0;
            for (int i = 0; i < quantidade; i++)
                dias += 7;
            

            return dias;
        }
        #endregion

        #region Metodos Protegidos
        protected virtual void ExecutarPluginRpa(T processos)
        {
            var exec = new AgendamentoExecucao(processos.IdProcesso, EStatusAgendamento.Executando);

            try
            {
                exec.AtualizaDataInicio(DateTime.Now);

                DateTime ini = DateTime.Now;
                Console.WriteLine($"Inicializando o Processo {processos.Descricao} Id - {exec.IdExecucao} - Inicio {ini}");

                _service.InicializaPlugin(processos);

                DateTime fim = DateTime.Now;
                Console.WriteLine($"Finalizando o Processo {processos.Descricao} Id - {exec.IdExecucao}  - Inicio {ini} - Fim -  {fim} -- Proxima execucao {processos.DataProximaExecucao}");


                processos.AtualizaStatusExecucao(EStatusAgendamento.Finalizado);
                exec.AtualizaDataFim(DateTime.Now);
                exec.AtualizaStatus(EStatusAgendamento.Finalizado);



                GetController<IAgendamentoRepository>().AtualizarStatusAgendamento(processos);
                GetController<IAgendamentoExecucoesRepository>().AdicionarExecucao(exec);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Processo {processos.Descricao} - Finalizado com Erro:{ex.Message}");


                processos.AtualizaStatusExecucao(EStatusAgendamento.FinalizadoComErro);
                exec.AtualizaDataFim(DateTime.Now);
                exec.AtualizaStatus(EStatusAgendamento.FinalizadoComErro);
                exec.AtualizaMensagemStatus(ex.Message);


                GetController<IAgendamentoRepository>().AtualizarStatusAgendamento(processos);
                GetController<IAgendamentoExecucoesRepository>().AdicionarExecucao(exec);
            }

        }
        #endregion

    }
}
