

namespace ByteBank.Classes {
    public class ContaCorrente : Conta {

        public ContaCorrente() {
            this.NumeroDaConta = $"{Conta.NumeroDaContaSequencial:D4}";
        }
    }
}