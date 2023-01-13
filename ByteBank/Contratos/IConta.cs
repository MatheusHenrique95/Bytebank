using ByteBank.Classes;
namespace ByteBank.Contratos {
    public interface IConta {

        void Deposita(double valor);
        bool Transfere(double valor);
        void Recebe(double valor);
        bool Saca(double valor);
        double SaldoDisponível();
        string GetNumeroAgencia();
        string GetNumeroDaConta();
        string GetCodigoDoBanco();
        List<Extrato> Extrato();
    }
}
