using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {   
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Sku { get; set; }
        public string? Description { get; set; }
        public required string Slug { get; set; }
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
        public List<Category> Categories { get; set; }
        public List<ShopProduct> ShopProducts {  get; set; }  

        public Product()
        {
            Categories = new List<Category>();
            ShopProducts = new List<ShopProduct>();
        }

    }
}
