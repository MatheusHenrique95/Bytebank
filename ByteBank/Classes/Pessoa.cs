using ByteBank.Contratos;

namespace ByteBank.Classes {
    public class Pessoa {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Senha { get; private set; }
        public IConta Conta { get; set; }

        public Pessoa(string nome, string cpf, string senha, IConta conta) {
            Nome = nome;
            CPF = cpf;
            Senha = senha;
            Conta = conta;
        }
    }
}
