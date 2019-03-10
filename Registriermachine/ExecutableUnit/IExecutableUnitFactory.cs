namespace Registriermachine
{
    using System.Collections.Generic;
    using Registriermachine.Compiler;

    public interface IExecutableUnitFactory
    {
        IExecutableUnit CreateFromInstructions(List<IInstruction> program);

    }
}