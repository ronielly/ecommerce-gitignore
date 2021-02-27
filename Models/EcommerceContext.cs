using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Ecommerce.Models
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext() : base("DefaultConnection")
        {

        }

        //DESABILITAR DELETE CASCADE
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<Ecommerce.Models.Departaments> Departaments { get; set; }

        public System.Data.Entity.DbSet<Ecommerce.Models.Cities> Cities { get; set; }
    }
}