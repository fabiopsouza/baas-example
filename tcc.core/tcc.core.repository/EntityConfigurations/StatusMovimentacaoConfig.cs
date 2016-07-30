using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using tcc.core.repository.Entity;

namespace tcc.core.repository.EntityConfigurations
{
    public class StatusMovimentacaoConfig : EntityTypeConfiguration<StatusMovimentacao>
    {
        public StatusMovimentacaoConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
