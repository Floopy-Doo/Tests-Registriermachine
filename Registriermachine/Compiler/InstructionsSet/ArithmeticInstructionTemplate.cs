namespace Registriermachine.Compiler.InstructionsSet
{
    using System;
    using System.Text.RegularExpressions;

    public class ArithmeticInstructionTemplate : BaseInstructionTemplate, IInstructionTemplate
    {
        private readonly Func<int, int, int> function;

        public ArithmeticInstructionTemplate(string operationSymbol, Func<int, int, int> function)
            : base(new Regex($@"^(?<registerResult>R\d+) \:\= (?<registerOperand1>R\d+) (?<operation>[{operationSymbol}]) (?<registerOperand2>R\d+)$"))
        {
            this.function = function;
        }

        public IInstruction Compile(string code)
        {
            Match match = this.CodePattern.Match(code);

            string registerResult = match.Groups["registerResult"].Value;
            string registerOperand1 = match.Groups["registerOperand1"].Value;
            string registerOperand2 = match.Groups["registerOperand2"].Value;

            return new ArithmeticInstruction(registerResult, registerOperand1, registerOperand2, this.function);
        }
    }
}