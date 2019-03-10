namespace Registriermachine.ExecutableUnit
{
    using Registriermachine.Register;

    public interface IExecutableUnit
    {
        IRegister Execute();
    }
}