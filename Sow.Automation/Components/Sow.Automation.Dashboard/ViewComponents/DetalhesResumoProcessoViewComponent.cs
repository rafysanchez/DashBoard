using Microsoft.AspNetCore.Mvc;
using Sow.Automation.Dashboard.Interfaces;
using Sow.Automation.Dashboard.Models;
using Sow.Automation.Dashboard.ViewModels;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Automation.Dashboard.ViewComponents
{
    public class DetalhesResumoProcessoViewComponent : ViewComponent
    {
        private readonly IAgendamentoAppService _service;
        public DetalhesResumoProcessoViewComponent(IAgendamentoAppService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(DadosFluxoTela dados)
        {

            
            var model = new  ResumoProcessosViewModel(_service.ObterTabelaAgendamentos(), _service.ObterTabelaExecucoes());
            switch (dados.FluxoTela)
            {
                case "CartoesVisita":
                    switch (dados.Fluxo)
                    {
                        case "0":
                         await Task.Run(()=> model.CarregarExecucoes(EStatusAgendamento.Finalizado));
                            break;
                        case "1":
                            await Task.Run(() => model.CarregarExecucoes(EStatusAgendamento.FinalizadoComErro));
                            break;
                        case "2":
                            await Task.Run(() => model.CarregarAgendamentos(EStatusAgendamento.Executando));
                            break;
                        default:
                            break;
                    }

                    break;
                case "ResumoProcesso":
                    switch (dados.Fluxo)
                    {
                        default:
                            await Task.Run(() => model.CarregarExecucoes(dados.IdAgendamento));
                            break;
                    }

                    break;
                default:
                    break;
            }

            
            return View("DetalhesResumoProcesso",model);
        }
    }
}
