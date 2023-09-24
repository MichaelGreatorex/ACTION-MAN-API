using System.ComponentModel.DataAnnotations;

namespace ProductStore.Api.Entities;

public class Product
{
    public int Id { get; set; }
    
    [Required]
    public required string[] Title { get; set; }
    
    [Required]
    public required string Type { get; set; }

    [Required]
    public required string Theme { get; set; }

    [Required]
    public required string Terrain { get; set; }

    public DateOnly ReleaseDate { get; set; }

    [Required]
    public required string MainImageUri { get; set; }
    
    public string[]? AdditionalImages { get; set; }

    [Required]
    public required string[] Items { get; set; }

}



