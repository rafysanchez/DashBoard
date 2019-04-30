using AutoMapper;
using Sow.Automation.Dashboard.Interfaces;
using Sow.Automation.Dashboard.ViewModels;
using Sow.Automation.Data.Entidades;
using Sow.Automation.Data.Entidades.Manipuladores.Interfaces;
using Sow.Automation.Data.Entidades.ServicosRoboContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Commands.Handlers;
using Sow.Automation.Data.Services;

namespace Sow.Automation.Dashboard.Services
{
   public class RegisterAppService : IRegisterAppService
    {

        private readonly IMapper _mapper;
        private readonly IHandler<Bairro>  _bairroHandler;
        private readonly IHandler<Cidade> _cidadeHandler;
        private readonly IHandler<Comarca> _comarcaHandler;
        private readonly IHandler<RegrasForunsBairros> _regraBairroHandler;
        private readonly IHandler<RegrasForunsBrasil> _regraHandler;
        private readonly IHandler<EstadosVsCustas> _custaHandler;

        public RegisterAppService(IMapper mapper, 
            IHandler<Bairro> bairroHandler, 
            IHandler<EstadosVsCustas> custaHandler, 
            IHandler<Cidade> cidadeHandler, 
            IHandler<Comarca> comarcaHandler,
            IHandler<RegrasForunsBairros> regraBairroHandler,
            IHandler<RegrasForunsBrasil> regraHandler)
        {
            _mapper = mapper;
            _bairroHandler = bairroHandler;
            _cidadeHandler = cidadeHandler;
            _comarcaHandler = comarcaHandler;
            _regraBairroHandler = regraBairroHandler;
            _regraHandler = regraHandler;
            _custaHandler = custaHandler;
        }
        
       

        public void AtualizarBairro(BairrosViewModel bairro) => _bairroHandler.HandleUpdate(_mapper.Map<Bairro>(bairro));

        public void AtualizarCidade(CidadeViewModel bairro) => _cidadeHandler.HandleUpdate(_mapper.Map<Cidade>(bairro));

        public void AtualizarComarca(ComarcasViewModel comarca) => _comarcaHandler.HandleUpdate(_mapper.Map<Comarca>(comarca));

        public void AtualizarCusta(EstadosVsCustasViewModel custa) => _custaHandler.HandleUpdate(_mapper.Map<EstadosVsCustas>(custa));

        public void AtualizarRegra(RegrasForunsBrasilViewModel regra) => _regraHandler.HandleUpdate(_mapper.Map<RegrasForunsBrasil>(regra));

        public void AtualizarRegraBairro(RegrasForunsBairrosViewModel regraBairro) => _regraBairroHandler.HandleUpdate(_mapper.Map<RegrasForunsBairros>(regraBairro));

        public void RegistrarBairro(BairrosViewModel bairro) => _bairroHandler.HandleInsert(_mapper.Map<Bairro>(bairro));

        public void RegistrarCidade(CidadeViewModel cidade) => _cidadeHandler.HandleInsert(_mapper.Map<Cidade>(cidade));

        public void RegistrarComarca(ComarcasViewModel comarca) => _comarcaHandler.HandleInsert(_mapper.Map<Comarca>(comarca));

        public void RegistrarCusta(EstadosVsCustasViewModel custa) => _custaHandler.HandleInsert(_mapper.Map<EstadosVsCustas>(custa));

        public void RegistrarRegra(RegrasForunsBrasilViewModel regra) => _regraHandler.HandleInsert(_mapper.Map<RegrasForunsBrasil>(regra));

        public void RegistrarRegraBairro(RegrasForunsBairrosViewModel regraBairro) => _regraBairroHandler.HandleInsert(_mapper.Map<RegrasForunsBairros>(regraBairro));

        public void RemoverBairro(BairrosViewModel bairro) => _bairroHandler.HandleDelete(_mapper.Map<Bairro>(bairro));

        public void RemoverCidade(CidadeViewModel cidade) => _cidadeHandler.HandleDelete(_mapper.Map<Cidade>(cidade));

        public void RemoverComarca(ComarcasViewModel comarca) => _comarcaHandler.HandleDelete(_mapper.Map<Comarca>(comarca));

        public void RemoverCusta(EstadosVsCustasViewModel custa) => _custaHandler.HandleDelete(_mapper.Map<EstadosVsCustas>(custa));

        public void RemoverRegra(RegrasForunsBrasilViewModel regra) => _regraHandler.HandleDelete(_mapper.Map<RegrasForunsBrasil>(regra));

        public void RemoverRegraBairro(RegrasForunsBairrosViewModel regraBairro) => _regraBairroHandler.HandleDelete(_mapper.Map<RegrasForunsBairros>(regraBairro));
    }
}
