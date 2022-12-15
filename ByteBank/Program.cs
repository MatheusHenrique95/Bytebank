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
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite seu nome: ");
            titulares.Add(Console.ReadLine());
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
                            Console.WriteLine("Senha errada ou não conrresponde ao CPF digitado");
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
        static void ExibirSaldoUsuario(List<string> cpfs, List<double> saldos, List<string> titulares) {
            while (true) {
                Console.Write("Digite seu CPF: ");
                string checkCPF = Console.ReadLine();
                int index = cpfs.IndexOf(checkCPF);
                if (cpfs.Contains(checkCPF)) {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine($"O saldo de {titulares[index]} é de R${saldos[index]:F2}");
                    Console.WriteLine("--------------------------");
                    return;
                } else {
                    Console.WriteLine("CPF não existe no nosso banco de dados");
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
                        ExibirSaldoUsuario(cpfs, saldos, titulares);
                        break;
                }

                Console.WriteLine("--------------------------");

            } while (option != 0);
        }
    }
}