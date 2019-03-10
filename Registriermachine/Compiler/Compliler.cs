namespace Registriermachine
{
    using System.Collections.Generic;

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