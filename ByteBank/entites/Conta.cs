namespace ByteBank.entites
{
    public class Conta
    {
        public string Agencia { get; set; }
        public int NumConta { get; set; }
        public double Saldo { get; set; }

        public Conta(string agencia, int numConta)
        {
            Agencia = agencia;
            NumConta = numConta;
        }

        public Conta()
        {
            Agencia = "0001";
            NumConta = GeradorNumConta();
            Saldo = 0;
        }
        private int GeradorNumConta()
        {
            Random ale = new Random();
            int numSorteado = ale.Next(100000, 1000000);
            return numSorteado;
        }
       
        public void ExibiContas(List<Usuario> usuarios, List<Conta> contas)
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("Não há contas cadastradas...");
            }
            else
            {
                for (int i = 0; i < usuarios.Count; i++)
                {
                    Console.WriteLine($"Nome:{usuarios[i].Nome} | Ag:{usuarios[i].Conta.Agencia} Conta:{usuarios[i].Conta.NumConta}");
                }
            }
        }
        public void QtdContas(List<Conta> contas)
        {
            Console.WriteLine($"Total de contas: {contas.Count}");
        }
    }
}
