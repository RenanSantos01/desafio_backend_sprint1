using System;

namespace SistemaBancario
{
    public class ContaEmpresarial : ContaBancaria
    {
        public double LimiteEmprestimo { get; private set; }

        // O limite agora é fixado em 10000 no construtor
        public ContaEmpresarial(string n, string t, double s) : base(n, t, s)
        {
            LimiteEmprestimo = 10000.00;
        }

        public void RealizarEmprestimo(double valor)
        {
            if (valor <= 0) throw new ArgumentException("O valor do empréstimo deve ser positivo.");
            if (valor > LimiteEmprestimo) throw new InvalidOperationException("Valor acima do limite de R$ 10.000,00.");

            Depositar(valor);
            LimiteEmprestimo -= valor; // Opcional: subtrai o limite disponível
            Console.WriteLine($"Empréstimo de R${valor:F2} realizado com sucesso!");
        }

        public override string ExibirDados() => 
            $"[Empresarial] Conta: {NumeroConta} | Titular: {Titular} | Saldo: R${Saldo:F2} | Limite Disponível: R${LimiteEmprestimo:F2}";
    }
}