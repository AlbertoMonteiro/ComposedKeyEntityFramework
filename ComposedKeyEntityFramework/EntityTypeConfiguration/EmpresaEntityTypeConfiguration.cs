using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ComposedKeyEntityFramework
{
    public class EmpresaEntityTypeConfiguration : EntityTypeConfiguration<Empresa>
    {
        public EmpresaEntityTypeConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}