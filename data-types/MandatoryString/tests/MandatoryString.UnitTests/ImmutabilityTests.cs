using System;
using FluentAssertions;
using Xunit;

namespace StudioPasokon.ForEverProject.DataTypes.Tests
{
    /// <summary>
    /// This test class checks whether the <see cref="MandatoryString"/> indeed is immutable.
    /// </summary>
    public class ImmutabilityTests
    {
        [Theory]
        [InlineData("fullstring")]
        [InlineData("full with spaces")]
        [InlineData("spaces at the end   ")]
        [InlineData("   beginning with spaces")]
        [InlineData("z")]
        public void Construct_WithProperData_ReturnsMandatoryString(string data)
        {
            // Arrange / Act.
            var mandatoryString = new MandatoryString(data);

            // Assert.
            mandatoryString.ToString().Should().Be(data);   // Explicit ToString().

            string tmpString = mandatoryString;             // Implicit ToString().
            tmpString.Should().Be(data);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("          ")]
        [InlineData(" ")]
        public void Construct_WithFaultyData_ThrowsException(string data)
        {
            // Arrange / Act.
            Action act = () =>
            {
                var tmp = (new MandatoryString(data)).ToString();
            };

            // Assert.
            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("A mandatory string cannot be null, empty or fully whitespace (Parameter 'value')")
                .And.ParamName.Should().Be("value");
        }
    }
}
