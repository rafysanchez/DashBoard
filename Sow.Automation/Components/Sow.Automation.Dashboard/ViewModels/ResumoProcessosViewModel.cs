using Sow.Automation.Dashboard.Interfaces;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Automation.Dashboard.ViewModels
{
    public class ResumoProcessosViewModel 
    {
        public readonly  IEnumerable<AgendamentoViewModel> _listaAgendamentos;
        public readonly IEnumerable<AgendamentoExecucoesViewModel> _listaExecucoes;
        

        #region Variaveis
        public int Erros { get; set; }
        public int Sucesso { get; set; }
        public int Executando { get; set; }
        #endregion

        #region Propriedades
        public List<ResumoProcessosViewModel> DetalhesProcessos { get; set; }
        public AgendamentoExecucoesViewModel Execucao { get; set; }
        public string Descricao { get; set; }
        #endregion

        #region Construtores
        public ResumoProcessosViewModel(IEnumerable<AgendamentoViewModel> listaAgendamentos,
           IEnumerable<AgendamentoExecucoesViewModel> listaExecucoes)
        {
            _listaAgendamentos = listaAgendamentos;
            _listaExecucoes = listaExecucoes;
            AtualizaStatus();
            DetalhesProcessos = new List<ResumoProcessosViewModel>();
        }

        private ResumoProcessosViewModel()
        {
            Execucao = new AgendamentoExecucoesViewModel();
        }
        #endregion


        #region Metodos Publicos
        public void AtualizaStatus()
        {
            Erros = _listaExecucoes.ToList().FindAll(a=> a.Status == EStatusAgendamento.FinalizadoComErro).Count;
            Sucesso = _listaExecucoes.ToList().FindAll(a => a.Status == EStatusAgendamento.Finalizado).Count;
            Executando = _listaAgendamentos.ToList().FindAll(a => a.StatusAgendamento == EStatusAgendamento.Executando).Count;
        }

        public void CarregarExecucoes(EStatusAgendamento status)
        {  
            var lista = _listaExecucoes.Where(a=> a.Status == status);
            foreach (var execucao in lista)
            {
                ResumoProcessosViewModel res = new ResumoProcessosViewModel
                {
                    Descricao = _listaAgendamentos.Where(a => a.IdProcesso == execucao.IdProcesso).FirstOrDefault().Descricao,
                    Execucao = execucao
                };
                DetalhesProcessos.Add(res);
            }
        }
        public void CarregarExecucoes(string idAgendamento)
        {
            var lista = _listaExecucoes.Where(a => a.IdProcesso == idAgendamento);
            foreach (var execucao in lista)
            {
                ResumoProcessosViewModel res = new ResumoProcessosViewModel
                {
                    Descricao = _listaAgendamentos.Where(a => a.IdProcesso == execucao.IdProcesso).FirstOrDefault().Descricao,
                    Execucao = execucao
                };
                DetalhesProcessos.Add(res);
            }
        }

        public void CarregarAgendamentos(EStatusAgendamento status)
        {
            var lista = _listaAgendamentos.Where(a => a.StatusAgendamento == status);
            foreach (var agendamento in lista)
            {
                ResumoProcessosViewModel res = new ResumoProcessosViewModel();
                res.Descricao = _listaAgendamentos.Where(a => a.IdProcesso == agendamento.IdProcesso).FirstOrDefault().Descricao;
                res.Execucao.Inicio = _listaExecucoes.Where(a => a.IdProcesso == agendamento.IdProcesso).LastOrDefault().Inicio;
                DetalhesProcessos.Add(res);
            }
        }

        #endregion
    }
}
