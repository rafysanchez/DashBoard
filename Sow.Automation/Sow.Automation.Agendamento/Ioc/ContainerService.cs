using Ninject.Modules;
using Sow.Automation.Agendamento.Abstracao;
using Sow.Automation.Agendamento.Repository;
using Sow.Automation.Data.Contexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces.ContextoPadrao;
using Sow.Automation.Data.Repositorios.ContextoPadrao;
using Sow.Automation.Orquestrador.Abstracao;
using Sow.Automation.Orquestrador.PluginRpa;

namespace Sow.Automation.Orquestrador.Ioc
{
    public class ContainerService : NinjectModule
    {
        public override void Load()
        {
            Bind<IJobRepository<AgendamentoInfo>>().To<JobRepository<AgendamentoInfo>>().InSingletonScope();

            Bind<IAgendamentoRepository>().To<AgendamentoRepository>().InThreadScope()
                .WithConstructorArgument(new AgendamentoRepository(new DashBoardDbContext()));

            Bind<IAgendamentoExecucoesRepository>().To<AgendamentoExecucoesRepository>().InThreadScope()
                .WithConstructorArgument(new AgendamentoRepository(new DashBoardDbContext()));

            Bind<IService<AgendamentoInfo>>().To<PluginOmniCobranca>().InThreadScope();
        }
    }
}
