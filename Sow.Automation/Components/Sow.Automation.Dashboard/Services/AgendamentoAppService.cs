using AutoMapper;
using Sow.Automation.Dashboard.Interfaces;
using Sow.Automation.Dashboard.ViewModels;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces.ContextoPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Automation.Dashboard.Services
{
    public class AgendamentoAppService : IAgendamentoAppService
    {
        private readonly IMapper _mapper;
        private readonly IAgendamentoRepository _repository;
        private readonly IAgendamentoExecucoesRepository _repositoryExec;

        public AgendamentoAppService(IMapper mapper, IAgendamentoRepository repository, IAgendamentoExecucoesRepository repositoryExec)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryExec = repositoryExec;
        }

        public IEnumerable<AgendamentoViewModel> ObterTabelaAgendamentos()
        {
            return _mapper.Map<IEnumerable<AgendamentoViewModel>>(_repository.ObterTodosAgendamentos());
        }

        public IEnumerable<AgendamentoExecucoesViewModel> ObterTabelaExecucoes()
        {
            return _mapper.Map<IEnumerable<AgendamentoExecucoesViewModel>>(_repositoryExec.ObterTodasExecucoes());
        }
    }
}
