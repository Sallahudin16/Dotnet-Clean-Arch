namespace Domain.Products.DTOs
{
    public record BrandDto(
        int Id,
        string Title,
        string Slug,
        string Description
    );
}
