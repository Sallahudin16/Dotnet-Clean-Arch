using Domain.Products.ValueTypes;
using System.Runtime.Serialization;

namespace Application.Products.Queries.GetProductById
{
    [Serializable]
    public class ProductNotFound : Exception
    {
        private ProductId productId;

        public ProductNotFound(ProductId productId)
            : base($"Product with Id: {productId.value} was not found")
        {
            this.productId = productId;
        }
    }
}