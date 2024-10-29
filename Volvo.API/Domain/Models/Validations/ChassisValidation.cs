using FluentValidation;
using Volvo.API.Domain.Models.ValueObjects;

namespace Volvo.API.Domain.Models.Validations
{
    public class ChassisValidation : AbstractValidator<Chassis>
    {
        public ChassisValidation()
        {
            RuleFor(u => u.Value)
                .MaximumLength(17)
                .WithMessage("Chassi deve ter o número máximo de 17 caracteres.");

            RuleFor(u => u.Value)
                .MinimumLength(17)
                .WithMessage("Chassi deve ter o número mínimo de 17 caracteres.");

            RuleFor(u => u.Value)
                .NotEmpty()
                .WithMessage("Chassi não pode estar vazio.");

            RuleFor(u => u.Value)
                .Matches("^[A-Za-z0-9]{3,3}[A-Za-z0-9]{6,6}[A-Za-z0-9]{2,2}[A-Za-z0-9]{6,6}$")
                .WithMessage("Chassi invalido.");
        }
    }
}
