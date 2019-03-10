namespace Registriermachine.Compiler.InstructionsSet
{
    using System.Text.RegularExpressions;

    public class GoToInstructionTemplate : BaseInstructionTemplate, IInstructionTemplate
    {
        public GoToInstructionTemplate()
            : base(new Regex(@"GOTO (?<line>\d+)"))
        {
        }

        public IInstruction Compile(string code)
        {
            Match match = this.CodePattern.Match(code);

            int line = int.Parse(match.Groups["line"].Value);

            return new GoToInstruction(line);
        }
    }
}