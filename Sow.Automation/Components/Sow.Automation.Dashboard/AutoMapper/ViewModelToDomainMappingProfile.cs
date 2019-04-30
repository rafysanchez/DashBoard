using AutoMapper;
using Sow.Automation.Dashboard.ViewModels;
using Sow.Automation.Data.Entidades.ServicosRoboContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using Sow.Automation.Data.Entidades.UsuarioAplicacaoContexto;

namespace Sow.Automation.Dashboard.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {

            CreateMap<AgendamentoViewModel, AgendamentoInfo>()
                 .ConstructUsing(c => new AgendamentoInfo(c.IdProcesso,c.DataInicio,c.Descricao,c.NomeAgente,c.Periodicidade,c.FrequenciaPeriodicidade.Value,c.StatusAgendamento,c.HoraInicio.Value,c.MinutoInicio.Value,c.AmPm,c.Ativo,c.DisparoManual,
                 new EmailInfo(c.IdProcesso,c.Email.Assunto,c.Email.Remetente,c.Email.Destinatario)));


            CreateMap<UserLoginViewModel, UsuarioAplicacao>()
                .ConstructUsing(c => new UsuarioAplicacao(c.Id, c.NomeUsuario, c.SenhaUsuario));
            
            CreateMap<RegrasForunsBairrosViewModel, RegrasForunsBairros>()
                .ConstructUsing(c=> new RegrasForunsBairros(c.IdEstado,c.IdComarca,c.IdCidade,c.IdBairro,c.Regra,c.Status));


            CreateMap<RegrasForunsBrasilViewModel, RegrasForunsBrasil>()
                .ConstructUsing(c=> new RegrasForunsBrasil(c.IdEstado,c.IdComarca,c.IdCidade,c.Regra,c.Status));


            CreateMap<ComarcasViewModel, Comarca>()
                .ConstructUsing(c => new Comarca(c.Id,c.IdEstado,c.Descricao));

            CreateMap<CidadeViewModel, Cidade>()
                .ConstructUsing(c => new Cidade(c.Id, c.IdEstado,c.IdComarca, c.Descricao));

            CreateMap<BairrosViewModel, Bairro>()
               .ConstructUsing(c => new Bairro(c.Id, c.IdCidade, c.Descricao));

            CreateMap<EstadosVsCustasViewModel, EstadosVsCustas>()
             .ConstructUsing(c=> new EstadosVsCustas(c.IdEstado,c.De,c.Ate));
        }
    }
}