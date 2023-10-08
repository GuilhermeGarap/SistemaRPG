using Microsoft.EntityFrameworkCore;
using ApiRpg.Models;

namespace ApiRpg.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<Campanha> Campanhas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Ficha> Fichas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.UsuarioId);
                entity.Property(u => u.Nome).IsRequired();

                entity.HasMany(u => u.Fichas)
                    .WithOne(f => f.Usuario)
                    .HasForeignKey(f => f.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict); 
            });

        modelBuilder.Entity<Campanha>(entity =>
        {
            entity.HasKey(c => c.CampanhaId);
            entity.Property(c => c.Nome).IsRequired();

            entity
                .HasMany(c => c.Fichas)
                .WithOne(f => f.Campanha)  
                .HasForeignKey(f => f.CampanhaId); 
        });

            modelBuilder.Entity<Ficha>(entity =>
            {
                entity.HasKey(f => f.FichaId);
                entity.Property(f => f.Nome).IsRequired();

                entity.HasOne(f => f.Classe)
                    .WithMany()
                    .HasForeignKey(f => f.ClasseId)
                    .OnDelete(DeleteBehavior.Restrict); 
            });

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(c => c.ClasseId);
                entity.Property(c => c.Nome).IsRequired();
                entity.Property(c => c.AtributoBonus).IsRequired();
            });

            // Configurações adicionais, se necessário

            base.OnModelCreating(modelBuilder);
        }
    }
}