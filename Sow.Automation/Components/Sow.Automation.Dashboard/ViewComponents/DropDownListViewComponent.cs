using Microsoft.AspNetCore.Mvc;
using Sow.Automation.Dashboard.Interfaces;
using Sow.Automation.Dashboard.Structs;
using Sow.Automation.Dashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Automation.Dashboard.ViewComponents
{
    public class DropDownListViewComponent : ViewComponent
    {
        private readonly IQueryAppService _appService;

        public DropDownListViewComponent(IQueryAppService appService)
        {
            _appService = appService;
        }
        public async Task<IViewComponentResult> InvokeAsync(FiltroDropDown Dados)
        {
            var model = new DropDownViewModel();


            await Task.Run(() => InicializaListas(Dados,model));


            return View("DropDownList",model);
        }

        private void InicializaListas(FiltroDropDown Dados, DropDownViewModel model )
        {
            switch (Dados.DropDown)
            {
                case "Comarcas":

                    if (Dados.IdEstado != null)
                        model.PopulaLista(_appService.ObterComarcas().ToList()
                                .FindAll(a => a.IdEstado == long.Parse(Dados.IdEstado)));
                    else
                        model.PopulaLista(_appService.ObterComarcas().ToList());

                    break;

                case "Cidades":

                    if (Dados.IdEstado != null && Dados.IdComarca != null)
                        model.PopulaLista(_appService.ObterCidades().ToList()
                                .FindAll(a => a.IdEstado == long.Parse(Dados.IdEstado) && a.IdComarca == long.Parse(Dados.IdComarca)));
                    else
                        model.PopulaLista(_appService.ObterCidades().ToList());

                    break;

                case "Bairros":

                    if (Dados.IdCidade != null)
                        model.PopulaLista(_appService.ObterBairros().ToList()
                                .FindAll(a => a.IdCidade == long.Parse(Dados.IdCidade)));
                    else
                        model.PopulaLista(_appService.ObterBairros().ToList());

                    break;

                default:
                    model.PopulaLista(_appService.ObterEstados().ToList());
                    break;
            }
        }
    }
}
