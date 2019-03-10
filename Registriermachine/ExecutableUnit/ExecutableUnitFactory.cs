namespace Registriermachine
{
    using System.Collections.Generic;
    using Registriermachine.Compiler;

    public class ExecutableUnitFactory : IExecutableUnitFactory
    {
        public IExecutableUnit CreateFromInstructions(List<IInstruction> program)
        {
            return new ExecutableUnit(program, new Register());
        }
    }
}