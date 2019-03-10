namespace Registriermachine.Tests.Compiler.InstructionsSet
{
    using FluentAssertions;
    using FluentAssertions.Execution;
    using Registriermachine.Compiler.InstructionsSet;
    using Registriermachine.Register;
    using Xunit;

    public class ConditionalGoToInstructionTests
    {
        [Fact]
        public void ShouldCorrectlyExecuteWhenConditionTrue()
        {
            // Arrange
            string registerName = "R20";
            int gotoLine = 77;
            int expectedProgramCounter = gotoLine - 1;

            Register register = new Registriermachine.Register.Register();
            register[registerName] = 0;

            ConditionalGoToInstruction testee = new ConditionalGoToInstruction(registerName, gotoLine);

            // Act
            testee.ExecuteOnRegister(register);

            // Assert
            using (new AssertionScope())
            {
                register[RegistriermachineConstants.ProgramCounterRegister].Should().Be(expectedProgramCounter, "exected increase of programm counter");
            }
        }

        [Fact]
        public void ShouldCorrectlyExecuteWhenConditionFalse()
        {
            // Arrange
            string registerName = "R20";
            int gotoLine = 88;
            int programCounter = 12;
            int expectedProgramCounter = programCounter + 1;

            Register register = new Registriermachine.Register.Register();
            register[RegistriermachineConstants.ProgramCounterRegister] = programCounter;
            register[registerName] = 1;

            ConditionalGoToInstruction testee = new ConditionalGoToInstruction(registerName, gotoLine);

            // Act
            testee.ExecuteOnRegister(register);

            // Assert
            using (new AssertionScope())
            {
                register[RegistriermachineConstants.ProgramCounterRegister].Should().Be(expectedProgramCounter, "normaly increase program counter");
            }
        }
    }
}