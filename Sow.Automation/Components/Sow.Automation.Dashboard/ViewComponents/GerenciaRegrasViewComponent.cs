using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Sow.Automation.Dashboard.Interfaces;
using Sow.Automation.Dashboard.ViewModels;
using Sow.Automation.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Automation.Dashboard.ViewComponents
{
    public class GerenciaRegrasViewComponent : ViewComponent
    {
        private readonly IQueryAppService _appService;
        private readonly JsonServices _jsonService;

        public GerenciaRegrasViewComponent(IQueryAppService appService, JsonServices jsonService)
        {
            _appService = appService;
            _jsonService = jsonService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string fluxo)
        {
            var model = new GerenciaRegrasViewModel
            {
                Fluxo = fluxo
            };
            await Task.Run(() => VerificaFluxo(model,fluxo));

            return View("GerenciaRegras",model);
        }

        private void VerificaFluxo(GerenciaRegrasViewModel model, string fluxo)
        {
            switch (fluxo)
            {
                case "1":
                    model.PopulaLista(_appService.ObterTabelaComarcas().ToList());
                    break;
                case "2":
                    model.PopulaLista(_appService.ObterTabelaCidades().ToList());
                    break;
                case "3":
                    model.PopulaLista(_appService.ObterTabelaBairros().ToList());
                    break;
                case "4":
                     model.PopulaLista(_appService.ObterRegras().ToList());
                    break;
                case "5":
                    model.PopulaLista(_appService.ObterRegrasBairro().ToList());
                    break;
                case "6":
                    model.PopulaLista(_jsonService.DeserializarNewtonsoft<long>("Contratos.Json"));
                    break;
                case "7":
                    model.PopulaLista(_jsonService.DeserializarNewtonsoft<long>("Despesas.Json"));
                    break;
                case "8":
                    model.PopulaLista(_appService.ObterTabelaCustas().ToList());
                    break;
                default:
                    break;
            }
        }
    }
}
