namespace Registriermachine.Tests.Compiler.InstructionsSet
{
    using FluentAssertions;
    using FluentAssertions.Execution;
    using Registriermachine.Compiler.InstructionsSet;
    using Registriermachine.Register;
    using Xunit;

    public class StopInstructionTests
    {
        [Fact]
        public void ShouldCorrectlyExecute()
        {
            // Arrange
            Register register = new Register();
            StopInstruction testee = new StopInstruction();

            // Act
            testee.ExecuteOnRegister(register);

            // Assert
            using (new AssertionScope())
            {
                register[RegistriermachineConstants.ProgramCounterRegister].Should().Be(RegistriermachineConstants.EndOfProgram);
            }
        }
    }
}