using Microsoft.AspNetCore.Mvc;
using Sow.Automation.Dashboard.Interfaces;
using Sow.Automation.Dashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Automation.Dashboard.ViewComponents
{
    public class ResumoProcessosViewComponent : ViewComponent
    {
        private readonly IAgendamentoAppService _service;
        public ResumoProcessosViewComponent(IAgendamentoAppService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
            var model = new ResumoProcessosViewModel(_service.ObterTabelaAgendamentos(),_service.ObterTabelaExecucoes());
         
            return View("ResumoProcessos",model);
        }

       
    }
}
