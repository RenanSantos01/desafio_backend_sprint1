using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBancario
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ContaBancaria> contas = new List<ContaBancaria>();
            bool continuar = true;

            while (continuar)
            {
                try
                {
                    Console.WriteLine("\n--- SISTEMA BANCÁRIO ---");
                    Console.WriteLine("1. Criar Conta Corrente");
                    Console.WriteLine("2. Criar Conta Poupança");
                    Console.WriteLine("3. Criar Conta Empresarial");
                    Console.WriteLine("4. Sacar");
                    Console.WriteLine("5. Depositar");
                    Console.WriteLine("6. Listar Contas");
                    Console.WriteLine("7. Aplicar Rendimento (Poupança)");
                    Console.WriteLine("8. Realizar Empréstimo (Empresarial)");
                    Console.WriteLine("0. Sair");
                    Console.Write("Opção: ");

                    string? opcao = Console.ReadLine();
                    if (opcao == "0") { continuar = false; continue; }

                    switch (opcao)
                    {
                        case "1":
                            Console.Write("Titular Corrente: ");
                            var c1 = new ContaCorrente(GerarNumero(), Console.ReadLine() ?? "Titular", 0);
                            contas.Add(c1);
                            Console.WriteLine("✅ " + c1.ExibirDados());
                            break;

                        case "2":
                            Console.Write("Titular Poupança: ");
                            var c2 = new ContaPoupanca(GerarNumero(), Console.ReadLine() ?? "Titular", 0);
                            contas.Add(c2);
                            Console.WriteLine("✅ " + c2.ExibirDados());
                            break;

                        case "3":
                            Console.Write("Titular Empresa: ");
                            // Agora não pede mais o limite, pois é fixo em 10.000
                            var c3 = new ContaEmpresarial(GerarNumero(), Console.ReadLine() ?? "Empresa", 0);
                            contas.Add(c3);
                            Console.WriteLine("✅ " + c3.ExibirDados());
                            break;

                        case "4":
                            Console.Write("Número da conta: ");
                            string? ns = Console.ReadLine();
                            var contaS = contas.FirstOrDefault(c => c.NumeroConta == ns);
                            if (contaS == null) throw new Exception("Conta não encontrada.");
                            Console.Write("Valor: ");
                            contaS.Sacar(double.Parse(Console.ReadLine() ?? "0"));
                            Console.WriteLine("✅ Sucesso!");
                            break;

                        case "5":
                            Console.Write("Número da conta: ");
                            string? nd = Console.ReadLine();
                            var contaD = contas.FirstOrDefault(c => c.NumeroConta == nd);
                            if (contaD == null) throw new Exception("Conta não encontrada.");
                            Console.Write("Valor: ");
                            contaD.Depositar(double.Parse(Console.ReadLine() ?? "0"));
                            Console.WriteLine("✅ Sucesso!");
                            break;

                        case "6":
                            contas.ForEach(c => Console.WriteLine(c.ExibirDados()));
                            break;

                        case "7":
                            Console.Write("Número Poupança: ");
                            string? nr = Console.ReadLine();
                            var cp = contas.OfType<ContaPoupanca>().FirstOrDefault(c => c.NumeroConta == nr);
                            if (cp == null) throw new Exception("Poupança não encontrada.");
                            Console.Write("Taxa %: ");
                            cp.AdicionarRendimento(double.Parse(Console.ReadLine() ?? "0"));
                            Console.WriteLine("✅ Rendimento aplicado!");
                            break;

                        case "8":
                            Console.Write("Número Empresarial: ");
                            string? ne = Console.ReadLine();
                            var ce = contas.OfType<ContaEmpresarial>().FirstOrDefault(c => c.NumeroConta == ne);
                            if (ce == null) throw new Exception("Conta Empresarial não encontrada.");
                            Console.Write("Valor Empréstimo: ");
                            ce.RealizarEmprestimo(double.Parse(Console.ReadLine() ?? "0"));
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n ERRO: {ex.Message}");
                }
            }
        }

        static string GerarNumero() => new Random().Next(1000, 9999).ToString();
    }
}