using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using tcc.core.repository.Entity;

namespace tcc.core.repository.EntityConfigurations
{
    public class MovimentacaoConfig : EntityTypeConfiguration<Movimentacao>
    {
        public MovimentacaoConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Cpf)
                .IsRequired()
                .HasMaxLength(15);

            Property(x => x.NomeTitular)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
