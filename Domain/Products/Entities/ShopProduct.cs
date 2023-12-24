using Domain.Products.ValueTypes;

namespace Domain.Products.Entities
{
    public class ShopProduct
    {
        public int Id { get; set; }

        public ProductId ProductId { get; set; } = null!;
        public Product? Product { get; set; } = null!;

        public int ShopId { get; set; }
        public Shop? Shop { get; set; } = null!;

        public decimal? ProductPrice { get; set; }
    }
}