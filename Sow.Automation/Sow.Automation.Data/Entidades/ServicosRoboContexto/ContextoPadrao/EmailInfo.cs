using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao
{
    public class EmailInfo : EntidadeBase<EmailInfo>
    {
        #region Construtores
        public EmailInfo(string id, string assunto, string remetente, string destinatario)
        {
            IdProcesso = id.ToString();
            Assunto = assunto;
            Remetente = remetente;
            Destinatario = destinatario;
        }
        private EmailInfo()
        {

        }
        #endregion

        #region Propriedades
        public string IdProcesso { get; private set; }
        public string Assunto { get; private set; }
        public string Remetente { get; private set; }
        public string Destinatario { get; private set; }
        public string Destinatario_CC { get; private set; }
        public string Destinatario_CO { get; private set; }
        #endregion

        #region Metodos Publicos
        public void VincularIdAgendamento(string id)
        {
            this.IdProcesso = id;
        }
        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        public void AtualizaDestinatario_CC(string dest)
        {
            if (dest != null)
                this.Destinatario_CC = dest;
        }

        public void AtualizaDestinatario_CO(string dest)
        {
            if (dest != null)
                this.Destinatario_CO = dest;
        }
        #endregion

        #region Metodos Privados
        private void Validar()
        {
            ValidaEmail();
            ValidationResult = Validate(this);
        }
        #endregion

        #region Validações

        private void ValidaEmail()
        {

            RuleFor(c => c.Assunto)
                  .NotNull().NotEmpty().WithMessage("O Assunto do E-mail não pode ser nulo");

            RuleFor(c => c.Remetente)
                  .NotNull().NotEmpty().WithMessage("O Remetente do E-mail não pode ser nulo");

            RuleFor(c => c.Destinatario)
                  .NotNull().NotEmpty().WithMessage("O Destinatario do E-mail não pode ser nulo");

            RuleFor(c => c.Remetente)
                 .EmailAddress().WithMessage("O Remetente é invalido");

            RuleFor(c => c.Destinatario)
                  .Must(c => Regex.Match(c, @"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$").Success).WithMessage("O Destinatario é invalido");

            if (Destinatario_CC != null)
                RuleFor(c => c.Destinatario_CC)
                                 .Must(c => Regex.Match(c, @"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$").Success).WithMessage("O Destinatario CC é invalido");

            if (Destinatario_CO != null)
                RuleFor(c => c.Destinatario_CO)
                                 .Must(c => Regex.Match(c, @"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$").Success).WithMessage("O Destinatario CO é invalido");




            RuleFor(c => c.Destinatario)
                .Must(c => !c.Substring(c.Length - 1, 1).Contains(";")).WithMessage("O destinatario não pode conter ; no final");

            if (!string.IsNullOrWhiteSpace(Destinatario_CC))
                RuleFor(c => c.Destinatario_CC)
                    .Must(c => !c.Substring(c.Length - 1, 1).Contains(";")).WithMessage("O destinatario CC não pode conter ; no final");

            if (!string.IsNullOrWhiteSpace(Destinatario_CO))
                RuleFor(c => c.Destinatario_CO)
                    .Must(c => !c.Substring(c.Length - 1, 1).Contains(";")).WithMessage("O destinatario CO não pode conter ; no final");


        }



        #endregion
    }
}