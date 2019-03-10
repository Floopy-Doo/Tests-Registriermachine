namespace Registriermachine.Tests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Xbehave;

    public class RegistriermachineFeature
    {
        [Scenario]
        public void ShouldExecuteProgramCorrectly()
        {
            List<string> codeLines = null;
            List<IInstructionConfiguration> instuctionSet = null;

            IRegister register = null;

            "Given I given set of code lines".x(
                () =>
                {
                    codeLines =
                        new List<string>
                        {
                            "R0 := 10",
                            "R1 := 1",
                            "R2 := 1",
                            "R2 := R2 * R0",
                            "R0 := R0 - R1",
                            "IF R0 = 0 GOTO 8",
                            "GOTO 4",
                            "R0 := R2 + R3",
                            "STOP"
                        };
                });

            "And I have the following instruction set available".x(
                () =>
                {
                    instuctionSet =
                        new List<IInstructionConfiguration>();
                });

            "When I compile and execute those line of code".x(
                () =>
                {
                    IExecutableUnitFactory executableUnitFactory = new ExecutableUnitFactory();
                    ICompiler compiler = new Compliler(instuctionSet, executableUnitFactory);
                    IExecutableUnit executableUnit = compiler.Compile(codeLines);
                    register = executableUnit.Execute();
                });

            "Then i get the correct result".x(
                () => { register["R0"].Should().Be(expected: 3628800); });
        }
    }
}