using Domain.Base;
using Domain.Products.Abstractions;
using Domain.Products.DTOs;
using Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository : BaseEFRepository<Product>, IProductRepository
    {
        public ProductRepository(ExpressContext context) : base(context)
        {
        }

        public async Task<List<ProductShortDto>> GetPaginatedResults(int CurrentPage, int ResultsPerPage)
        {
            var position = (CurrentPage - 1) * ResultsPerPage;
            return await _context
                .Products
                .Skip(position)
                .Take(ResultsPerPage)
                .Include(p => p.Brand)
                .Select(p =>  
                    new ProductShortDto(
                        p.Id.value,
                        p.Title,
                        p.Slug.Value,
                        p.Sku.Value,
                        p.Description,
                        p.Brand.Title ))
                .ToListAsync();
        }
    }
}
