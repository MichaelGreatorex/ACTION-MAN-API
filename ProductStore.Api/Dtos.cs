using System.ComponentModel.DataAnnotations;

namespace ProductStore.Api.Dtos;

public record ProductDto(
    int Id,
    string[] Title,
    string Type,
    string Theme,
    string Terrain,
    DateOnly ReleaseDate,
    string MainImageUri,
    string[]? AdditionalImages,
    string[] Items
);

public record CreateProductDto(
    [Required] string[] Title,
    [Required] string Type,
    [Required] string Theme,
    [Required] string Terrain,
    DateOnly ReleaseDate,
    [Required] string MainImageUri,
    string[]? AdditionalImages,
    [Required] string[] Items
);

public record UpdateProductDto(
    [Required] string[] Title,
    [Required] string Type,
    [Required] string Theme,
    [Required] string Terrain,
    DateOnly ReleaseDate,
    [Required] string MainImageUri,
    string[]? AdditionalImages,
    [Required] string[] Items
);