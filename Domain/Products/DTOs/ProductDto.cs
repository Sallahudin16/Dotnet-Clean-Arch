namespace Domain.Products.DTOs
{
    public record ProductDto(
        Guid Id,
        string Title,
        string Slug,
        string Sku,
        string Description,
        string Barcode,
        BrandDto? Brand
    );
}
