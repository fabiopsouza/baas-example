using System.Linq;
using tcc.core.repository.Entity;
using tcc.core.repository.Interfaces;

namespace tcc.core.repository.Repositories
{
    public class MovimentacaoRepository : RepositoryBase<Movimentacao>, IMovimentacaoRepository
    {
        public object getCountStatusMovimentacao()
        {
            var query = "select (select count(*) from Movimentacao where StatusMovimentacaoId = 1) Pendentes, " +
                        " (select count(*) from Movimentacao where StatusMovimentacaoId = 2) Aprovados, " +
                        " (select count(*) from Movimentacao where StatusMovimentacaoId = 3) Reprovados";

            var counts = Ctx.Database.SqlQuery<CountStatusMovimentacao>(query).FirstOrDefault();
            return counts;
        }
    }
}