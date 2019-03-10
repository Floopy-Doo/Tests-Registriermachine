namespace Registriermachine.Compiler.InstructionsSet
{
    public interface IInstructionTemplate
    {
        IInstruction Compile(string code);

        bool MatchesCode(string code);
    }
}