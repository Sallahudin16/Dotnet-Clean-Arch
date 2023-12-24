using Data.Configuration.Entities;
using Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ExpressContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }

        public ExpressContext(DbContextOptions<ExpressContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ShopProductEntityTypeConfiguration).Assembly
            );
            modelBuilder
                .Entity<Brand>()
                .HasData(
                    new Brand { Id = 1, Title="Alpha", BrandCode="ALPHA", Slug="alpha", Description="Good Local Food Brand" },
                    new Brand { Id = 2, Title="AVZ Animal Health", BrandCode="AVZ", Slug="avz-animal-health", Description="Good Russian Brand" },
                    new Brand { Id = 3, Title="Arion Food", BrandCode="ARION", Slug="arion-food", Description="Good Euro Brand" }
                );
        }
    }
}
