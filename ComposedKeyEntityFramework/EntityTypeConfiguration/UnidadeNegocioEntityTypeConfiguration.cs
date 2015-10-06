using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ComposedKeyEntityFramework
{
    public class UnidadeNegocioEntityTypeConfiguration : EntityTypeConfiguration<UnidadeNegocio>
    {
        public UnidadeNegocioEntityTypeConfiguration()
        {
            HasKey(x => new { x.Id, x.EmpresaId });
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Empresa).WithMany().WillCascadeOnDelete(false);
        }
    }
}