using FluentAssertions;
using Volvo.API.Domain.Models.ValueObjects;

namespace Volvo.API.Tests.Domain.ValueObjects
{
    public class ColorObjTests
    {
        [Theory]
        [InlineData("#FFFFFF")]
        [InlineData("#000000")]
        [InlineData("#FFA500")]
        public void ColorObj_Should_Be_Valid_When_Value_Is_Valid(string validColor)
        {
            // Act
            var color = new ColorObj(validColor);

            // Assert
            color.IsValid().Should().BeTrue();
            color.ToString().Should().Be(validColor);
        }

        [Theory]
        [InlineData("INVALID")]
        [InlineData("#GGGGGG")]
        [InlineData("")]
        public void ColorObj_Should_Be_Invalid_When_Value_Is_Invalid(string invalidColor)
        {
            // Act
            var color = new ColorObj(invalidColor);

            // Assert
            color.IsValid().Should().BeFalse();
        }
    }
}
