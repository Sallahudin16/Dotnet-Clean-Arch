using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.DTOs
{
    public record ProductShortDto(
        Guid Id,
        string Title, 
        string Slug, 
        string Sku, 
        string? Description,
        string BrandName 
    );
}
