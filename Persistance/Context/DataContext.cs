using Domain.Entity.Active;
using Domain.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context
{
    public class DataContext:IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options):base(options)
        {
        }
      public  DbSet<Activity> activities { get; set; }
    }
}
