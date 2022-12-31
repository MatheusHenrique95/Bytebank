using ByteBank.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Contratos {
    public interface IConta {

        void Deposita(double valor);
        bool Saca(double valor);
        double SaldoDisponível();
        string GetNumeroAgencia();
        string GetNumeroDaConta();
        string GetCodigoDoBanco();
        List<Extrato> Extrato();
    }
}
