namespace Registriermachine.Compiler.InstructionsSet
{
    using Registriermachine.Register;

    public class GoToInstruction : IInstruction
    {
        public GoToInstruction(int line)
        {
            this.Line = line;
        }

        public int Line { get; }

        public void ExecuteOnRegister(IRegister register)
        {
            register[RegistriermachineConstants.ProgramCounterRegister] = this.Line - 1;
        }
    }
}