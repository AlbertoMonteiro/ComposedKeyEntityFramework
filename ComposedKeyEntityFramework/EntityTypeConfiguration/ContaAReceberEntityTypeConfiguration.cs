using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ComposedKeyEntityFramework
{
    public class ContaAReceberEntityTypeConfiguration : EntityTypeConfiguration<ContaAReceber>
    {
        public ContaAReceberEntityTypeConfiguration()
        {
            HasKey(x => new { x.Id, x.EmpresaId });
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Empresa).WithMany().WillCascadeOnDelete(false);
            HasRequired(x => x.UnidadeNegocio)
                .WithMany()
                .HasForeignKey(x => new { x.UnidadeNegocioId, x.UnidadeNegocioEmpresaId })
                .WillCascadeOnDelete(false);
        }
    }
}