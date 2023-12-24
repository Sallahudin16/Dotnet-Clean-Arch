using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetAllProducts;
using Application.Products.Queries.GetProductById;
using Asp.Versioning;
using Domain.Products.ValueTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using REST.Abstractions;
using REST.Products.Requests;

namespace REST.Products.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController : ApiController
    {
        public ProductsController(ISender sender) : base(sender)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var categories = request.Categories.Length == 0 ? null : request.Categories;

            var command = new CreateProductCommand(
                request.Title,
                request.Barcode,
                request.BrandId,
                request.Description,
                categories
            );

            await _Sender.Send(command, cancellationToken);

            return Created();
        }

        [HttpGet]
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var query = new GetProductByIdQuery(
                    new ProductId(Id)
                );
            var product = await _Sender.Send(query);
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(int Page = 1, int ResultsPerPage = 10)
        {
            var query = new GetAllProductsQuery(
                ResultsPerPage,
                Page
                );
            var products = await _Sender.Send(query);
            return Ok(products);
        }
    }
}
