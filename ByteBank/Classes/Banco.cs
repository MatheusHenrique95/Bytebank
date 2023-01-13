

namespace ByteBank.Classes {
    public abstract class Banco {

        public Banco() {
            this.CoodigoDoBanco = "079";
            this.NomeDoBanco = "ByteBank";

        }
        public string NomeDoBanco { get; private set; }
        public string CoodigoDoBanco { get; private set; }
    }
}
