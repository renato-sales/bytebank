namespace ByteBank.entites
{
    public class Banco
    {
        public Banco()
        {
        }
        public void SaldoBanco(List<Usuario> usuarios)
        {
            double saldoTotal = 0;
            for (int i = 0; i < usuarios.Count; i++)
            {
                saldoTotal += usuarios[i].Conta.Saldo;
            }
            Console.WriteLine($"Saldo total do banco: R$ {saldoTotal:F2}");
        }
    }
}
