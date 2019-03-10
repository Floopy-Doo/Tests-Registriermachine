namespace Registriermachine.Tests
{
    using FluentAssertions;
    using Registriermachine.Register;
    using Xunit;

    public class RegisterTests
    {
        [Fact]
        public void ShouldReturnZeroWhenRegistryNotOtherwiseSet()
        {
            // Arrange
            Register testee = new Register();

            // Act
            int[] result =
            {
                testee["R0"],
                testee["R10"],
                testee["R32156874"]
            };

            // Assert
            result.Should().Equal(0, 0, 0);
        }

        [Fact]
        public void ShouldCorrectlySetRegistry()
        {
            // Arrange
            int expectedResult = 1234;
            string registerName = "R12";

            Register testee = new Register();

            // Act
            testee[registerName] = expectedResult;

            // Assert
            testee[registerName].Should().Be(expectedResult);
        }

        [Fact]
        public void ShouldCorrecltyOverrideOldRegistryEntry()
        {
            // Arrange
            int expectedResult = 99989;
            string registerName = "R3948";

            Register testee = new Register();
            testee[registerName] = 12;

            // Act
            testee[registerName] = expectedResult;

            // Assert
            testee[registerName].Should().Be(expectedResult);
        }
    }
}