namespace Registriermachine.Compiler.InstructionsSet
{
    using Registriermachine.Register;

    public class ConditionalGoToInstruction : IInstruction
    {
        public ConditionalGoToInstruction(string registerCheck, int line)
        {
            this.RegisterCheck = registerCheck;
            this.Line = line;
        }

        public int Line { get; }

        public string RegisterCheck { get; }

        public void ExecuteOnRegister(IRegister register)
        {
            if (register[this.RegisterCheck] != 0)
            {
                register[RegistriermachineConstants.ProgramCounterRegister] += 1;
                return;
            }

            GoToInstruction goToInstruction = new GoToInstruction(this.Line);
            goToInstruction.ExecuteOnRegister(register);
        }
    }
}