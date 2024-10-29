using FluentAssertions;
using Volvo.API.Domain.Models.ValueObjects;

namespace Volvo.API.Tests.Domain.ValueObjects
{
    public class ChassisTests
    {
        [Theory]
        [InlineData("1HGCM82633A004352")]
        [InlineData("JHMFA16546S000000")]
        public void Chassis_Should_Be_Valid_When_Value_Is_Valid(string validChassis)
        {
            // Act
            var chassis = new Chassis(validChassis);

            // Assert
            chassis.IsValid().Should().BeTrue();
            chassis.Value.Should().Be(validChassis.ToUpper());
        }

        [Theory]
        [InlineData("INVALID")]
        [InlineData("")]
        public void Chassis_Should_Be_Invalid_When_Value_Is_Invalid(string invalidChassis)
        {
            // Act
            var chassis = new Chassis(invalidChassis);

            // Assert
            chassis.IsValid().Should().BeFalse();
        }
    }
}
