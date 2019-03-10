namespace Registriermachine
{
    public interface IRegister
    {
        int this[string registerName] { get; set; }
    }
}