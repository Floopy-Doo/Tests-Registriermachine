namespace Registriermachine.Compiler.InstructionsSet
{
    using System.Text.RegularExpressions;

    public class ConditionalGoToInstructionTemplate : BaseInstructionTemplate, IInstructionTemplate
    {
        public ConditionalGoToInstructionTemplate()
            : base(new Regex(@"^IF (?<registerCheck>R\d+) \= 0 GOTO (?<line>d+)$"))
        {
        }

        public IInstruction Compile(string code)
        {
            Match match = this.CodePattern.Match(code);

            string registerCheck = match.Groups["registerCheck"].Value;
            int line = int.Parse(match.Groups["line"].Value);

            return new ConditionalGoToInstruction(registerCheck, line);
        }
    }
}