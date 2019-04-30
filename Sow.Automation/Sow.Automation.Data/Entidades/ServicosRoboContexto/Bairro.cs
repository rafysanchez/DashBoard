using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto
{
    public class Bairro : EntidadeBase<Bairro>
    {


        public Bairro(long id, long idCidade, string descricao)
        {
            Id = id;
            IdCidade = idCidade;
            Descricao = descricao;
        }

        private Bairro()
        {

        }

        public long Id { get; private set; }
        public long IdCidade { get; private set; }
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
            RuleFor(a => a.IdCidade)
                .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(IdCidade)}!");
            RuleFor(a => a.Descricao)
                .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(Descricao)}!");
        }
    }
}
