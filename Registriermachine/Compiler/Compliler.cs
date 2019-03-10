namespace Registriermachine.Compiler
{
    using System.Collections.Generic;
    using Registriermachine.Compiler.InstructionsSet;
    using Registriermachine.ExecutableUnit;

    public class Compliler : ICompiler
    {
        public Compliler(List<IInstructionConfiguration> instuctionSet, IExecutableUnitFactory executableUnitFactory)
        {
        }

        public IExecutableUnit Compile(List<string> codeLines)
        {
            return null;
        }
    }
}