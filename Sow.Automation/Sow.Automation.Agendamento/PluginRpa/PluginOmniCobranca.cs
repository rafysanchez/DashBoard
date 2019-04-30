using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using Sow.Automation.Orquestrador.Abstracao;
using SOW.Automation.Kernel.Enums;
using SOW.Automation.OmniCobrancaWorkflow.Workflows;
using SOW.Automation.Pom.Models;
using SOW.Automation.Pom.Services;
using System.Collections.Generic;


namespace Sow.Automation.Orquestrador.PluginRpa
{
   public class PluginOmniCobranca  : IService<AgendamentoInfo>
    {
        public  void InicializaPlugin(AgendamentoInfo dadosAgendamento)
        {
          var  _container = new ContainerService(new List<ServicesEnum>() { ServicesEnum.WebService, ServicesEnum.OCRService });
          WorkflowAbertura.InicializaEtapa(_container.GetPom<OmniCobrancaPom>());
        }
    }
}
