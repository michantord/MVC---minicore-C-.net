using Microsoft.EntityFrameworkCore;
using ComisionesVentas.Models;

namespace ComisionesVentas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
    }
}
