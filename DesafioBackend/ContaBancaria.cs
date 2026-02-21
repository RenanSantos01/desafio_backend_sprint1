using System;

namespace SistemaBancario
{
    public abstract class ContaBancaria
    {
        public string NumeroConta { get; set; }
        public string Titular { get; set; }
        public double Saldo { get; protected set; }

        public ContaBancaria(string numero, string titular, double saldoInicial)
        {
            NumeroConta = numero;
            Titular = titular;
            Saldo = saldoInicial;
        }

        public virtual void Sacar(double valor)
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
}