namespace Registriermachine.ExecutableUnit
{
    using System.Collections.Generic;
    using Registriermachine.Compiler;
    using Registriermachine.Register;

    public class ExecutableUnit : IExecutableUnit
    {
        private const string ProgramCounterRegister = "PC";

        private readonly List<IInstruction> programInstructions;
        private readonly IRegister register;

        public ExecutableUnit(List<IInstruction> programInstructions, IRegister register)
        {
            this.programInstructions = programInstructions;
            this.register = register;
        }

        private int ProgramCounter => this.register[ProgramCounterRegister];

        public IRegister Execute()
        {
            while (this.HasReachedProgramEnd())
            {
                IInstruction loadedInstruction = this.LoadInstruction();
                loadedInstruction.ExecuteOnRegister(this.register);
            }

            return this.register;
        }

        private bool HasReachedProgramEnd()
        {
            return this.register[ProgramCounterRegister] > 0;
        }

        private IInstruction LoadInstruction()
        {
            return this.programInstructions[this.ProgramCounter];
        }
    }
}