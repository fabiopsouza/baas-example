namespace tcc.core.repository.Entity
{
    public class Movimentacao
    {
        public int Id { get; set; }

        public string Cpf { get; set; }
        
        public string NomeTitular { get; set; }

        public string NumeroConta { get; set; }

        public double TotalCreditos { get; set; }

        public double TotalDebitos { get; set; }

        public int StatusMovimentacaoId { get; set; }

        public StatusMovimentacao StatusMovimentacao { get; set; }

        public Movimentacao()
        {

        }

        public Movimentacao(int id, string cpf, string nomeTitular, string numeroConta, double totalCreditos, double totalDebitos, int statusMovimentacaoId)
        {
            Id = id;
            Cpf = cpf;
            NomeTitular = nomeTitular;
            NumeroConta = numeroConta;
            TotalCreditos = totalCreditos;
            TotalDebitos = totalDebitos;
            StatusMovimentacaoId = statusMovimentacaoId;
        }
    }
}
