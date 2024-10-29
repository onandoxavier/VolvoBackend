using FluentValidation.TestHelper;
using Volvo.API.Domain.Models.Validations;
using Volvo.API.Domain.Models.ValueObjects;

namespace Volvo.API.Tests.Domain.Validations
{
    public class ColorValidationTests
    {
        private readonly ColorValidation _validator = new ColorValidation();

        [Fact]
        public void Should_Have_Error_When_Color_Is_Invalid()
        {
            // Arrange
            var color = new ColorObj("INVALID");

            // Act & Assert
            var result = _validator.TestValidate(color);
            result.ShouldHaveValidationErrorFor(c => c.Value)
                .WithErrorMessage("Valor invalido.");
        }

        [Fact]
        public void Should_Not_Have_Error_When_Color_Is_Valid()
        {
            // Arrange
            var color = new ColorObj("#FFA500");

            // Act & Assert
            var result = _validator.TestValidate(color);
            result.ShouldNotHaveValidationErrorFor(c => c.Value);
        }
    }
}
