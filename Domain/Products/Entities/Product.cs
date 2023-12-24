using Domain.Products.ValueTypes;

namespace Domain.Products.Entities
{
    public class Product
    {
        public ProductId Id { get; private set; }
        public string Title { get; private set; }
        public Sku Sku { get; private set; }
        public Slug Slug { get; private set; }
        public Barcode Barcode { get; private set; }
        public string? Description { get; private set; }
        public int BrandId { get; private set; }
        public Brand Brand { get; set; } = null!;
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<ShopProduct> ShopProducts { get; set; } = new List<ShopProduct>();

        private Product(
            ProductId id,
            string title,
            Slug slug,
            Sku sku,
            Barcode barcode,
            string? description,
            int brandId)
        {
            Id = id;
            Title = title;
            Slug = slug;
            Sku = sku;
            Description = description;
            Barcode = barcode;
            BrandId = brandId;
        }

        public static Product Create(
            string title,
            string barcode,
            string? description,
            Brand brand)
        {
            var product = new Product(
                new ProductId(Guid.NewGuid()),
                title,
                Slug.Create(title),
                Sku.Create($"{brand.BrandCode}-{barcode[^6..]}"),
                Barcode.Create(barcode), 
                description, 
                brand.Id
            );
            product.Brand = brand;

            //Any Other Creation Logic

            return product;
        }

        public void AssignBrand(Brand brand)
        {
            BrandId = brand.Id;
            Brand = brand;
        }

        public void AddCategories(List<Category> categories)
        {
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }
    }
}
