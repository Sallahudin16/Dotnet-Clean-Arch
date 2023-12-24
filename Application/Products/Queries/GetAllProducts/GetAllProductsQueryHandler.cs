using Domain.Products.Abstractions;
using Domain.Products.DTOs;
using MediatR;

namespace Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ProductListDto>
    {
        public readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductListDto> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var allCount = await _productRepository.GetCountAsync();
            var products = await _productRepository.GetPaginatedResults(
                request.CurrentPage,
                request.ResultsPerPage
                );

            var totaPageCount = (int) Math.Ceiling((Decimal)allCount / request.ResultsPerPage);
            var isLastPage = request.CurrentPage == totaPageCount;
            var previousPage = request.CurrentPage == 1 ? 1 : request.CurrentPage - 1;
            var nextPage = isLastPage ? totaPageCount : request.CurrentPage + 1;


            var result = new ProductListDto(
                products.Count,
                totaPageCount,
                request.CurrentPage,
                previousPage,
                nextPage,
                isLastPage,
                products
                );

            return result;
        }
    }
}
