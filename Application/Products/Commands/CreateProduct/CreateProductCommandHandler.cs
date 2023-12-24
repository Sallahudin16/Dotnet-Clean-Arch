using Domain.Abstractions;
using Domain.Products.Abstractions;
using Domain.Products.Entities;
using MediatR;
using SharedKernel;

namespace Application.Products.Commands.CreateProduct
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(
            IBrandRepository brandRepository,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        async Task IRequestHandler<CreateProductCommand>.Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var brandId = (int)command.BrandId;
            var brand = _brandRepository.GetById(brandId);


            //Should create a product
            var product = Product.Create(
                command.Title,
                command.Barcode,
                command.Description,
                brand
            );


            if (command.Categories != null)
            {
                var categories = _categoryRepository.GetByIds(command.Categories);
                product.AddCategories(categories);
            }

            //Should Utilize if Success
            //note question: Should we return the created resource ? (REST Specs)
            _productRepository.Add(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
