using GameHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameHub.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Igrica> Igrica { get; set; }
        public DbSet<Objava> Objava { get; set; }
        public DbSet<KomentarIgrica> KomentarIgrica { get; set; }
        public DbSet<KomentarObjava> KomentarObjava { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Igrica>().ToTable("Igrica");
            modelBuilder.Entity<Objava>().ToTable("Objava");
            modelBuilder.Entity<KomentarIgrica>().ToTable("KomentarIgrica");
            modelBuilder.Entity<KomentarObjava>().ToTable("KomentarObjava");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.BirthDate)
                .HasMaxLength(250);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.Opis)
                .HasMaxLength(250);

            modelBuilder.Entity<ApplicationUser>()
               .Property(e => e.Slika)
               .HasMaxLength(250);
        }
    }
}
