using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sow.Automation.Dashboard.Models;
using Sow.Automation.Dashboard.Structs;
using Sow.Automation.Data.Entidades.Manipuladores.Interfaces;
using Sow.Automation.Data.Entidades.NotificacoesContexto;
using Sow.Automation.Dashboard.ViewModels;
using Sow.Automation.Dashboard.Interfaces;
using Sow.Automation.Data.Services;
using Microsoft.AspNetCore.Hosting;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Enums;

namespace Sow.Automation.Dashboard.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IAgendamentoAppService _service;
        public HomeController(IUserAppServices userappService,
            IDomainNotificationHandler notification, IAgendamentoAppService service) : base(notification, userappService)
        {
            _service = service;
        }


        public int Notificacoes()
        {
            if (CheckSession())
            {
                return _service.ObterTabelaExecucoes().Where(a => a.Status == EStatusAgendamento.FinalizadoComErro).Count();
            }

            return 0;
        }

        #region ViewComponents
        public IActionResult AtualizaResumoProcesso()
        {
            if (CheckSession())
            {
                return ViewComponent("ResumoProcessos");
            }
            else
            {
                return Redirect("/Home/Login");
            }
            
        }


        public IActionResult AtualizaCartoes()
        {
            if (CheckSession())
            {
                return ViewComponent("CartoesVisita");
            }
            else
            {
                return Redirect("/Home/Login");
            }

        }

        [HttpPost]
        public IActionResult DetalheResumoProcesso([FromBody] DadosFluxoTela dados)
        {
            if (CheckSession())
            {
                return ViewComponent("DetalhesResumoProcesso", new { dados});
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }
        #endregion

        #region Views
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Home/Login");

        }
        public IActionResult Index()
        {
            if (CheckSession())
            {
                return View();
            }
            else
            {
                return Redirect("/Home/Login");
            }

        }
        #endregion

        #region Actions Default
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }
}
