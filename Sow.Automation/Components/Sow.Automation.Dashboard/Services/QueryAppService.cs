using AutoMapper;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces;
using Sow.Automation.Dashboard.Interfaces;
using Sow.Automation.Dashboard.ViewModels;
using Sow.Automation.Data.Entidades.ServicosRoboContexto;
using Sow.Automation.Data.Services;

namespace Sow.Automation.Dashboard.Services
{
    public class QueryAppService : IQueryAppService
    {

        private readonly IRepository _repository;
        private readonly IRegrasForumRepository _repositoryRegras;
        private readonly IRegrasForunsBairrosRepository _repositoryRegrasBairro;
        private readonly ICustasRepository _repositoryCustas;
        private readonly IMapper _mapper;
        public QueryAppService(ICustasRepository repositoryCustas,
            IRegrasForunsBairrosRepository repositoryRegrasBairro, 
            IRegrasForumRepository repositoryRegras,
            IRepository repository, 
            IMapper mapper)
        {
            _repository = repository;
            _repositoryRegras = repositoryRegras;
            _repositoryRegrasBairro = repositoryRegrasBairro;
            _repositoryCustas = repositoryCustas;
            _mapper = mapper;
        }

        public IList<BairrosViewModel> ObterBairros()
        {
            return _mapper.Map<IList<BairrosViewModel>>(_repository.ObterTodos<Bairro>("Bairros"));
        }

        public IList<CidadeViewModel> ObterCidades()
        {
            return _mapper.Map<IList<CidadeViewModel>>(_repository.ObterTodos<Cidade>("Cidades"));
        }

        public IList<ComarcasViewModel> ObterComarcas()
        {
            return _mapper.Map<IList<ComarcasViewModel>>(_repository.ObterTodos<Comarca>("Comarcas"));
        }

        public IList<EstadosViewModel> ObterEstados()
        {
            return _mapper.Map<IList<EstadosViewModel>>(_repository.ObterTodos<Estado>("Estados"));
        }

        public IList<RegrasForunsBrasilViewModel> ObterRegras()
        {
            return _mapper.Map<IList<RegrasForunsBrasilViewModel>>(_repositoryRegras.ObterTodasRegrasDetalhado().ToList());
        }

        public IList<RegrasForunsBairrosViewModel> ObterRegrasBairro()
        {
            return _mapper.Map<IList<RegrasForunsBairrosViewModel>>(_repositoryRegrasBairro.ObterTodosBairrosDetalhado().ToList());
        }

        public IList<RegrasForunsBairrosViewModel> ObterTabelaBairros()
        {
            return _mapper.Map<IList<RegrasForunsBairrosViewModel>>(_repository.ObterTodosLocais().ToList());
        }

        public IList<RegrasForunsBairrosViewModel> ObterTabelaCidades()
        {
            return _mapper.Map<IList<RegrasForunsBairrosViewModel>>(_repository.ObterTodasCidades().ToList());
        }

        public IList<RegrasForunsBairrosViewModel> ObterTabelaComarcas()
        {
            return _mapper.Map<IList<RegrasForunsBairrosViewModel>>(_repository.ObterTodasComarca().ToList());
        }

        public IList<EstadosVsCustasViewModel> ObterTabelaCustas()
        {
            return _mapper.Map<IList<EstadosVsCustasViewModel>>(_repositoryCustas.ObterTodosDetalhado().ToList());
        }

        
    }
}
