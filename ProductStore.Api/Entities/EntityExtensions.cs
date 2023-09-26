using ProductStore.Api.Dtos;

namespace ProductStore.Api.Entities;

public static class EntityExtensions
{
    public static ProductDto AsDto(this Product product)
    {
        return new ProductDto(
            product.Id,
            product.Title,
            product.Type,
            product.Theme,
            product.Terrain,
            product.ReleaseDate,
            product.MainImageUri,
            product.AdditionalImages,
            product.Items
        );
    }
}