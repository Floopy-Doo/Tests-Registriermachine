namespace Registriermachine.Compiler.InstructionsSet
{
    using System;
    using Registriermachine.Register;

    public class ArithmeticInstruction : IInstruction
    {
        public ArithmeticInstruction(
            string registerResult,
            string registerOperand1,
            string registerOperand2,
            Func<int, int, int> arithmeticFunction)
        {
            this.RegisterResult = registerResult;
            this.RegisterOperand1 = registerOperand1;
            this.RegisterOperand2 = registerOperand2;
            this.ArithmeticFunction = arithmeticFunction;
        }

        public Func<int, int, int> ArithmeticFunction { get; }

        public string RegisterOperand1 { get; }

        public string RegisterOperand2 { get; }

        public string RegisterResult { get; }

        public void ExecuteOnRegister(IRegister register)
        {
            int valueOperand1 = register[this.RegisterOperand1];
            int valueOperand2 = register[this.RegisterOperand2];

            register[this.RegisterResult] = this.ArithmeticFunction.Invoke(valueOperand1, valueOperand2);

            register[RegistriermachineConstants.ProgramCounterRegister] += 1;
        }
    }
}