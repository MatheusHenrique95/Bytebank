namespace ByteBank1 {

    public class Program {

        static void ShowMenu() {
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Total armazenado no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }
        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos) {
            Console.Write("Digite seu CPF: ");
            string novoCpf=(Console.ReadLine());
            if (cpfs.Contains(novoCpf)){
                Console.WriteLine("CPF corresponde à um usuário existente");
                return;
            } else {
                cpfs.Add(novoCpf);
            }
            Console.Write("Digite seu nome: ");
            string novoTitular = (Console.ReadLine());
            if (titulares.Contains(novoTitular)){
                Console.WriteLine("Nome corresponde à um usuário existente");
                return;
            } else {
                titulares.Add(novoTitular);
            }
            Console.Write("Digite sua senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);
        }
        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos) {

            while (true) {
                Console.Write("Digite seu CPF: ");
                string checkCPF = Console.ReadLine();
                int index = cpfs.IndexOf(checkCPF);
                if (cpfs.Contains(checkCPF)) {
                    for (int i = 0; i < 3; i++) {
                        Console.Write("Digite sua senha: ");
                        string checkSenha = Console.ReadLine();
                        if (senhas.Contains(checkSenha) && cpfs.IndexOf(checkCPF) == senhas.IndexOf(checkSenha)) {
                            cpfs.Remove(cpfs[index]);
                            senhas.Remove(senhas[index]);
                            titulares.Remove(titulares[index]);
                            saldos.Remove(saldos[index]);
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("Conta removida com sucesso");
                            return;
                        } else {
                            Console.WriteLine("Senha errada ou não corresponde ao CPF digitado");
                        }
                    }
                    Console.WriteLine("Recomeçe o processo");
                } else {
                    Console.WriteLine("CPF não existe no nosso banco de dados");
                }
            }
        }
        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos) {
            for (int i = 0; i < cpfs.Count; i++) {
                Console.WriteLine($"CPF: {cpfs[i]} | Titular: {titulares[i]} | Saldo: R${saldos[i]:F2}");
            }
        }
        static void DetalhesDoUsuario(List<string> cpfs, List<double> saldos, List<string> titulares) {
            while (true) {
                Console.Write("Digite seu CPF: ");
                string checkCPF = Console.ReadLine();
                int index = cpfs.IndexOf(checkCPF);
                if (cpfs.Contains(checkCPF)) {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine($"Nome do titular da conta: {titulares[index]}");
                    Console.WriteLine();
                    Console.WriteLine($"CPF do titular da conta: {cpfs[index]}");
                    Console.WriteLine();
                    Console.WriteLine($"Saldo da conta: R${saldos[index]:F2}");
                    Console.WriteLine("--------------------------");
                    return;
                } else {
                    Console.WriteLine("CPF não existe no nosso banco de dados");
                }
            }
        }
        static void SaldoTotalDoBanco(List<double> saldos) {
            double total = 0;
            foreach (double saldo in saldos) {
                total += saldo;
            }
            Console.WriteLine($"O saldo total do banco é de R${total}");
        }
        static void ShowMenu2() {
            Console.WriteLine("1 - Realizar transferência");
            Console.WriteLine("2 - Fazer depósito");
            Console.WriteLine("3 - Sacar quantia");
            Console.WriteLine("0 - Voltar");
            Console.Write("Digite a opção desejada: ");
        }
        static void ManipularConta(List<double> saldos, List<string> titulares, List<string> senhas, List<string> cpfs) {
            int option2;
            do {
                Console.WriteLine("--------------------------");
                ShowMenu2();
                option2 = int.Parse(Console.ReadLine());

                Console.WriteLine("--------------------------");
                switch (option2) {
                    case 0:
                        Console.WriteLine("Alterações salvas");
                        break;
                    case 1:
                        RealizarTransferencia(cpfs, saldos, titulares, senhas);
                        break;
                    case 2:
                        FazerDeposito(cpfs, saldos, titulares, senhas);
                        break;
                }
            } while (option2 != 0);
        }

        static void FazerDeposito(List<string> cpfs, List<double> saldos, List<string> titulares, List<string> senhas) {
            while (true) {
                Console.Write("Confirme seu CPF: ");
                string checkCPF = Console.ReadLine();
                int index1 = cpfs.IndexOf(checkCPF);
                if (cpfs.Contains(checkCPF)) {
                    Console.Write("Digite o valor do depósito: ");
                    double deposito = double.Parse(Console.ReadLine());
                    double saldo = saldos[index1];
                    saldo = saldo + deposito;
                    Console.WriteLine($"Deposito de R${saldo:F2} realizado com sucesso");
                    return;
                } else {
                    Console.WriteLine("Algum dos CPF's não existe no nosso banco de dados");
                }

            }
        }

        static void RealizarTransferencia(List<string> cpfs, List<double> saldos, List<string> titulares, List<string> senhas) {
            while (true) {
                Console.Write("Confirme seu CPF: ");
                string checkCPF1 = Console.ReadLine();
                int index1 = cpfs.IndexOf(checkCPF1);
                Console.Write("Digite o CPF da conta à receber: ");
                string checkCPF2 = Console.ReadLine();
                int index2 = cpfs.IndexOf(checkCPF2);
                if (cpfs.Contains(checkCPF1) && cpfs.Contains(checkCPF2)) {
                    Console.Write("Digite o valor a ser tranferido: ");
                    double tranferir = double.Parse(Console.ReadLine());
                    for (int i = 0; i < 3; i++) {
                        Console.Write("Digite sua senha: ");
                        string checkSenha = Console.ReadLine();
                        if (senhas.Contains(checkSenha) && cpfs.IndexOf(checkCPF1) == senhas.IndexOf(checkSenha)) {
                            if (saldos[index1] < tranferir) {
                                Console.WriteLine("--------------------------");
                                Console.WriteLine("Saldo insuficiente");
                                return;
                            } else {
                                double Saldo1 = saldos.IndexOf(index1);
                                double Saldo2 = saldos.IndexOf(index2);
                                Saldo1 = Saldo1 - tranferir;
                                Saldo2 = Saldo2 + tranferir;
                                Console.WriteLine("Transferência realizada com sucesso");
                                Console.WriteLine($" - R${tranferir:F2} {titulares[index1]}");
                                Console.WriteLine($" + R${tranferir:F2} {titulares[index2]}");
                                return;
                            }
                        } else {
                            Console.WriteLine("Senha errada ou não corresponde ao CPF digitado");
                        }
                    }
                    Console.WriteLine("Recomeçe o processo");
                } else {
                    Console.WriteLine("Algum dos CPF's não existe no nosso banco de dados");
                }
            }
        }

        public static void Main(string[] args) {

            Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores: ");

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            int option;

            do {
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                Console.WriteLine("--------------------------");

                switch (option) {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        DetalhesDoUsuario(cpfs, saldos, titulares);
                        break;
                    case 5:
                        SaldoTotalDoBanco(saldos);
                        break;
                    case 6:
                        ManipularConta(saldos, titulares, senhas, cpfs);
                        break;
                }

                Console.WriteLine("--------------------------");

            } while (option != 0);
        }
    }
}