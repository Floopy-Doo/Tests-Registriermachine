namespace Registriermachine.Compiler.InstructionsSet
{
    using Registriermachine.Register;

    public class AssignConstantInstruction : IInstruction
    {
        public AssignConstantInstruction(string registerName, int constant)
        {
            this.RegisterName = registerName;
            this.Constant = constant;
        }

        public int Constant { get; }

        public string RegisterName { get; }

        public void ExecuteOnRegister(IRegister register)
        {
            register[this.RegisterName] = this.Constant;
            register[RegistriermachineConstants.ProgramCounterRegister] += 1;
        }
    }
}