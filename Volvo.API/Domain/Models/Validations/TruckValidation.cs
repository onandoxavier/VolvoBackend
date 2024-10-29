using FluentValidation;
using Volvo.API.Domain.Entities;

namespace Volvo.API.Domain.Models.Validations
{
    public class TruckValidation : AbstractValidator<Truck>
    {
        public TruckValidation()
        {
            RuleFor(u => u.Chassis)
                .SetValidator(new ChassisValidation());

            RuleFor(u => u.Year)
                .GreaterThan(1900)
                .WithMessage("O ano deve ser superior a 1900.");

            RuleFor(u => u.Year)
                .LessThan(DateTime.Now.Year + 10)
                .WithMessage("O ano deve ser inferir aos próximos 10 considerando a data atual.");
        }
    }
}
