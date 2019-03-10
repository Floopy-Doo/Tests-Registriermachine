namespace Registriermachine.Tests.Compiler.InstructionsSet
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using Registriermachine.Compiler.InstructionsSet;
    using Xunit;

    public class ArithmeticInstructionTemplateTests
    {
        public static IEnumerable<object[]> ValidMatchesTestData =>
            new List<object[]>
            {
                new object[] { '+', "R0 := R1 + R2" },
                new object[] { '-', "R88 := R2154 - R54646" },
                new object[] { '*', "R1 := R1 * R1" },
            };

        public static IEnumerable<object[]> InvalidMatchesTestData =>
            new List<object[]>
            {
                new object[] { '-', "R0 := R1 + R2" },
                new object[] { '*', "R88 := R2154 + R54646" },
                new object[] { '+', "R1 := R1 * R1" },
                new object[] { '+', "R-1 := R1 + R2" },
                new object[] { '+', "R88 := R + R54646" },
                new object[] { '+', "R1 := R1 *" },
                new object[] { '+', "R1 := R1 R2" },
            };

        [Fact]
        public void ShouldCompileInstructionCorrectly()
        {
            // Arrange
            Func<int, int, int> function = (a, b) => 1;
            ArithmeticInstructionTemplate testee = new ArithmeticInstructionTemplate('+', function);

            // Act
            IInstruction instruction = testee.Compile("R0 := R1 + R2");

            // Assert
            instruction.Should().BeEquivalentTo(new ArithmeticInstruction("R0", "R1", "R2", function), o => o.RespectingRuntimeTypes());
        }

        [Theory]
        [MemberData(nameof(ValidMatchesTestData))]
        public void ShouldMatchCode(char operand, string code)
        {
            // Arrange
            ArithmeticInstructionTemplate testee = new ArithmeticInstructionTemplate(operand, (a, b) => 1);

            // Act
            bool result = testee.MatchesCode(code);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(InvalidMatchesTestData))]
        public void ShouldNotMatchCode(char operand, string code)
        {
            // Arrange
            ArithmeticInstructionTemplate testee = new ArithmeticInstructionTemplate(operand, (a, b) => 1);

            // Act
            bool result = testee.MatchesCode(code);

            // Assert
            result.Should().BeFalse();
        }
    }
}