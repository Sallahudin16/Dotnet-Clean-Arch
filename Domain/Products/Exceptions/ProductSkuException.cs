using Domain.Products.ValueTypes;
using System.Runtime.Serialization;

namespace Domain.Products.Exceptions
{
    [Serializable]
    internal class ProductSkuException : Exception
    {
       
        public ProductSkuException(string? message) : base(message)
        {
        }
    }
}