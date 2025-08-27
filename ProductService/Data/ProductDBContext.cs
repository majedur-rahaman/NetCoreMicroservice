using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductService.Models;

namespace ProductService.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options):base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p=>p.IsActive != false);
            modelBuilder.Entity<Category>()
          .HasQueryFilter(p => p.IsActive != false);

            // one to many relationship
            //modelBuilder.Entity<Vendor>()
            //        .HasMany(p => p.Products)
            //        .WithOne(v => v.Vendor)
            //        .IsRequired();
        }
    }
}
