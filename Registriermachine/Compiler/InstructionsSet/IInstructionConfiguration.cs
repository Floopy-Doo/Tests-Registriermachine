namespace Registriermachine.Compiler.InstructionsSet
{
    public interface IInstructionConfiguration
    {
        IInstruction Compile(string code);

        bool MatchesCode(string code);
    }
}