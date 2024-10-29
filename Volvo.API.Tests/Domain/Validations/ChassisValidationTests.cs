using FluentValidation.TestHelper;
using Volvo.API.Domain.Models.Validations;
using Volvo.API.Domain.Models.ValueObjects;

namespace Volvo.API.Tests.Domain.Validations
{
    public class ChassisValidationTests
    {
        private readonly ChassisValidation _validator = new ChassisValidation();

        [Fact]
        public void Should_Have_Error_When_Chassis_Length_Is_Too_Long()
        {
            // Arrange
            var chassis = new Chassis("12345678901234567890");

            // Act & Assert
            var result = _validator.TestValidate(chassis);
            result.ShouldHaveValidationErrorFor(c => c.Value)
                .WithErrorMessage("Chassi deve ter o número máximo de 17 caracteres.");
        }

        [Fact]
        public void Should_Have_Error_When_Chassis_Length_Not_Long_Enough()
        {
            // Arrange
            var chassis = new Chassis("1234567890123456");

            // Act & Assert
            var result = _validator.TestValidate(chassis);
            result.ShouldHaveValidationErrorFor(c => c.Value)
                .WithErrorMessage("Chassi deve ter o número mínimo de 17 caracteres.");
        }

        [Fact]
        public void Should_Have_Error_When_Chassis_Is_Empty()
        {
            // Arrange
            var chassis = new Chassis("");

            // Act & Assert
            var result = _validator.TestValidate(chassis);
            result.ShouldHaveValidationErrorFor(c => c.Value)
                .WithErrorMessage("Chassi não pode estar vazio.");
        }

        [Fact]
        public void Should_Have_Error_When_Chassis_Is_Invalid()
        {
            // Arrange
            var chassis = new Chassis("INVALID");

            // Act & Assert
            var result = _validator.TestValidate(chassis);
            result.ShouldHaveValidationErrorFor(c => c.Value)
                .WithErrorMessage("Chassi invalido.");
        }
    }
}
