namespace SistemaBancario
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(string n, string t, double s) : base(n, t, s) { }

        public override string ExibirDados() => 
            $"[Poupança] Conta: {NumeroConta} | Titular: {Titular} | Saldo: R${Saldo:F2}";
    }
}