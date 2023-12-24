using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.DTOs
{
    public record ProductListDto(
        int ResultCount,
        int TotalPageCount,
        int CurrentPage,
        int PreviousPage,
        int NextPage,
        bool IsLastPage,
        List<ProductShortDto> Products
    );
}
