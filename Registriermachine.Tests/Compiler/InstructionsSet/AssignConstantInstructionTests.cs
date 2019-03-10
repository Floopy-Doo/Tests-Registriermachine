namespace Registriermachine.Tests.Compiler.InstructionsSet
{
    using FluentAssertions;
    using FluentAssertions.Execution;
    using Registriermachine.Compiler.InstructionsSet;
    using Registriermachine.Register;
    using Xunit;

    public class AssignConstantInstructionTests
    {
        [Fact]
        public void ShouldCorrectlyExecute()
        {
            // Arrange
            string expectedRegisterName = "R10";
            int programCounter = 10;
            int expectedProgramCounter = programCounter + 1;
            int expectedConstant = 99;

            Register register = new Register();
            register[RegistriermachineConstants.ProgramCounterRegister] = programCounter;
            AssignConstantInstruction testee = new AssignConstantInstruction(expectedRegisterName, expectedConstant);

            // Act
            testee.ExecuteOnRegister(register);

            // Assert
            using (new AssertionScope())
            {
                register[expectedRegisterName].Should().Be(expectedConstant, "expected correct register to be filled with constant");
                register[RegistriermachineConstants.ProgramCounterRegister].Should().Be(expectedProgramCounter, "exected increase of programm counter");
            }
        }
    }
}