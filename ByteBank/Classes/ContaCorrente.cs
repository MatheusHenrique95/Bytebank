

namespace ByteBank.Classes {
    public class ContaCorrente : Conta {

        public ContaCorrente(double saldo): base(saldo) {

            this.NumeroDaConta = $"{Conta.NumeroDaContaSequencial:D4}";
        }
    }
}