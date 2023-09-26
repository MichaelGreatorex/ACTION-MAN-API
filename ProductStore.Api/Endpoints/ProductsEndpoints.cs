using ProductStore.Api.Dtos;
using ProductStore.Api.Entities;
using ProductStore.Api.Repositories;

namespace ProductStore.Api.Endpoints;

public static class ProductsEndpoints
{
    const string GetProductEndpointName = "GetProduct";

    public static RouteGroupBuilder MapProductsEndpoints(this IEndpointRouteBuilder routes)
    {       
        var group = routes.MapGroup("/products")
                .WithParameterValidation();

        group.MapGet("/", (IProductsRepository repository) => 
            repository.GetAll().Select(product => product.AsDto()));

        group.MapGet("/{id}", (IProductsRepository repository, int id) => // READ
        {
            Product? product = repository.Get(id);
            return product is not null ? Results.Ok(product.AsDto()) : Results.NotFound();
        })
        .WithName(GetProductEndpointName);

        group.MapPost("/", (IProductsRepository repository, CreateProductDto productDto) => // CREATE
        {
            Product product = new()
            {
                Title = productDto.Title,
                Type = productDto.Type,
                Theme = productDto.Theme,
                Terrain = productDto.Terrain,
                ReleaseDate = productDto.ReleaseDate,
                MainImageUri = productDto.MainImageUri,
                AdditionalImages = productDto.AdditionalImages,
                Items = productDto.Items
            };
            
            repository.Create(product);
            return Results.CreatedAtRoute(GetProductEndpointName, new {id = product.Id}, product);
        });

        group.MapPut("/{id}", (IProductsRepository repository, int id, UpdateProductDto updatedProductDto) => // UPDATE
        {
            Product? existingProduct = repository.Get(id);

            if (existingProduct is null)
            {
                return Results.NotFound();
            }

            existingProduct.Title = updatedProductDto.Title;
            existingProduct.Type = updatedProductDto.Type;
            existingProduct.Theme = updatedProductDto.Theme;
            existingProduct.Terrain = updatedProductDto.Terrain;
            existingProduct.ReleaseDate = updatedProductDto.ReleaseDate;
            existingProduct.MainImageUri = updatedProductDto.MainImageUri;
            existingProduct.AdditionalImages = updatedProductDto.AdditionalImages;
            existingProduct.Items = updatedProductDto.Items;

            repository.Update(existingProduct);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (IProductsRepository repository, int id) => // DELETE
{
    Product? product = repository.Get(id);

    if (product is not null)
    {
        repository.Delete(id);
    }

    return Results.NoContent();
});

        return group;
    }
}