using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto
{
    public class RegrasForunsBairros : EntidadeBase<RegrasForunsBairros>
    {
        public RegrasForunsBairros(long idEstado, long idComarca, long idCidade, long idbairro, string regra, bool status)
        {
            IdEstado = idEstado;
            IdComarca = idComarca;
            IdCidade = idCidade;
            IdBairro = idbairro;
            Regra = regra;
            Status = status;
        }
        private RegrasForunsBairros()
        {

        }

        public long IdEstado { get; private set; }
        public long IdComarca { get; private set; }
        public long IdCidade { get; private set; }
        public long IdBairro { get; private set; }
        public string Regra { get; private set; }
        public bool Status { get; private set; }

        public override bool IsValid()
        {
            Validate();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }


        private void Validate()
        {


            RuleFor(c => c.IdEstado)
                  .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(IdEstado)}!");
            RuleFor(c => c.IdCidade)
                  .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(IdComarca)}!");
            RuleFor(c => c.IdComarca)
                  .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(IdComarca)}!");
            RuleFor(c => c.Regra)
                  .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(Regra)}!");
            RuleFor(c => c.IdBairro)
                 .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(IdBairro)}!");
            RuleFor(c => c.IdEstado)
                 .NotEmpty().WithMessage($"Necessário Preenher o dado de {nameof(IdEstado)}!");
            RuleFor(c => c.IdCidade)
                  .NotEmpty().WithMessage($"Necessário Preenher o dado de {nameof(IdComarca)}!");
            RuleFor(c => c.IdComarca)
                  .NotEmpty().WithMessage($"Necessário Preenher o dado de {nameof(IdComarca)}!");
            RuleFor(c => c.Regra)
                  .NotEmpty().WithMessage($"Necessário Preenher o dado de {nameof(Regra)}!");
            RuleFor(c => c.IdBairro)
            .NotEmpty().WithMessage($"Necessário Preenher o dado de {nameof(IdBairro)}!");

        }
    }
}
