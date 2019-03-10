namespace Registriermachine.ExecutableUnit
{
    using System.Collections.Generic;
    using Registriermachine.Compiler;
    using Registriermachine.Compiler.InstructionsSet;
    using Registriermachine.Register;

    public class ExecutableUnitFactory : IExecutableUnitFactory
    {
        public IExecutableUnit CreateFromInstructions(List<IInstruction> program)
        {
            return new ExecutableUnit(program, new Register());
        }
    }
}