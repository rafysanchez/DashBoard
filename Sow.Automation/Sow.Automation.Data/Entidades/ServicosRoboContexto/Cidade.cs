using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto
{
    public class Cidade : EntidadeBase<Cidade>
    {
        public Cidade(long id, long idEstado, long idComarca, string descricao)
        {
            Id = id;
            IdEstado = idEstado;
            IdComarca = idComarca;
            Descricao = descricao;
        }

        public long Id { get; private set; }
        public long IdEstado { get; private set; }
        public long IdComarca { get; private set; }
        public string Descricao { get; private set; }

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
            RuleFor(a => a.IdComarca)
                 .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(IdComarca)}!");
            RuleFor(a => a.IdEstado)
                .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(IdEstado)}!");
            RuleFor(a => a.Descricao)
                .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(Descricao)}!");
        }
    }
}
