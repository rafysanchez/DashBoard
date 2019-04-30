using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sow.Automation.Dashboard.Interfaces;
using Sow.Automation.Dashboard.Structs;
using Sow.Automation.Dashboard.ViewModels;
using Sow.Automation.Data.Entidades.Manipuladores.Interfaces;
using Sow.Automation.Data.Entidades.ServicosRoboContexto;
using Sow.Automation.Data.Services;

namespace Sow.Automation.Dashboard.Controllers
{
    public class ConfiguracoesController : BaseController
    {
        public ConfiguracoesController(IDomainNotificationHandler notification, IMapper mapper,
            IUserAppServices userappService,
            IRegisterAppService registerAppService,
            IQueryAppService localsAppService,
            JsonServices jsonService) : base(notification, userappService)
        {
            _registerAppService = registerAppService;
            _localsAppService = localsAppService;
            _jsonService = jsonService;
            _mapper = mapper;
        }

        #region Variaveis
        private readonly IRegisterAppService _registerAppService;
        private readonly IQueryAppService _localsAppService;
        private readonly IMapper _mapper;
        private readonly JsonServices _jsonService;
        #endregion

        #region Views
        public IActionResult ConfiguracaoParametros()
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

        #region Chamadas Ajax

        [HttpPost]
        public IActionResult ListarCidades([FromBody] long idEstado)
        {
            if (CheckSession())
            {
                return Json(_localsAppService.ObterComarcas().ToList().FindAll(a => a.IdEstado == idEstado));
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }

        [HttpPost]
        public string CadastrarComarca([FromBody]ComarcasViewModel Dados)
        {
            if (CheckSession())
            {
                   _registerAppService.RegistrarComarca(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string CadastrarCusta([FromBody]EstadosVsCustasViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.RegistrarCusta(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string RemoverCusta([FromBody]EstadosVsCustasViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.RemoverCusta(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string AtualizarCusta([FromBody]EstadosVsCustasViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.AtualizarCusta(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string AtualizarComarca([FromBody]ComarcasViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.AtualizarComarca(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string RemoverComarca([FromBody]ComarcasViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.RemoverComarca(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string CadastrarCidade([FromBody]CidadeViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.RegistrarCidade(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string AtualizarCidade([FromBody]CidadeViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.AtualizarCidade(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string RemoverCidade([FromBody]CidadeViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.RemoverCidade(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string CadastrarBairro([FromBody]BairrosViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.RegistrarBairro(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string AtualizarBairro([FromBody]BairrosViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.AtualizarBairro(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string RemoverBairro([FromBody]BairrosViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.RemoverBairro(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string CadastrarRegra([FromBody]RegrasForunsBrasilViewModel Dados)
        {
            if (CheckSession())
            {

                _registerAppService.RegistrarRegra(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }


        }

        [HttpPost]
        public string AtualizarRegra([FromBody]RegrasForunsBrasilViewModel Dados)
        {
            if (CheckSession())
            {

                _registerAppService.AtualizarRegra(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }


        }

        [HttpPost]
        public string RemoverRegra([FromBody] RegrasForunsBrasilViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.RemoverRegra(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string CadastrarRegraBairro([FromBody] RegrasForunsBairrosViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.RegistrarRegraBairro(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string AtualizarRegraBairro([FromBody] RegrasForunsBairrosViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.AtualizarRegraBairro(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string RemoverRegraBairro([FromBody] RegrasForunsBairrosViewModel Dados)
        {
            if (CheckSession())
            {
                _registerAppService.RemoverRegraBairro(Dados);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string RemoverContrato([FromBody] long contrato)
        {
            if (CheckSession())
            {
                _jsonService.Remover<long>("Contratos.json", contrato);
                return RetornaNotificacaoFormatada();

            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string RemoverDespesa([FromBody] long despesa)
        {
            if (CheckSession())
            {
                if (CheckSession())
                {
                    _jsonService.Remover<long>("Despesas.json", despesa);
                    return RetornaNotificacaoFormatada();

                }
                else
                {
                    return "Sessão Expirou";
                }
            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string CadastrarDespesa([FromBody] long despesa)
        {
            if (CheckSession())
            {
                if (CheckSession())
                {
                    _jsonService.Adicionar<long>("Despesas.json", despesa);
                    return RetornaNotificacaoFormatada();

                }
                else
                {
                    return "Sessão Expirou";
                }
            }
            else
            {
                return "Sessão Expirou";
            }
        }

        [HttpPost]
        public string CadastrarContrato([FromBody] long contrato)
        {
            if (CheckSession())
            {
                if (CheckSession())
                {
                    _jsonService.Adicionar<long>("Contratos.json", contrato);
                    return RetornaNotificacaoFormatada();

                }
                else
                {
                    return "Sessão Expirou";
                }
            }
            else
            {
                return "Sessão Expirou";
            }
        }
        #endregion

        #region Chamadas de View Components



        public IActionResult CadastroRegras()
        {
            if (CheckSession())
                return ViewComponent("CadastroRegras");
            
                return Redirect("/Home/Login");
        }
        [HttpPost]
        public IActionResult PopulaOpcoesDropDown([FromBody] FiltroDropDown Dados)
        {
            if (CheckSession())
                return ViewComponent("DropDownList", new { Dados });

                return Redirect("/Home/Login");
            
        }

        [HttpPost]
        public IActionResult ListarRegras([FromBody] string fluxo)
        {
            if (CheckSession())
                return ViewComponent("GerenciaRegras", new { fluxo });
  
                return Redirect("/Home/Login");
            
        }
        #endregion
    }
}
