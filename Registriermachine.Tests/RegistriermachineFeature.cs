﻿namespace Registriermachine.Tests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Registriermachine.Compiler;
    using Registriermachine.Compiler.InstructionsSet;
    using Registriermachine.ExecutableUnit;
    using Registriermachine.Register;
    using Xbehave;

    public class RegistriermachineFeature
    {
        [Scenario]
        public void ShouldExecuteProgramCorrectly()
        {
            List<string> codeLines = null;
            List<IInstructionTemplate> instuctionSet = null;

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
                        new List<IInstructionTemplate>
                        {
                            new ConstantInstructionTemplate(),
                            new ArithmeticInstructionTemplate('+', (a, b) => a + b),
                            new ArithmeticInstructionTemplate('-', (a, b) => a - b),
                            new ArithmeticInstructionTemplate('*', (a, b) => a * b),
                            new GoToInstructionTemplate(),
                            new ConditionalGoToInstructionTemplate(),
                            new StopInstructionTemplate()
                        };
                });

            "When I compile and execute those line of code".x(
                () =>
                {
                    IExecutableUnitFactory executableUnitFactory = new ExecutableUnitFactory();
                    ICompiler compiler = new Registriermachine.Compiler.Compiler(instuctionSet, executableUnitFactory);
                    IExecutableUnit executableUnit = compiler.Compile(codeLines);
                    register = executableUnit.Execute();
                });

            "Then i get the correct result".x(
                () => { register["R0"].Should().Be(expected: 3628800); });
        }
    }
}