using Cafe.Data.Configurations;
using Cafe.Data.Models.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Data.Context
{
    public class MainContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}