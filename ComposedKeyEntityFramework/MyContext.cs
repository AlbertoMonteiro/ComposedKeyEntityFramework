using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ComposedKeyEntityFramework
{
    public class MyContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<UnidadeNegocio> UnidadesNegocio { get; set; }
        public DbSet<ContaAReceber> ContasAReceber { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(MyContext).Assembly);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>().Configure(x => x.IsRequired());
        }
    }
}