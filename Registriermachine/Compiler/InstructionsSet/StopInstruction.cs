namespace Registriermachine.Compiler.InstructionsSet
{
    using Registriermachine.Register;

    public class StopInstruction : IInstruction
    {
        public void ExecuteOnRegister(IRegister register)
        {
            register[RegistriermachineConstants.ProgramCounterRegister] = RegistriermachineConstants.EndOfProgram;
        }
    }
}