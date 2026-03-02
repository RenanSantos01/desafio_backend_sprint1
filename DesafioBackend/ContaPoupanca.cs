using System;

namespace SistemaBancario
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(string n, string t, double s) : base(n, t, s) { }

        
        public void AdicionarRendimento(double taxa)
        {
            if (taxa <= 0) throw new ArgumentException("A taxa deve ser positiva.");
            double rendimento = Saldo * (taxa / 100);
            Depositar(rendimento);
        }

        public override string ExibirDados() => 
            $"[Poupança] Conta: {NumeroConta} | Titular: {Titular} | Saldo: R${Saldo:F2}";
    }
}