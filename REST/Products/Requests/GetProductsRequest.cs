using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Products.Requests
{
    public record GetProductsRequest
    {
        public int ResultsPerPage { get; init; } = 10; //Default
        public int CurrentPage { get; init; } = 1; //Default
    }
}
