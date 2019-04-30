using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto
{
   public class EstadosVsCustas : EntidadeBase<EstadosVsCustas>
    {
        public EstadosVsCustas(long idEstado, long de, long ate)
        {
            IdEstado = idEstado;
            De = de;
            Ate = ate;
        }

        public long IdEstado { get; private set; }
        public long De { get; private set; }
        public long Ate { get; private set; }

        public override bool IsValid()
        {
            Validate();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            RuleFor(a => a.IdEstado)
                 .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(IdEstado)}!");
            RuleFor(a => a.De)
                 .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(De)}!");
            RuleFor(a => a.Ate)
                .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(Ate)}!");
            RuleFor(a => a.De)
                 .LessThanOrEqualTo(a => a.Ate).WithMessage($"O Valor De não pode ser menor que o valor de Ate ");
        }
    }
}
