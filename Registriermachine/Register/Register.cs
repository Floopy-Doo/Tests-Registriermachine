namespace Registriermachine.Register
{
    using System.Collections.Generic;

    public class Register : IRegister
    {
        private readonly Dictionary<string, int> valueStore = new Dictionary<string, int>();

        public int this[string registerName]
        {
            get
            {
                this.valueStore.TryGetValue(registerName, out int result);
                return result;
            }

            set
            {
                if (this.valueStore.ContainsKey(registerName))
                {
                    this.valueStore[registerName] = value;
                    return;
                }

                this.valueStore.Add(registerName, value);
            }
        }
    }
}