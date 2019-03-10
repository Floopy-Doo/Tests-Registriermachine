namespace Registriermachine.Compiler.InstructionsSet
{
    using System.Text.RegularExpressions;

    public class AssignConstantInstructionTemplate : IInstructionTemplate
    {
        private readonly Regex codePattern = new Regex(@"^(?<register>R\d+) \:\= (?<constant>[-]{0,1}\d+)$");

        public IInstruction Compile(string code)
        {
            Match match = this.codePattern.Match(code);
            string registerName = match.Groups["register"].Value;
            int constant = int.Parse(match.Groups["constant"].Value);

            return new AssignConstantInstruction(registerName, constant);
        }

        public bool MatchesCode(string code)
        {
            return this.codePattern.IsMatch(code);
        }
    }
}