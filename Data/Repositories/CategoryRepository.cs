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
    public class CategoryRepository : BaseEFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ExpressContext context) : base(context)
        {
        }
    }
}
