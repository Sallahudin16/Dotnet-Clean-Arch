using Domain.Products.DTOs;
using MediatR;

namespace Application.Products.Queries.GetAllProducts
{
    public sealed record GetAllProductsQuery(
        int ResultsPerPage,
        int CurrentPage
    ): IRequest<ProductListDto>;
}
