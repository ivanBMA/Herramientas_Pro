using Microsoft.EntityFrameworkCore;

namespace Herramientas_Pro.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Productos> Productos { get; set; }
    }
}
