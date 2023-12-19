namespace Domain.Entities
{
    public class ShopProduct
    {
        public int Id { get; set; }
        
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        
        public int ShopId { get; set; }
        public Shop? Shop { get; set; }
        
        public Decimal? ProductPrice { get; set; }
    }
}