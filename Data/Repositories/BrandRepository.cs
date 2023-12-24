using Domain.Base;
using Domain.Products.Abstractions;
using Domain.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BrandRepository : BaseEFRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ExpressContext context) : base(context)
        {
        }
    }
}
