namespace Registriermachine.Compiler.InstructionsSet
{
    using System.Text.RegularExpressions;

    public class ConstantInstructionTemplate : BaseInstructionTemplate, IInstructionTemplate
    {
        public ConstantInstructionTemplate()
            : base(new Regex(@"^(?<register>R\d+) \:\= (?<constant>[-]{0,1}\d+)$"))
        {
        }

        public IInstruction Compile(string code)
        {
            Match match = this.CodePattern.Match(code);
            string registerName = match.Groups["register"].Value;
            int constant = int.Parse(match.Groups["constant"].Value);

            return new ConstantInstruction(registerName, constant);
        }
    }
}