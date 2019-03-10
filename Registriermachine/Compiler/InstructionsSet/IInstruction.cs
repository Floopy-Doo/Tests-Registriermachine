namespace Registriermachine.Compiler.InstructionsSet
{
    using Registriermachine.Register;

    public interface IInstruction
    {
        void ExecuteOnRegister(IRegister register);
    }
}