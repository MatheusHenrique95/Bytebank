using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Classes {
    public class Extrato {
        public Extrato(DateTime data, string descrição, double valor) {
            this.Data = data;
            this.Descrição = descrição;
            this.Valor = valor;
        }
        public DateTime Data { get; private set; }
        public string Descrição { get; private set; }
        public double Valor { get; private set; }
    }
}
