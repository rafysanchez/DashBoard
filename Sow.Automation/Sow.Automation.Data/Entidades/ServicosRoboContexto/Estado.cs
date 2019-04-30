using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto
{
    public class Estado : EntidadeBase<Estado>
    {
        public Estado(long id, string nome, string uf)
        {
            Id = id;
            Nome = nome;
            Uf = uf;
        }

        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Uf { get; private set; }

        public override bool IsValid()
        {
            Validate();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }



        private void Validate()
        {
            RuleFor(a => a.Id)
                .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(Id)}!");
            RuleFor(a => a.Nome)
               .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(Nome)}!");
            RuleFor(a => a.Uf)
               .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(Uf)}!");

        }
    }
}
