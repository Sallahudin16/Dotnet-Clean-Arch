using Domain.Products.Entities;
using Domain.Products.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.ValueTypes
{
    public record Sku
    {
        private const int MaxLenght = 20;

        private Sku(string value) => Value = value;

        public string Value { get; init; }

        public static Sku Create(string value)
        {
            //Guard
            if (string.IsNullOrEmpty(value))
                throw new ProductSkuException(
                    $"Provided SKU value is Empty"
                );

            //Create
            var sku = value;

            //Validate
            if(sku.Length > MaxLenght) 
                throw new ProductSkuException(
                    $"the SKU: {sku} exceeds the maximum lenght of {MaxLenght}characters"
                );

            return new Sku(sku);
        }
    }
}
