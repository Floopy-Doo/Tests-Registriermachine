namespace Registriermachine.Compiler
{
    using Registriermachine.Register;

    public interface IInstruction
    {
        void ExecuteOnRegister(IRegister register);
    }
}