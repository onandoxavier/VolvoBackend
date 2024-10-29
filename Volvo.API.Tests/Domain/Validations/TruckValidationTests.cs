using FluentValidation.TestHelper;
using Volvo.API.Domain.Entities;
using Volvo.API.Domain.Models.Validations;
using Volvo.API.Domain.Models.ValueObjects;

namespace Volvo.API.Tests.Domain.Validations
{
    public class TruckValidationTests
    {
        private readonly TruckValidation _validator = new TruckValidation();

        [Fact]
        public void Should_Have_Error_When_Chassis_Is_Invalid()
        {
            // Arrange
            var truck = new Truck
            {
                Chassis = new Chassis("INVALID")
            };

            // Act & Assert
            var result = _validator.TestValidate(truck);
            result.ShouldHaveValidationErrorFor(t => t.Chassis.Value)
                .WithErrorMessage("Chassi invalido.");
        }

        [Fact]
        public void Should_Have_Error_When_Year_Is_Invalid()
        {
            // Arrange
            var truck = new Truck
            {
                Year = 1800
            };

            // Act & Assert
            var result = _validator.TestValidate(truck);
            result.ShouldHaveValidationErrorFor(t => t.Year)
                .WithErrorMessage("O ano deve ser superior a 1900.");
        }

        [Fact]
        public void Should_Have_Error_When_Year_Is_Out_Limit()
        {
            // Arrange
            var truck = new Truck
            {
                Year = DateTime.Now.Year + 11
            };

            // Act & Assert
            var result = _validator.TestValidate(truck);
            result.ShouldHaveValidationErrorFor(t => t.Year)
                .WithErrorMessage("O ano deve ser inferir aos próximos 10 considerando a data atual.");
        }
    }
}
