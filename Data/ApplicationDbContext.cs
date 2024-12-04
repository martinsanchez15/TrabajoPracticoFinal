using Microsoft.EntityFrameworkCore;
using TrabajoPracticoFinal.Models;

namespace TrabajoPracticoFinal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Articulo>? Articulos { get; set; }
    }
}
