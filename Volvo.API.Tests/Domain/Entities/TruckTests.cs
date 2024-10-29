using FluentAssertions;
using Volvo.API.Domain.Entities;
using Volvo.API.Domain.Models.Commands;
using Volvo.API.Domain.Models.Enum;
using Volvo.API.Utils.Exceptions;

namespace Volvo.API.Tests.Domain.Entities
{
    public class TruckTests
    {
        [Fact]
        public void Constructor_Should_Create_Valid_Truck_When_Command_Is_Valid()
        {
            // Arrange
            var command = new CreateTruckCommand
            {
                Chassis = "1HGCM82633A004352",
                Year = DateTime.Now.Year,
                Model = EModelType.FH,
                Color = "#FFFFFF",
                Plan = EPlan.Brazil
            };

            // Act
            var truck = new Truck(command);

            // Assert
            truck.Should().NotBeNull();
            truck.Chassis.Value.Should().Be("1HGCM82633A004352");
            truck.Year.Should().Be(command.Year);
            truck.ModelType.Should().Be(command.Model);
            truck.Color.Value.Should().Be("FFFFFF");
            truck.Plan.Should().Be(command.Plan);
        }

        [Fact]
        public void Constructor_Should_Throw_Exception_When_Command_Is_Invalid()
        {
            // Arrange
            var command = new CreateTruckCommand
            {
                Chassis = "INVALID_CHASSIS",
                Year = 1800, // Invalid year
                Model = (EModelType)999, // Invalid model
                Color = "InvalidColor",
                Plan = (EPlan)999 // Invalid plan
            };

            // Act
            Action act = () => new Truck(command);

            // Assert
            act.Should().Throw<EntityValidationException>()
                .WithMessage("*");
        }

        [Fact]
        public void Update_Should_Update_Truck_Details_When_Command_Is_Valid()
        {
            // Arrange
            var createCommand = new CreateTruckCommand
            {
                Chassis = "1HGCM82633A004352",
                Year = DateTime.Now.Year,
                Model = EModelType.FH,
                Color = "#FFFFFF",
                Plan = EPlan.Sweden
            };

            var truck = new Truck(createCommand);

            var updateCommand = new UpdateTruckCommand
            {
                Chassis = "1HGCM82633A004353",
                Year = DateTime.Now.Year + 1,
                Model = EModelType.FM,
                Color = "#000000",
                Plan = EPlan.UnitedStates
            };

            // Act
            truck.Update(updateCommand);

            // Assert
            truck.Chassis.Value.Should().Be("1HGCM82633A004353");
            truck.Year.Should().Be(updateCommand.Year);
            truck.ModelType.Should().Be(updateCommand.Model);
            truck.Color.Value.Should().Be("000000");
            truck.Plan.Should().Be(updateCommand.Plan);
        }

        [Fact]
        public void Update_Should_Throw_Exception_When_Command_Is_Invalid()
        {
            // Arrange
            var createCommand = new CreateTruckCommand
            {
                Chassis = "1HGCM82633A004352",
                Year = DateTime.Now.Year,
                Model = EModelType.FH,
                Color = "#FFFFFF",
                Plan = EPlan.Brazil
            };

            var truck = new Truck(createCommand);

            var updateCommand = new UpdateTruckCommand
            {
                Chassis = "INVALID_CHASSIS",
                Year = 1800, // Invalid year
                Model = (EModelType)999, // Invalid model
                Color = "InvalidColor",
                Plan = (EPlan)999 // Invalid plan
            };

            // Act
            Action act = () => truck.Update(updateCommand);

            // Assert
            act.Should().Throw<EntityValidationException>()
                .WithMessage("*");
        }
    }
}
