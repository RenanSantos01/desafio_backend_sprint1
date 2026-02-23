namespace SistemaBancario
{
    public class ContaCorrente : ContaBancaria
    {
        private const double TaxaSaque = 2.50;

        public ContaCorrente(string n, string t, double s) : base(n, t, s) { }

        public override void Sacar(double valor)
        {
            
            base.Sacar(valor + TaxaSaque);
        }

        public override string ExibirDados() => 
            $"[Corrente] Conta: {NumeroConta} | Titular: {Titular} | Saldo: R${Saldo:F2}";
    }
}