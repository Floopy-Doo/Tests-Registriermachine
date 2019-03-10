namespace Registriermachine.Register
{
    public interface IRegister
    {
        int this[string registerName] { get; set; }
    }
}