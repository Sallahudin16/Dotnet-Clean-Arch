using Domain.Products.DTOs;
using Domain.Products.ValueTypes;
using MediatR;

namespace Application.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(ProductId ProductId) : IRequest<ProductDto>;
}
