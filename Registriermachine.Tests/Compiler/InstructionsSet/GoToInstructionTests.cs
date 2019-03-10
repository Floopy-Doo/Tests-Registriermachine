namespace Registriermachine.Tests.Compiler.InstructionsSet
{
    using FluentAssertions;
    using FluentAssertions.Execution;
    using Registriermachine.Compiler.InstructionsSet;
    using Registriermachine.Register;
    using Xunit;

    public class GoToInstructionTests
    {
        [Fact]
        public void ShouldCorrectlyExecute()
        {
            // Arrange
            int gotoLine = 99;
            int expectedLine = gotoLine - 1 ;

            Register register = new Registriermachine.Register.Register();
            GoToInstruction testee = new GoToInstruction(gotoLine);

            // Act
            testee.ExecuteOnRegister(register);

            // Assert
            using (new AssertionScope())
            {
                register[RegistriermachineConstants.ProgramCounterRegister].Should().Be(expectedLine, "exected increase of programm counter");
            }
        }
    }
}