using Volvo.API.Domain.Models.Validations;

namespace Volvo.API.Domain.Models.ValueObjects
{
    public class Chassis : ValueObject
    {
        public string Value { get; private set; }

        public Chassis(string value)
        {
            Value = value.Replace(" ", "").ToUpper();
        }

        public bool IsValid()
        {
            ValidationResult = new ChassisValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
