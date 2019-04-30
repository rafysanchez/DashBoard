using Microsoft.AspNetCore.Mvc;
using Sow.Automation.Dashboard.Interfaces;
using Sow.Automation.Dashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Automation.Dashboard.ViewComponents
{
    public class CartoesVisitaViewComponent : ViewComponent
    {

        private readonly IAgendamentoAppService _service;
        public CartoesVisitaViewComponent(IAgendamentoAppService service)
        {
            _service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new ResumoProcessosViewModel(_service.ObterTabelaAgendamentos(), _service.ObterTabelaExecucoes());
           
            return await Task.Run(() => View("CartoesVisita",model));
        }

       
    }
}
