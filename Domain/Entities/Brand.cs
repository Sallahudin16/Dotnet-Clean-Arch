namespace Domain.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Slug { get; set; }
        public string? Description { get; set; }
        public List<Product> Products { get; set; }
        public Brand()
        {
            Products = new List<Product>();
        }

    }
}