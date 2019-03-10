namespace Registriermachine.Compiler
{
    using System.Collections.Generic;
    using Registriermachine.ExecutableUnit;

    public interface ICompiler
    {
        IExecutableUnit Compile(List<string> codeLines);
    }
}