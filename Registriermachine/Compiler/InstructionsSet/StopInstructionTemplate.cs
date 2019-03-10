namespace Registriermachine.Compiler.InstructionsSet
{
    using System.Text.RegularExpressions;

    public class StopInstructionTemplate : BaseInstructionTemplate, IInstructionTemplate
    {
        public StopInstructionTemplate() 
            : base(new Regex("^STOP$"))
        {
        }

        public IInstruction Compile(string code)
        {
            return new StopInstruction();
        }
    }
}