using System.ComponentModel.DataAnnotations;
using Volvo.API.Domain.Models.Validations;

namespace Volvo.API.Domain.Models.ValueObjects
{
    public class ColorObj : ValueObject
    {
        public string Value { get; private set; }

        public ColorObj(string value)
        {
            Value = value.Replace("#", "");
            IsValid();
        }

        public bool IsValid()
        {
            ValidationResult = new ColorValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public override string ToString()
        {
            return $"#{Value}";
        }
    }
}
