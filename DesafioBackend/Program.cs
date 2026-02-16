using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBancario
{
    // Classe Pai Abstrata - Requisito POO (Ação 2)
    public abstract class ContaBancaria
    {
        public string NumeroConta { get; set; }
        public string Titular { get; set; }
        public double Saldo { get; protected set; } // Encapsulamento

        public ContaBancaria(string numero, string titular, double saldoInicial)
        {
            NumeroConta = numero;
            Titular = titular;
            Saldo = saldoInicial;
        }

        public virtual void Sacar(double valor) // Polimorfismo
        {
            if (valor <= 0) throw new ArgumentException("O valor do saque deve ser positivo.");
            if (valor > Saldo) throw new InvalidOperationException("Saldo insuficiente.");
            Saldo -= valor;
        }

        public void Depositar(double valor)
        {
            if (valor <= 0) throw new ArgumentException("O valor do depósito deve ser positivo.");
            Saldo += valor;
        }

        public abstract string ExibirDados();
    }

    // Herança: Conta Corrente com taxa (Tema 1 da Aula)
    public class ContaCorrente : ContaBancaria
    {
        private const double TaxaSaque = 2.50;
        public ContaCorrente(string n, string t, double s) : base(n, t, s) { }

        public override void Sacar(double valor)
        {
            base.Sacar(valor + TaxaSaque);
        }

        public override string ExibirDados() => $"[Corrente] Conta: {NumeroConta} | Titular: {Titular} | Saldo: R${Saldo:F2}";
    }

    // Herança: Conta Poupança (Tema 1 da Aula)
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(string n, string t, double s) : base(n, t, s) { }
        public override string ExibirDados() => $"[Poupança] Conta: {NumeroConta} | Titular: {Titular} | Saldo: R${Saldo:F2}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<ContaBancaria> contas = new List<ContaBancaria>();
            bool continuar = true;

            while (continuar)
            {
                try // Tratamento de exceções (Passo 10)
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
                            Console.WriteLine("Conta Corrente criada!");
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