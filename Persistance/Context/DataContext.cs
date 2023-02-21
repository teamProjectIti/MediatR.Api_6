using Domain.Entity.Active;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {

        }


      public  DbSet<Activity> activities { get; set; }
    }
}
