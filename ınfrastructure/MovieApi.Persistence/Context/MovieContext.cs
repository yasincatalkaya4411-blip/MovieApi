using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApi.domain.entities;
using MovieApi.Persistence.Identity;

namespace MovieApi.Persistence.Context
{
    public class MovieContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "server=DESKTOP-STRCHAF;initial Catalog=ApiMovieDb;integrated Security=true;TrustServerCertificate=true",
                b => b.MigrationsAssembly("MovieApi.Persistence"));
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> tags { get; set; }
        public DbSet<Cast> casts { get; set; }
        public DbSet<Series> Serieses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Identity tabloları (IdentityUserLogin vb.) için gerekli

            // Explicit primary key configuration
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Movie>().HasKey(m => m.MovieId);
            modelBuilder.Entity<Review>().HasKey(r => r.ReviewId);
            modelBuilder.Entity<Tag>().HasKey(t => t.TagId);
            modelBuilder.Entity<Cast>().HasKey(c => c.CastId);
            
            modelBuilder.Entity<Review>()
                .HasOne<AppUser>()
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}