namespace Registriermachine.ExecutableUnit
{
    using System.Collections.Generic;
    using Registriermachine.Compiler;
    using Registriermachine.Compiler.InstructionsSet;

    public interface IExecutableUnitFactory
    {
        IExecutableUnit CreateFromInstructions(List<IInstruction> program);

    }
}