using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Enums;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces.ContextoPadrao;
using Sow.Automation.Agendamento.Abstracao;
using Sow.Automation.Agendamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sow.Automation.Agendamento.Servicos
{
   
    public class Agendamentos : AgendamentoBase<AgendamentoInfo>, IExecutor, IAgendamento<AgendamentoInfo>
    {
       

        #region Construtores
        public Agendamentos()
        {
            RecuperaAgendamentos();
        }
        #endregion

        #region Metodos Publicos

        #region IExecucao Interface
        public async Task InicializaAgendamentoLeituraAsyncrono()
        {
            await Task.Factory.StartNew(() => ProcessarLeituraAgendamentos());

        }
        public async Task InicializaAgendamentoExecucoesAsyncrono()
        {
            await Task.Factory.StartNew(() => ProcessarExecucaoAgendamentos());
        }
        #endregion


        #region IAgendamento Interface

        public void ProcessarLeituraAgendamentos()
        {
            while (agendamento)
            {
                Thread.Sleep(2000);
                var ag = _repository.ObterTodosAgendamentosEnfileirar();
                 var agendamentos = FiltrarAgendamentosAExecutar(ag);
                agendamentos.ToList().ForEach(InsereAgendamento);
            }
        }

        public void ProcessarExecucaoAgendamentos()
        {
            while (agendamento)
            {
                if (_jobRepository.GetMessageInRepository() > 0)
                {
                    Thread.Sleep(2000);
                    var processos = _jobRepository.ReadMessage();
                    processos.AtualizaStatusExecucao(EStatusAgendamento.Executando);
                    GetController<IAgendamentoRepository>().AtualizarStatusAgendamento(processos);
                    Task.Factory.StartNew(() => ExecutarPluginRpa(processos));
                }
            }
        }
      
        public IEnumerable<AgendamentoInfo> FiltrarAgendamentosAExecutar(IEnumerable<AgendamentoInfo> agendamentos)
        {

            var dt = DateTime.Now;
            var data = dt.AddSeconds(-dt.Second).ToString("yyyy-MM-dd hh:mm");

            return agendamentos.ToList()
                  .FindAll(a => (a.DataProximaExecucao.ToString("yyyy-MM-dd hh:mm") == data
                  && a.DataUltimaExecucao.ToString("yyyy-MM-dd hh:mm") != data)
                  || ((a.DataInicio.ToString("yyyy-MM-dd hh:mm") == data && a.StatusAgendamento == EStatusAgendamento.Aguardando)));

        }

        public void InsereAgendamento(AgendamentoInfo agendamento)
        {
            agendamento.AtualizaStatusExecucao(EStatusAgendamento.NaFila);
            AtualizaDataProximaExecucao(agendamento);
            _jobRepository.SetMessage(agendamento);
            _repository.AtualizarStatusAgendamento(agendamento);
            
        }

        public void AtualizaDataProximaExecucao(AgendamentoInfo agendamento)
        {
            var data = DateTime.Now;
            switch (agendamento.Periodicidade)
            {
                case ETipoPeriodicidade.Minutos:
                    agendamento.AtualizarDataUltimaExecucao(data);
                    agendamento.AtualizarDataProxima(MinutoCorrido(data, agendamento.FrequenciaPeriodicidade.Value));
                    break;
                case ETipoPeriodicidade.Horas:
                    agendamento.AtualizarDataUltimaExecucao(data);
                    agendamento.AtualizarDataProxima(HorasCorrida(data, agendamento.FrequenciaPeriodicidade.Value));
                    break;
                case ETipoPeriodicidade.Diario:
                    agendamento.AtualizarDataUltimaExecucao(data);
                    agendamento.AtualizarDataProxima(DiaCorrido(data, agendamento.FrequenciaPeriodicidade.Value));
                    break;
                case ETipoPeriodicidade.Semanal:
                    agendamento.AtualizarDataUltimaExecucao(data);
                    agendamento.AtualizarDataProxima(SemanaCorrida(data, agendamento.FrequenciaPeriodicidade.Value));
                    break;
                case ETipoPeriodicidade.Mensal:
                    agendamento.AtualizarDataUltimaExecucao(data);
                    agendamento.AtualizarDataProxima((MesCorrido(data, agendamento.FrequenciaPeriodicidade.Value)));
                    break;
                default:
                    break;
            }
        }

        public void RecuperaAgendamentos()
        {
            _repository.ObterTodosAgendamentos().ToList()
                .FindAll(a => a.StatusAgendamento == EStatusAgendamento.NaFila || a.StatusAgendamento == EStatusAgendamento.Executando)
                 .ForEach(InsereAgendamento);
        }

        public void FinalizaProcesso() => agendamento = false;

        #endregion

        #endregion
    }


}
