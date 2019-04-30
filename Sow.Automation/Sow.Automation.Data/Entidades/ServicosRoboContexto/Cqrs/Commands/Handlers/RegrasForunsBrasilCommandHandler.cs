using Sow.Automation.Data.Entidades.Manipuladores;
using Sow.Automation.Data.Entidades.Manipuladores.Interfaces;
using Sow.Automation.Data.Entidades.NotificacoesContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces;
using System.Linq;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Commands.Handlers
{
    public class RegrasForunsBrasilCommandHandler : CommandHandler,
        IHandler<RegrasForunsBrasil>

    {

        private readonly IRegrasForumRepository _repository;

        public RegrasForunsBrasilCommandHandler(IRegrasForumRepository repository, IDomainNotificationHandler notifications) : base( notifications)
        {
            _repository = repository;
        }

       
        public void HandleDelete(RegrasForunsBrasil message)
        {
           
            var result = _repository.RemoverRegra(message);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Regra Bairro Removida com Sucesso"));
            }
        }

        public void HandleInsert(RegrasForunsBrasil message)
        {
           

            if (!message.IsValid())
            {
                NotificarValidacoesErro(message.ValidationResult);
                return;
            }

            var det = _repository.ObterTodasRegrasDetalhado()
                          .ToList().Find(a => a.IdEstado == message.IdEstado
                            && a.IdComarca == message.IdComarca
                             && a.IdCidade == message.IdCidade);

            if (det != null)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, $"Ja existe um forum cadastrado com os seguintes dados :  {det.Estado} - {det.Comarca} - {det.Cidade}  - {det.Regra}, favor remover ou atualizar esta regra"));
                return;
            }

            var result = _repository.AdicionarRegra(message);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Regra Bairro Inserida com Sucesso"));
            }
        }

        public void HandleUpdate(RegrasForunsBrasil message)
        {
         
            if (!message.IsValid())
            {
                NotificarValidacoesErro(message.ValidationResult);
                return;
            }


            var result = _repository.AtualizarRegra(message);

            if (!result.Success)
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, result.Message));
            }
            else
            {
                _notifications.AddNotification(new DomainNotification(message.MessageType, "Regra Bairro Atualizada com Sucesso"));
            }
        }
    }
}
