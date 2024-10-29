using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation.Results;

namespace Volvo.API.Domain.Models.ValueObjects
{
    public class ValueObject
    {
        [NotMapped]
        public virtual ValidationResult ValidationResult { get; protected set; }
    }
}
