using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades
{
    public abstract class EntidadeBase<T> : AbstractValidator<T> where T : EntidadeBase<T>
    {
        public EntidadeBase()
        {
            ValidationResult = new ValidationResult();
        }
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool IsValid();
        public DateTime TimeStamp { get; protected set; }
        public string MessageType { get; protected set; }

    }
}
