namespace Registriermachine.Tests.Compiler.InstructionsSet
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using FluentAssertions.Execution;
    using Registriermachine.Compiler.InstructionsSet;
    using Registriermachine.Register;
    using Xunit;

    public class ArithmeticInstructionTests
    {
        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { 2, 3, (Func<int, int, int>)((a, b) => a + b), 5 },
                new object[] { 8, 10, (Func<int, int, int>)((a, b) => a - b), -2 },
                new object[] { 200, 52, (Func<int, int, int>)((a, b) => a * b), 10400 },
            };

        [Theory]
        [MemberData(nameof(TestData))]
        public void ShouldCorrectlyExecute(int operandA, int operandB, Func<int, int, int> arithmeticFunction, int expectedResult)
        {
            // Arrange
            string registerResult = "R1";
            string registerOperandA = "R200";
            string registerOperandB = "R3";

            Register register = new Register();
            register[registerOperandA] = operandA;
            register[registerOperandB] = operandB;

            ArithmeticInstruction testee = new ArithmeticInstruction(registerResult, registerOperandA, registerOperandB, arithmeticFunction);

            // Act
            testee.ExecuteOnRegister(register);

            // Assert
            using (new AssertionScope())
            {
                register[RegistriermachineConstants.ProgramCounterRegister].Should().Be(expected: 1, because: "program counter should have been increased");
                register[registerResult].Should().Be(expectedResult, "correctly calculated");
            }
        }
    }
}