namespace Registriermachine.Tests.Compiler.InstructionsSet
{
    using FluentAssertions;
    using Registriermachine.Compiler.InstructionsSet;
    using Xunit;

    public class GoToInstructionTemplateTests
    {
        [Fact]
        public void ShouldCompileInstructionCorrectly()
        {
            // Arrange
            GoToInstructionTemplate testee = new GoToInstructionTemplate();

            // Act
            IInstruction instruction = testee.Compile("GOTO 145");

            // Assert
            instruction.Should().BeEquivalentTo(new GoToInstruction(145), o => o.RespectingRuntimeTypes());
        }

        [Theory]
        [InlineData("GOTO 12")]
        [InlineData("GOTO 9")]
        public void ShouldMatchCode(string code)
        {
            // Arrange
            GoToInstructionTemplate testee = new GoToInstructionTemplate();

            // Act
            bool result = testee.MatchesCode(code);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("IF R-1 = 0 GOTO 12")]
        [InlineData("GOTO -9")]
        [InlineData("GOTO")]
        public void ShouldNotMatchCode(string code)
        {
            // Arrange
            GoToInstructionTemplate testee = new GoToInstructionTemplate();

            // Act
            bool result = testee.MatchesCode(code);

            // Assert
            result.Should().BeFalse();
        }
    }
}