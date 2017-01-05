using Microsoft.AspNet.Identity.EntityFramework;
using Persistance.DomainModel;
using System.Data.Entity;

namespace Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // application specific database trables
        public DbSet<ContactType> ContactTypes { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
