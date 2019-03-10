namespace Registriermachine.Tests.Compiler.InstructionsSet
{
    using FluentAssertions;
    using Registriermachine.Compiler.InstructionsSet;
    using Xunit;

    public class AssignConstantInstructionTemplateTests
    {
        [Fact]
        public void ShouldCompileInstructionCorrectly()
        {
            // Arrange
            AssignConstantInstructionTemplate testee = new AssignConstantInstructionTemplate();

            // Act
            IInstruction instruction = testee.Compile("R10 := 9");

            // Assert
            instruction.Should().BeEquivalentTo(new AssignConstantInstruction("R10", constant: 9), o => o.RespectingRuntimeTypes());
        }

        [Theory]
        [InlineData("R0 := 12")]
        [InlineData("R200 := 888")]
        [InlineData("R0 := -10")]
        public void ShouldMatchCode(string code)
        {
            // Arrange
            AssignConstantInstructionTemplate testee = new AssignConstantInstructionTemplate();

            // Act
            bool result = testee.MatchesCode(code);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("R354128 := Constant")]
        [InlineData("R-10 := Constant")]
        [InlineData("PC := 1")]
        [InlineData("X0 := 12")]
        public void ShouldNotMatchCode(string code)
        {
            // Arrange
            AssignConstantInstructionTemplate testee = new AssignConstantInstructionTemplate();

            // Act
            bool result = testee.MatchesCode(code);

            // Assert
            result.Should().BeFalse();
        }
    }
}