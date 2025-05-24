using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using practica3.Models;

namespace practica3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FeedbackModelo> Feedbacks { get; set; }

    
        public DbSet<PublicacionVistaModelo> Publicaciones { get; set; }
        public DbSet<ComentarioVistaModelo> Comentarios { get; set; }
        public DbSet<AutorVistaModelo> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Puedes agregar configuraciones adicionales aquí si usas Fluent API
        }
    }
}
