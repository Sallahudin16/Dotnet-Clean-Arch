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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasConversion(
                productId => productId.value,
                value => new ProductId(value)
            );

            builder.Property(p => p.Sku).HasConversion(
                sku => sku.Value,
                value => Sku.Create(value)
            );
            builder.Property(p => p.Slug).HasConversion(
                slug => slug.Value,
                value => Slug.Create(value)
            );
            builder.Property(p => p.Barcode).HasConversion(
                barcode => barcode.Value,
                value => Barcode.Create(value)
            );


        }
    }
}
