using System.Collections.Generic;

namespace tcc.core.repository.Entity
{
    public class StatusMovimentacao
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public ICollection<Movimentacao> Movimentacoes { get; set; }
        
        public StatusMovimentacao()
        {
            Movimentacoes = new List<Movimentacao>();
        }

        public StatusMovimentacao(string descricao)
        {
            Movimentacoes = new List<Movimentacao>();
            Descricao = descricao;
        }
    }
}
