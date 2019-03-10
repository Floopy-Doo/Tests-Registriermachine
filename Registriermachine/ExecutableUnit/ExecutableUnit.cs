namespace Registriermachine.ExecutableUnit
{
    using System.Collections.Generic;
    using Registriermachine.Compiler.InstructionsSet;
    using Registriermachine.Register;

    public class ExecutableUnit : IExecutableUnit
    {
        private readonly List<IInstruction> programInstructions;
        private readonly IRegister register;

        public ExecutableUnit(List<IInstruction> programInstructions, IRegister register)
        {
            this.programInstructions = programInstructions;
            this.register = register;
        }

        private int ProgramCounter => this.register[RegistriermachineConstants.ProgramCounterRegister];

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
            return this.register[RegistriermachineConstants.ProgramCounterRegister] > 0;
        }

        private IInstruction LoadInstruction()
        {
            return this.programInstructions[this.ProgramCounter];
        }
    }
}