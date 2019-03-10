namespace Registriermachine.Tests.Compiler.InstructionsSet
{
    using FluentAssertions;
    using Registriermachine.Compiler.InstructionsSet;
    using Xunit;

    public class StopInstructionTemplateTests
    {
        [Fact]
        public void ShouldCompileInstructionCorrectly()
        {
            // Arrange
            StopInstructionTemplate testee = new StopInstructionTemplate();

            // Act
            IInstruction instruction = testee.Compile("STOP");

            // Assert
            instruction.Should().BeOfType<StopInstruction>();
        }

        [Theory]
        [InlineData("STOP")]
        public void ShouldMatchCode(string code)
        {
            // Arrange
            StopInstructionTemplate testee = new StopInstructionTemplate();

            // Act
            bool result = testee.MatchesCode(code);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("S T O P")]
        [InlineData("stop")]
        [InlineData(" STOP ")]
        [InlineData("STOP 1")]
        public void ShouldNotMatchCode(string code)
        {
            // Arrange
            StopInstructionTemplate testee = new StopInstructionTemplate();

            // Act
            bool result = testee.MatchesCode(code);

            // Assert
            result.Should().BeFalse();
        }
    }
}