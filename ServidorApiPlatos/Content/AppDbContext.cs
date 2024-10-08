using Microsoft.EntityFrameworkCore;
using ServidorApiPlatos.Models;

namespace ServidorApiPlatos.Content
{
    public class AppDbContext : DbContext
    {
        public DbSet<Plato> Platos => Set<Plato>();
        public AppDbContext(DbContextOptions<AppDbContext> opciones) : base(opciones)
        {

        }
    }
}
