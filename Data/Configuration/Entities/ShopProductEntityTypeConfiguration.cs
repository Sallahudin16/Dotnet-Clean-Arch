using Domain.Products.Entities;
using Domain.Products.ValueTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration.Entities
{
    public class ShopProductEntityTypeConfiguration : IEntityTypeConfiguration<ShopProduct>
    {
        public void Configure(EntityTypeBuilder<ShopProduct> builder)
        {
            builder.Property(sp => sp.ProductPrice).HasPrecision(12,2);

            builder.Property(p => p.ProductId).HasConversion(
                productId => productId.value,
                value => new ProductId(value)
            );
        }
    }
}
