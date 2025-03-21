using Microsoft.EntityFrameworkCore;
using Modelos.Entidad;

namespace Modelos.Datos
{
    public class AppDbContexts:DbContext
    {
        public AppDbContexts(DbContextOptions<AppDbContexts> options): base(options) { 
        
        
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autores> Autores { get; set; }
        
    }
}
