using Microsoft.EntityFrameworkCore;

namespace Site.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
             : base(options)
        {

        }
    }
}
