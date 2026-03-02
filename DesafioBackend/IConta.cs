namespace SistemaBancario
{
   
    public interface IConta
    {
        void Sacar(double valor);
        void Depositar(double valor);
        string ExibirDados();
    }
}