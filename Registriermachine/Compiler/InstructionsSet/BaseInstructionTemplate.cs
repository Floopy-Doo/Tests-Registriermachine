namespace Registriermachine.Compiler.InstructionsSet
{
    using System.Text.RegularExpressions;

    public abstract class BaseInstructionTemplate
    {
        public BaseInstructionTemplate(Regex codePattern)
        {
            this.CodePattern = codePattern;
        }

        protected Regex CodePattern { get; }

        public bool MatchesCode(string code)
        {
            return this.CodePattern.IsMatch(code);
        }
    }
}