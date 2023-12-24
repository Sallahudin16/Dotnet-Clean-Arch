using Data;
using Domain.Products.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly ExpressContext _context;

        public GetProductByIdQueryHandler(ExpressContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context
                .Products
                .Where(p => p.Id == request.ProductId)
                .Include(p => p.Brand)
                .Select(p => new ProductDto(
                    p.Id.value,
                    p.Title,
                    p.Slug.Value,
                    p.Sku.Value,
                    p.Description!,
                    p.Barcode.Value,
                    new BrandDto(
                        p.Brand.Id,
                        p.Brand.Title,
                        p.Brand.Slug,
                        p.Brand.Description!
                    )))
                .SingleOrDefaultAsync();

            if(product is null)
            {
                throw new ProductNotFound(request.ProductId);
            }

            return product;
        }
    }
}
