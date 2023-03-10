
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Collections.Generic;

namespace ByteBank.Classes {
    public class Layout {
        public static string filename = "pessoas.json";
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int opcao = 0;
        public static void TelaPrincipal(string filename) {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();

            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                          Digite uma opção:                          ");
            Console.WriteLine("                                          ::::::::::::::::::::::::::::::::           ");
            Console.WriteLine("                                          1 - Criar conta                            ");
            Console.WriteLine("                                          ::::::::::::::::::::::::::::::::           ");
            Console.WriteLine("                                          2 - Entre com CPF e senha                  ");
            Console.WriteLine("                                          ::::::::::::::::::::::::::::::::           ");
            Console.WriteLine("                                          3 - Deletar uma conta                      ");
            Console.WriteLine("                                          ::::::::::::::::::::::::::::::::           ");
            Console.WriteLine("                                          4 - Listar todas as contas                 ");
            Console.WriteLine("                                          ::::::::::::::::::::::::::::::::           ");
            Console.WriteLine("                                          5 - Ver detalhes de uma conta              ");
            Console.WriteLine("                                          ::::::::::::::::::::::::::::::::           ");
            Console.WriteLine("                                          6 - Total armazenado no banco              ");
            Console.WriteLine("                                          ::::::::::::::::::::::::::::::::           ");
            Console.WriteLine("                                          0 - Encerrar o programa                    ");
            Console.WriteLine("                                          ::::::::::::::::::::::::::::::::           ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao) {
                case 0:
                    EncerrarPrograma();
                    break;
                case 1:
                    TelaCriarConta(filename);
                    break;
                case 2:
                    TelaLogin();
                    break;
                case 3:
                    TelaDeletarConta();
                    break;
                case 4:
                    ContasCadastradas();
                    break;
                case 5:
                    DetalhesDeUmaConta();
                    break;
                case 6:
                    TotalNoBanco();
                        break;
                default:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("                                          Opção inválida!                            ");
                    Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
                    Thread.Sleep(1000);
                    TelaPrincipal(filename);
                    break;
            }
        }
        private static void EncerrarPrograma() {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Encerrando o programa...");
            Thread.Sleep(1200);
        }
        private static void TelaCriarConta(string filename) {
            
            Console.Clear();
            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::::::          ");
            Console.WriteLine("                                          Digite seu nome e sobrenome:               ");
            string nome = Console.ReadLine();
            if (nome.Length > 3 && Regex.IsMatch(nome, "^[a-z A-Z]+$")) {
                Console.WriteLine("                                          :::::::::::::::::::::::::::::::::              ");
                Console.WriteLine("                                          Digite seu CPF (apenas números):               ");
                string cpf = Console.ReadLine();
                Pessoa pessoa1 = pessoas.FirstOrDefault(x => x.CPF == cpf);
                if (cpf.Length == 11 && Regex.IsMatch(cpf, "^[0-9]+$") && pessoa1 == null) {
                    Console.WriteLine("                                          :::::::::::::::::::::::::::::::::              ");
                    Console.WriteLine("                                          Crie uma senha(4 dígitos):                     ");
                    string senha = getPassword();
                    if (senha.Length == 4) {
                        ContaCorrente contaCorrente = new ContaCorrente(0.0);
                        Pessoa pessoa = new Pessoa(nome, cpf, senha, contaCorrente);
                        pessoas.Add(pessoa);
                        string jsonstring = JsonSerializer.Serialize(pessoas);
                        File.WriteAllText(filename, jsonstring);
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("                                          Conta cadrastrada com sucesso                 ");
                        Console.WriteLine("                                          ::::::::::::::::::::::::::::::::              ");
                        Thread.Sleep(1200);
                        TelaPrincipal(filename);
                    } else {
                        Console.Clear();

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("                                           Formato de senha inválido!                   ");
                        Console.WriteLine("                                          ::::::::::::::::::::::::::::::::              ");

                        Thread.Sleep(1200);

                        TelaPrincipal(filename);

                    }
                }else {
                    Console.Clear();

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("                                           CPF inválido ou já existente!                ");
                    Console.WriteLine("                                          ::::::::::::::::::::::::::::::::              ");

                    Thread.Sleep(1200);

                    TelaPrincipal(filename);

                }
            } else {
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                                           Formato de nome inválido!                    ");
                Console.WriteLine("                                          ::::::::::::::::::::::::::::::::              ");

                Thread.Sleep(1200);

                TelaPrincipal(filename);
            }
        }
        private static void TelaLogin() {
            Console.Clear();
            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
            Console.WriteLine("                                          Digite seu CPF:                            ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
            Console.WriteLine("                                          Digite sua senha:                          ");
            string senha = getPassword();

            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if (pessoa != null) {
                TelaBoasVindas(pessoa);
                TelaContaLogada(pessoa);

            } else {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                                          Pessoa não cadastrada                         ");
                Console.WriteLine("                                          ::::::::::::::::::::::::::::::::              ");
                Thread.Sleep(1200);
                TelaPrincipal(filename);
            }
        }
        private static void TelaDeletarConta() {
            Console.Clear();
            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                          Digite seu CPF:                            ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                                          Digite sua senha:                          ");
            string senha = getPassword();

            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);
            int index = pessoas.FindIndex(x => x.CPF == cpf);

            if (pessoa != null) {
                pessoas.RemoveAt(index);
                string jsonstring = JsonSerializer.Serialize(pessoas);
                File.WriteAllText(filename, jsonstring);
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                                          Conta deletada com sucesso                    ");
                Console.WriteLine("                                          ::::::::::::::::::::::::::::::::              ");
                Thread.Sleep(1200);
                TelaPrincipal(filename);

            } else {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                                          Pessoa não cadastrada                         ");
                Console.WriteLine("                                          ::::::::::::::::::::::::::::::::              ");
                Thread.Sleep(1200);
                TelaPrincipal(filename);
            }
        }
        private static void TotalNoBanco() {
            Console.Clear();
            double total = 0;
            foreach(Pessoa pessoa in pessoas) {
                total += pessoa.Conta.SaldoDisponível();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"                                        =======================================");
            Console.WriteLine($"                                          O banco tem um total de R${total:F2} ");
            Console.WriteLine($"                                        =======================================");
            TelaVoltarDeslogado();
        }
        private static void ContasCadastradas() {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            foreach (Pessoa pessoa in pessoas) {
                string pessoaRegistrada = $"{pessoa.Nome} | CPF: {pessoa.CPF} | Banco: {pessoa.Conta.GetCodigoDoBanco()} |" +
                $" Agencia: {pessoa.Conta.GetNumeroAgencia()} | Conta: {pessoa.Conta.GetNumeroDaConta()}";
                Console.WriteLine();
                Console.WriteLine($"                        {pessoaRegistrada}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            TelaVoltarDeslogado();
        }
        private static void DetalhesDeUmaConta() {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                              Digite o CPF da conta que deseja exibir detalhes                        ");
            Console.WriteLine("                             ::::::::::::::::::::::::::::::::::::::::::::::::::::                     ");
            string cpf = Console.ReadLine();
            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf);
            if (pessoa != null) {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"                                          Titular: {pessoa.Nome}");
                Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
                Console.WriteLine($"                                          CPF: {pessoa.CPF}");
                Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
                Console.WriteLine($"                                          Banco: {pessoa.Conta.GetCodigoDoBanco()}");
                Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
                Console.WriteLine($"                                          Agência: {pessoa.Conta.GetNumeroAgencia()}");
                Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
                Console.WriteLine($"                                          Conta: {pessoa.Conta.GetNumeroDaConta()}");
                Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
                Console.WriteLine($"                                          Saldo: R${pessoa.Conta.SaldoDisponível():F2}");
                Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
                TelaVoltarDeslogado();
            } else {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                                          Conta inexistente!                         ");
                Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
                Thread.Sleep(1000);
                TelaPrincipal(filename);
            }
        }
        private static void TelaBoasVindas(Pessoa pessoa) {
            string msgTelaBemVindo = $"{pessoa.Nome} | Banco: {pessoa.Conta.GetCodigoDoBanco()} |" +
                $" Agencia: {pessoa.Conta.GetNumeroAgencia()} | Conta: {pessoa.Conta.GetNumeroDaConta()} ";
            Console.WriteLine();
            Console.WriteLine($"                     Seja bem-vinda(o) {msgTelaBemVindo} ");
            Console.WriteLine();
        }
        private static void TelaContaLogada(Pessoa pessoa) {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                          Digite a opção desejada:                   ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
            Console.WriteLine("                                          1 - Realizar um depósito                   ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
            Console.WriteLine("                                          2 - Realizar um saque                      ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
            Console.WriteLine("                                          3 - Realizar transferência                 ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
            Console.WriteLine("                                          4 - Consultar saldo                        ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
            Console.WriteLine("                                          5 - Extrato                                ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
            Console.WriteLine("                                          6 - Sair                                   ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao) {
                case 1:
                    TelaDeposito(pessoa);
                    break;
                case 2:
                    TelaSaque(pessoa);
                    break;
                case 3:
                    TelaTransferencia(pessoa);
                    break;
                case 4:
                    TelaSaldo(pessoa);
                    break;
                case 5:
                    TelaExtrato(pessoa);
                    break;
                case 6:
                    TelaPrincipal(filename);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("                                          Opção inválida!                            ");
                    Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
                    break;
            }
        }
        private static void TelaDeposito(Pessoa pessoa) {
            Console.Clear();
            TelaBoasVindas(pessoa);
            Console.WriteLine("                                          Digite o valor do depósito:                ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
            double valor = double.Parse(Console.ReadLine());

            pessoa.Conta.Deposita(valor);
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                          Depósito realizado com sucesso                ");
            Console.WriteLine("                                          ::::::::::::::::::::::::::::::::              ");
            TelaVoltarLogado(pessoa);
        }
        private static void TelaSaque(Pessoa pessoa) {
            Console.Clear();
            TelaBoasVindas(pessoa);
            Console.WriteLine("                                          Digite o valor do Saque:                   ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("                                          Digite sua senha:                          ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
            string senha = getPassword();

            if (pessoa.Senha == senha) {
                bool OkSaque = pessoa.Conta.Saca(valor);
                Console.Clear();
                TelaBoasVindas(pessoa);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                if (OkSaque) {

                    Console.WriteLine("                                          Saque realizado com sucesso                   ");
                    Console.WriteLine("                                          ::::::::::::::::::::::::::::::::              ");
                } else {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("                                          Saldo insuficiente!                           ");
                    Console.WriteLine("                                          ::::::::::::::::::::::::::::::::              ");
                    Thread.Sleep(1200);
                    TelaContaLogada(pessoa);
                }
                TelaVoltarLogado(pessoa);
            } else {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                                           Senha incorreta, recomece o processo!                   ");
                Console.WriteLine("                                          :::::::::::::::::::::::::::::::::::::::::::              ");
                Thread.Sleep(1200);
                TelaContaLogada(pessoa);
            }
            
        }
        private static void TelaTransferencia(Pessoa pessoa) {
            Console.Clear();
            TelaBoasVindas(pessoa);
            Console.WriteLine("                                          Digite o CPF do beneficiado:               ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::::::::        ");
            string cpf = Console.ReadLine(); Pessoa pessoa2 = pessoas.FirstOrDefault(x => x.CPF == cpf);

            if (pessoa2 != null && pessoa != pessoa2) {

                Console.WriteLine("                                          Digite o valor a ser transferido:          ");
                Console.WriteLine("                                          :::::::::::::::::::::::::::::::::::        ");
                double valor = double.Parse(Console.ReadLine());
                Console.WriteLine("                                          Digite sua senha:                          ");
                Console.WriteLine("                                          :::::::::::::::::::::::::::::::::::        ");
                string senha = getPassword();
                if (pessoa.Senha == senha) {

                    bool OkTransfere = pessoa.Conta.Transfere(valor);
                    if (OkTransfere) {
                        Console.Clear();
                        pessoa2.Conta.Recebe(valor);
                        Console.WriteLine("                                           Transferencia realizada com sucesso!                 ");
                        Console.WriteLine("                                          ::::::::::::::::::::::::::::::::::::::::              ");
                        TelaVoltarLogado(pessoa);
                    }else {
                        Console.Clear();
                        Console.WriteLine("                                           Saldo insuficiente!                 ");
                        Console.WriteLine("                                          :::::::::::::::::::::::              ");
                        Thread.Sleep(1200);
                        Console.WriteLine("                                           Tente novamente!                    ");
                        Console.WriteLine("                                          :::::::::::::::::::::::              ");
                        Thread.Sleep(1200);
                        TelaTransferencia(pessoa);
                    }

                } else {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("                                           Senha incorreta, recomece o processo!                   ");
                    Console.WriteLine("                                          :::::::::::::::::::::::::::::::::::::::::::              ");
                    Thread.Sleep(1200);
                    TelaTransferencia(pessoa);
                }

            } else {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                                           Pessoa inexistente ou é você mesmo, tente outra!                 ");
                Console.WriteLine("                                          ::::::::::::::::::::::::::::::::::::::::::::::::::::              ");
                Thread.Sleep(1200);
                TelaTransferencia(pessoa);
            }


        }
        private static void TelaSaldo(Pessoa pessoa) {
            Console.Clear();
            TelaBoasVindas(pessoa);
            double saldo = pessoa.Conta.SaldoDisponível();
            Console.WriteLine($"                                          Seu saldo é: R${saldo:F2} ");
            Console.WriteLine("                                          ::::::::::::::::::::::::::::::::               ");
            TelaVoltarLogado(pessoa);
        }
        private static void TelaExtrato(Pessoa pessoa) {
            Console.Clear();
            TelaBoasVindas(pessoa);
            if (pessoa.Conta.Extrato().Any()) {

                foreach (Extrato extrato in pessoa.Conta.Extrato()) {

                    Console.WriteLine($"                                          Data: {extrato.Data.ToString("dd/MM/yyyy HH:mm:ss")}     ");
                    Console.WriteLine($"                                          Tipo da movimentação: {extrato.Descrição}                ");
                    Console.WriteLine($"                                          Valor: R${extrato.Valor:F2}                              ");
                    Console.WriteLine("                                          :::::::::::::::::::::::::::::::::::::::::                ");
                }

                double total = pessoa.Conta.Extrato().Sum(x => x.Valor);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"                                          SUB TOTAL: R${total:F2}                        ");
                Console.WriteLine("                                          ::::::::::::::::::::::::::::::::               ");
            } else {

                Console.WriteLine("                                          Não há extrato a ser exibido!                 ");
                Console.WriteLine("                                          ::::::::::::::::::::::::::::::::              ");
            }
            TelaVoltarLogado(pessoa);
        }
        private static void TelaVoltarLogado(Pessoa pessoa) {

            Console.WriteLine("                                                                                             ");
            Console.WriteLine("                                          Digite uma opção:                                  ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::::::::::              ");
            Console.WriteLine("                                          1 - Voltar para minha conta                        ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::::::::::              ");
            Console.WriteLine("                                          2 - Voltar para o menu principal                   ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::::::::::              ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1) {
                TelaContaLogada(pessoa);
            } else {
                TelaPrincipal(filename);
            }

        }
        private static void TelaVoltarDeslogado() {

            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                          Digite uma opção:                          ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::::::::        ");
            Console.WriteLine("                                          1 - Voltar para o menu principal           ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::::::::        ");
            Console.WriteLine("                                          2 - Encerrar o programa                    ");
            Console.WriteLine("                                          :::::::::::::::::::::::::::::::::::        ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1) {
                TelaPrincipal(filename);
            } else if (opcao == 2) {
                EncerrarPrograma();
            } else {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                                          Opção inválida!                            ");
                Console.WriteLine("                                          :::::::::::::::::::::::::::::              ");
                Thread.Sleep(1000);

                TelaVoltarDeslogado();
            }
        }
        public static string getPassword() {
            var pass = string.Empty;
            ConsoleKey key;
            do {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0) {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                } else if (!char.IsControl(keyInfo.KeyChar)) {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();
            return pass;
        }
        public static void LerPessoas() {

            string jsonString = File.ReadAllText(filename);
            if (!string.IsNullOrEmpty(jsonString)) {
                List<Pessoa> todasPessoas = JsonSerializer.Deserialize<List<Pessoa>>(jsonString);
                todasPessoas.ForEach(pessoa => pessoas.Add(pessoa));
            } else {
                Console.WriteLine(" ");
            }
        }
    }
}
