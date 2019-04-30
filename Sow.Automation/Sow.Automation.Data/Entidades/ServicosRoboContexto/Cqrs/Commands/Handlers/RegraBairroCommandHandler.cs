using Sow.Automation.Data.Entidades.Manipuladores;
using Sow.Automation.Data.Entidades.Manipuladores.Interfaces;
using Sow.Automation.Data.Entidades.NotificacoesContexto;

using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Commands.Handlers
{
    public class RegraBairroCommandHandler : CommandHandler,
         IHandler<RegrasForunsBairros>
    {
        IRegrasForunsBairrosRepository _repository;
        public RegraBairroCommandHandler(IRegrasForunsBairrosRepository repository, IDomainNotificationHandler notifications) : base(notifications)
        {
            _repository = repository;
        }

     

        public void HandleDelete(RegrasForunsBairros message)
        {
           
            var result = _repository.RemoverRegraBairro(message);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Regra Removida com Sucesso"));
            }
        }

        public void HandleInsert(RegrasForunsBairros message)
        {
          
            if (!message.IsValid())
            {
                NotificarValidacoesErro(message.ValidationResult);
                return;
            }


            var det = _repository.ObterTodosBairrosDetalhado()
                         .ToList().Find(a => a.IdEstado == message.IdEstado
                           && a.IdComarca == message.IdComarca
                            && a.IdCidade == message.IdCidade
                              && a.IdBairro == message.IdBairro);

            if (det != null)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, $"Ja existe um forum cadastrado com os seguintes dados :  {det.Estado} - {det.Comarca} - {det.Cidade} - {det.Bairro} - {det.Regra}, favor remover ou atualizar esta regra"));
                return;
            }

            var result = _repository.AdicionarRegraBairro(message);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Regra Inserida com Sucesso"));
            }
        }

        public void HandleUpdate(RegrasForunsBairros message)
        {
          
            if (!message.IsValid())
            {
                NotificarValidacoesErro(message.ValidationResult);
                return;
            }

            var result = _repository.AtualizarRegraBairro(message);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Regra Atualizada com Sucesso"));
            }
        }
    }
}
