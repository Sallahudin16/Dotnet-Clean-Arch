
using MediatR;

namespace Application.Products.Commands.CreateProduct
{
    public sealed record CreateProductCommand(
        string Title,
        string Barcode,
        int BrandId,
        string? Description,
        int[]? Categories
    ) : IRequest;
}
