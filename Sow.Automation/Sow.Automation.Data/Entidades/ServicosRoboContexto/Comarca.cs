using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto
{
    public class Comarca : EntidadeBase<Comarca>
    {
        public Comarca(long id, long idEstado, string descricao)
        {
            Id = id;
            IdEstado = idEstado;
            Descricao = descricao;
        }

        public long Id { get; private set; }
        public long IdEstado { get; private set; }
        public string Descricao { get; private set; }


        public void AtualizaDescricao(string desc)
        {
            this.Descricao = desc;
        }

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
            RuleFor(a => a.IdEstado)
                 .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(IdEstado)}!");
            RuleFor(a => a.Descricao)
                .NotNull().WithMessage($"Necessário Preenher o dado de {nameof(Descricao)}!");
        }
    }
}
