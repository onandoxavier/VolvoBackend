using FluentValidation;
using Volvo.API.Domain.Models.ValueObjects;

namespace Volvo.API.Domain.Models.Validations
{
    public class ColorValidation : AbstractValidator<ColorObj>
    {
        public ColorValidation()
        {
            RuleFor(transaction => transaction.Value)
                .Matches("^([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")
                .When(transaction => transaction.Value != null)
                .WithMessage("Valor invalido.");
        }
    }
}
