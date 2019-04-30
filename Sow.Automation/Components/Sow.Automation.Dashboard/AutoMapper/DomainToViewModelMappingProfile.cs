using AutoMapper;
using Sow.Automation.Dashboard.ViewModels;
using Sow.Automation.Data.Entidades.ServicosRoboContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Queries;
using Sow.Automation.Data.Entidades.UsuarioAplicacaoContexto;

namespace Sow.Automation.Dashboard.AutoMapper
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<UsuarioAplicacao, UserLoginViewModel>();
            CreateMap<Cidade, CidadeViewModel>();
            CreateMap<Comarca, ComarcasViewModel>();
            CreateMap<Bairro, BairrosViewModel>();
            CreateMap<Estado, EstadosViewModel>();
            CreateMap<RegrasForunsBrasil, RegrasForunsBrasilViewModel>();
            CreateMap<RegrasForunsBairros, RegrasForunsBairrosViewModel>();
            CreateMap<RegraBrasilQueryResult, RegrasForunsBrasilViewModel>();
            CreateMap<RegraBairroQueryResult, RegrasForunsBairrosViewModel>();

            CreateMap<CustasQueryResult, EstadosVsCustasViewModel>();
            CreateMap<EstadosVsCustas, EstadosVsCustasViewModel>();
            CreateMap<AgendamentoInfo, AgendamentoViewModel>();
            CreateMap<AgendamentoExecucao, AgendamentoExecucoesViewModel>();
            CreateMap<EmailInfo, EmailViewModel>();
        }
    }
}