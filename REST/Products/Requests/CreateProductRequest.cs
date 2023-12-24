using MediatR;
using REST.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Products.Requests
{
    public sealed record CreateProductRequest(
        string Title,
        string Barcode,
        string? Description,
        int BrandId,
        int[] Categories
    );


}
