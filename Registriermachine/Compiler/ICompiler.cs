namespace Registriermachine
{
    using System.Collections.Generic;

    public interface ICompiler
    {
        IExecutableUnit Compile(List<string> codeLines);
    }
}