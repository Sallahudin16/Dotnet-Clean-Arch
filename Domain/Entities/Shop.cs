namespace Domain.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Slug { get; set; }
        public string Description { get; set; }
        public Uri WebsiteURL { get; set; }
        public List<ShopProduct> ShopProducts { get; set; }

        public Shop()
        {
            ShopProducts = new List<ShopProduct>();
        }
    }
}