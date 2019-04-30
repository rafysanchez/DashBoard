using Sow.Automation.Data.Entidades.Manipuladores;
using Sow.Automation.Data.Entidades.Manipuladores.Interfaces;
using Sow.Automation.Data.Entidades.NotificacoesContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces.ContextoPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao.EmailInfo;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao.Handlers
{
    public class AgendamentoHandler : CommandHandler,
        IHandler<AgendamentoInfo>
    {

        private readonly IAgendamentoRepository _repository;
        public AgendamentoHandler(IDomainNotificationHandler notifications, IAgendamentoRepository repository) : base(notifications)
        {
            _repository = repository;
        }

        public void HandleDelete(AgendamentoInfo message)
        {
            var result = _repository.RemoverAgendamentoInfoPorID(message.IdProcesso);
            _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
        }

        public void HandleInsert(AgendamentoInfo message)
        {
            message.Email.AtualizaDestinatario_CC(message.Email.Destinatario_CC);
            message.Email.AtualizaDestinatario_CO(message.Email.Destinatario_CO);

            if (!message.IsValid())
            {
                NotificarValidacoesErro(message.ValidationResult);
                return;
            }

          var result =  _repository.AdicionarAgendamento(message);
          _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
 
        }

        public void HandleUpdate(AgendamentoInfo message)
        {
            message.Email.AtualizaDestinatario_CC(message.Email.Destinatario_CC);
            message.Email.AtualizaDestinatario_CO(message.Email.Destinatario_CO);


            if (!message.IsValid())
            {
                NotificarValidacoesErro(message.ValidationResult);
                return;
            }

            var result = _repository.AtualizarAgendamentoInfoPorID(message);
            _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
        }
    }
}
