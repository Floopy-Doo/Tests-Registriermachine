namespace Registriermachine.Compiler
{
    public interface IInstruction
    {
        void ExecuteOnRegister(IRegister register);
    }
}