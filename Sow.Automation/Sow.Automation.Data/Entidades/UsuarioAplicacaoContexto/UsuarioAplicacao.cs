using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.UsuarioAplicacaoContexto
{
    public class UsuarioAplicacao : EntidadeBase<UsuarioAplicacao>
    {
        public UsuarioAplicacao(long id, string nomeUsuario, string senhaUsuario)
        {
            Id = id;
            NomeUsuario = nomeUsuario;
            SenhaUsuario = senhaUsuario;
            IsValid();
        }

        public long Id { get; private set; }
        public string NomeUsuario { get; private set; }
        public string SenhaUsuario { get; private set; }


        public void AtualizaSenha(string senha)
        {
            this.SenhaUsuario = senha;
        }
        public override bool IsValid()
        {
            Validate();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            RuleFor(a => a.NomeUsuario)
                .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(NomeUsuario)}!");
            RuleFor(a => a.SenhaUsuario)
               .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(SenhaUsuario)}!");

            RuleFor(a => a.NomeUsuario)
               .NotEmpty().WithMessage($"Necessário Preenher o dado de {nameof(NomeUsuario)}!");
            RuleFor(a => a.SenhaUsuario)
               .NotEmpty().WithMessage($"Necessário Preenher o dado de {nameof(SenhaUsuario)}!");
        }
    }
}
