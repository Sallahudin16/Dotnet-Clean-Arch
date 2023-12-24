using Domain.Abstractions;
using Domain.Products.DTOs;
using Domain.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.Abstractions
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<List<ProductShortDto>> GetPaginatedResults(int CurrentPage, int ResultsPerPage);
    }
}
