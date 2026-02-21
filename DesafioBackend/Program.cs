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
                    Console.WriteLine("3. Sacar");
                    Console.WriteLine("4. Depositar");
                    Console.WriteLine("5. Listar Contas");
                    Console.WriteLine("0. Sair");
                    Console.Write("Opção: ");

                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            Console.Write("Nome do Titular: ");
                            string t1 = Console.ReadLine();
                            contas.Add(new ContaCorrente(new Random().Next(1000, 9999).ToString(), t1, 0)); 
                            Console.WriteLine("Conta Corrente criada com R$ 500,00!");
                            break;
                        case "2":
                            Console.Write("Nome do Titular: ");
                            string t2 = Console.ReadLine();
                            contas.Add(new ContaPoupanca(new Random().Next(1000, 9999).ToString(), t2, 0));
                            Console.WriteLine("Conta Poupança criada!");
                            break;
                        case "3":
                            Console.Write("Número da conta: ");
                            string ns = Console.ReadLine();
                            var cs = contas.FirstOrDefault(c => c.NumeroConta == ns);
                            if (cs == null) throw new Exception("Conta não encontrada.");
                            Console.Write("Valor do saque: ");
                            cs.Sacar(double.Parse(Console.ReadLine()));
                            Console.WriteLine("Sucesso!");
                            break;
                        case "4":
                            Console.Write("Número da conta: ");
                            string nd = Console.ReadLine();
                            var cd = contas.FirstOrDefault(c => c.NumeroConta == nd);
                            if (cd == null) throw new Exception("Conta não encontrada.");
                            Console.Write("Valor do depósito: ");
                            cd.Depositar(double.Parse(Console.ReadLine()));
                            Console.WriteLine("Sucesso!");
                            break;
                        case "5":
                            contas.ForEach(c => Console.WriteLine(c.ExibirDados()));
                            break;
                        case "0":
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO: {ex.Message}");
                }
            }
        }
    }
}