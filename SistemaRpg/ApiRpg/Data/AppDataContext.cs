using Microsoft.EntityFrameworkCore;
using ApiRpg.Models;

namespace ApiTeste.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<Campanha> Campanhas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Ficha> Fichas{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campanha>(entity =>
            {
                // Config propriedades
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                // Config propriedades
            });

            modelBuilder.Entity<Classe>(entity =>
            {
                // Config propriedades
            });

            modelBuilder.Entity<Ficha>(entity =>
            {
                // Config propriedades
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
