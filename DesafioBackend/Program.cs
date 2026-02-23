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

                    string? opcao = Console.ReadLine();

                    if (opcao == "0")
                    {
                        continuar = false;
                        Console.WriteLine("Encerrando o sistema...");
                        continue;
                    }

                    switch (opcao)
                    {
                        case "1":
                            Console.Write("Nome do Titular: ");
                            string titular1 = Console.ReadLine() ?? "Titular Desconhecido";
                            string num1 = new Random().Next(1000, 9999).ToString();
                            var novaCC = new ContaCorrente(num1, titular1, 0);
                            contas.Add(novaCC);
                            Console.WriteLine("\n✅ Conta Corrente criada com sucesso!");
                            Console.WriteLine(novaCC.ExibirDados());
                            break;

                        case "2":
                            Console.Write("Nome do Titular: ");
                            string titular2 = Console.ReadLine() ?? "Titular Desconhecido";
                            string num2 = new Random().Next(1000, 9999).ToString();
                            var novaCP = new ContaPoupanca(num2, titular2, 0);
                            contas.Add(novaCP);
                            Console.WriteLine("\n✅ Conta Poupança criada com sucesso!");
                            Console.WriteLine(novaCP.ExibirDados());
                            break;

                        case "3":
                            Console.Write("Digite o número da conta para SAQUE: ");
                            string? ns = Console.ReadLine();
                            var cs = contas.FirstOrDefault(c => c.NumeroConta == ns);
                            if (cs == null) throw new Exception("Conta não encontrada.");
                            
                            Console.Write("Valor do saque: ");
                            if (double.TryParse(Console.ReadLine(), out double valS))
                            {
                                cs.Sacar(valS);
                                Console.WriteLine($"Sucesso! Novo Saldo: R${cs.Saldo:F2}");
                            }
                            else throw new Exception("Valor inválido.");
                            break;

                        case "4":
                            Console.Write("Digite o número da conta para DEPÓSITO: ");
                            string? nd = Console.ReadLine();
                            var cd = contas.FirstOrDefault(c => c.NumeroConta == nd);
                            if (cd == null) throw new Exception("Conta não encontrada.");
                            
                            Console.Write("Valor do depósito: ");
                            if (double.TryParse(Console.ReadLine(), out double valD))
                            {
                                cd.Depositar(valD);
                                Console.WriteLine($"Sucesso! Novo Saldo: R${cd.Saldo:F2}");
                            }
                            else throw new Exception("Valor inválido.");
                            break;

                        case "5":
                            Console.WriteLine("\n--- LISTA DE TODAS AS CONTAS ---");
                            if (!contas.Any()) Console.WriteLine("Nenhuma conta cadastrada.");
                            else contas.ForEach(c => Console.WriteLine(c.ExibirDados()));
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
    }
}