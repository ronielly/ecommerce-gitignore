using System.Data.Entity;

namespace Ecommerce.Models
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Ecommerce.Models.Departaments> Departaments { get; set; }

        public System.Data.Entity.DbSet<Ecommerce.Models.Cities> Cities { get; set; }
    }
}