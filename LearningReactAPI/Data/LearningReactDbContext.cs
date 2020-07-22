using LearningReactAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningReactAPI.Data
{
    public class LearningReactDbContext : DbContext
    {
        public LearningReactDbContext(DbContextOptions<LearningReactDbContext> options) : base(options) {   }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products);

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Brand>().ToTable("Brand");
        }
    }
}
