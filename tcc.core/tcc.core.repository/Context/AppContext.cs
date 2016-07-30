using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using tcc.core.repository.Entity;
using tcc.core.repository.EntityConfigurations;

namespace tcc.core.repository.Context
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=TccConnectionString")
        {
        }

        public virtual DbSet<Movimentacao> Movimentacao { get; set; }
        
        public virtual DbSet<StatusMovimentacao> StatusMovimentacao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties()
                .Where(x => x.Name == x.ReflectedType.Name + "Id")
                .Configure(x => x.IsKey());

            modelBuilder.Configurations.Add(new MovimentacaoConfig());
            modelBuilder.Configurations.Add(new StatusMovimentacaoConfig());
        }
    }
}
