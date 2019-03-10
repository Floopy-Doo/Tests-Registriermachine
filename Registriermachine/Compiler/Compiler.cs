namespace Registriermachine.Compiler
{
    using System.Collections.Generic;
    using System.Linq;
    using Registriermachine.Compiler.InstructionsSet;
    using Registriermachine.ExecutableUnit;

    public class Compiler : ICompiler
    {
        private readonly IExecutableUnitFactory executableUnitFactory;
        private readonly List<IInstructionTemplate> instructionSet;

        public Compiler(List<IInstructionTemplate> instructionSet, IExecutableUnitFactory executableUnitFactory)
        {
            this.instructionSet = instructionSet;
            this.executableUnitFactory = executableUnitFactory;
        }

        public IExecutableUnit Compile(List<string> codeLines)
        {
            List<IInstruction> program = new List<IInstruction>();

            foreach (string codeLine in codeLines)
            {
                IInstructionTemplate matchingInstruction = this.instructionSet.SingleOrDefault(x => x.MatchesCode(codeLine));
                if (matchingInstruction == null)
                {
                    throw new InvalidCodeException();
                }

                IInstruction instruction = matchingInstruction.Compile(codeLine);
                program.Add(instruction);
            }

            return this.executableUnitFactory.CreateFromInstructions(program);
        }
    }
}