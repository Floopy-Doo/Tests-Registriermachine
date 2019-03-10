namespace Registriermachine.Tests.Compiler.InstructionsSet
{
    using FluentAssertions;
    using Registriermachine.Compiler.InstructionsSet;
    using Xunit;

    public class ConditionalGoToInstructionTemplateTests
    {
        [Fact]
        public void ShouldCompileInstructionCorrectly()
        {
            // Arrange
            ConditionalGoToInstructionTemplate testee = new ConditionalGoToInstructionTemplate();

            // Act
            IInstruction instruction = testee.Compile("IF R2154 = 0 GOTO 145");

            // Assert
            instruction.Should().BeEquivalentTo(new GoToInstruction(145), o => o.RespectingRuntimeTypes());
        }

        [Theory]
        [InlineData("IF R0 = 0 GOTO 12")]
        [InlineData("IF R50 = 0 GOTO 9")]
        [InlineData("IF R2154 = 0 GOTO 145")]
        public void ShouldMatchCode(string code)
        {
            // Arrange
            ConditionalGoToInstructionTemplate testee = new ConditionalGoToInstructionTemplate();

            // Act
            bool result = testee.MatchesCode(code);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("IF R-1 = 0 GOTO 12")]
        [InlineData("IF R1 = 1 GOTO 9")]
        [InlineData("IF R2 = 0 GOTO -1")]
        public void ShouldNotMatchCode(string code)
        {
            // Arrange
            ConditionalGoToInstructionTemplate testee = new ConditionalGoToInstructionTemplate();

            // Act
            bool result = testee.MatchesCode(code);

            // Assert
            result.Should().BeFalse();
        }
    }
}