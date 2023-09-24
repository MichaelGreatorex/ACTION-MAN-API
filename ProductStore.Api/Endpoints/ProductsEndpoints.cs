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

        group.MapGet("/", (IProductsRepository repository) => repository.GetAll());

        group.MapGet("/{id}", (IProductsRepository repository, int id) => // READ
        {
            Product? product = repository.Get(id);
            return product is not null ? Results.Ok(product) : Results.NotFound();
        })
        .WithName(GetProductEndpointName);

        group.MapPost("/", (IProductsRepository repository, Product product) => // CREATE
        {
            repository.Create(product);
            return Results.CreatedAtRoute(GetProductEndpointName, new {id = product.Id}, product);
        });

        group.MapPut("/{id}", (IProductsRepository repository, int id, Product updatedProduct) => // UPDATE
        {
            Product? existingProduct = repository.Get(id);

            if (existingProduct is null)
            {
                return Results.NotFound();
            }

            existingProduct.Title = updatedProduct.Title;
            existingProduct.Type = updatedProduct.Type;
            existingProduct.Theme = updatedProduct.Theme;
            existingProduct.Terrain = updatedProduct.Terrain;
            existingProduct.ReleaseDate = updatedProduct.ReleaseDate;
            existingProduct.MainImageUri = updatedProduct.MainImageUri;
            existingProduct.AdditionalImages = updatedProduct.AdditionalImages;
            existingProduct.Items = updatedProduct.Items;

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