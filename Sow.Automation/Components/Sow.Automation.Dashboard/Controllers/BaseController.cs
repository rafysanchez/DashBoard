using Microsoft.AspNetCore.Mvc;
using Sow.Automation.Dashboard.Interfaces;
using Sow.Automation.Dashboard.ViewModels;
using Sow.Automation.Data.Entidades.Manipuladores.Interfaces;
using Sow.Automation.Data.Entidades.NotificacoesContexto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Automation.Dashboard.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IDomainNotificationHandler _notification;
        protected readonly IUserAppServices _userappService;



        public BaseController(IDomainNotificationHandler notification, IUserAppServices userappService)
        {
            _notification = notification;
            _userappService = userappService;
        }

        [HttpPost]
        public string ValidarLoginSenha(UserLoginViewModel user)
        {
            if (_userappService.Autenticar(user))
            {
                _userappService.AtualizaDadosSessao(user, HttpContext.Session);
                return "0";
            }
            else
            {
                return "1";
            }


        }

        #region Metodos privados
        protected bool CheckSession()
        {
            if ((HttpContext.Session.IsAvailable && _userappService.ValidaSessaoUsuario(HttpContext.Session)))
            {
                ViewData["usuario"] = _userappService.ObtemDadosSessao(HttpContext.Session).NomeUsuario;
                return true;
            }
            else
            {
                return false;
            }


        }

        protected string RetornaNotificacaoFormatada()
        {
            string result = "";
            _notification.GetNotifications().ForEach(a => result += $"<p> {a.Value} </p>");
            return result;
        }

        protected bool OperacaoValida()
        {
            return (!_notification.HasNotifications());
        }

        #endregion

    }
}
