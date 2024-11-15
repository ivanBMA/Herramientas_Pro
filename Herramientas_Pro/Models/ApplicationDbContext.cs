using Microsoft.EntityFrameworkCore;

namespace Herramientas_Pro.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Arreglos> Arreglos { get; set; }
        public DbSet<Entradas_Salidas> Entradas_Salidas { get; set; }
        public DbSet<Fabricacion> Fabricacion { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Productos> Productos { get; set; }

    }
}
