using ProductStore.Api.Entities;

namespace ProductStore.Api.Repositories;

public class InMemProductsRepository : IProductsRepository
{
    private readonly List<Product> products = new()
    {
        new Product()
        {
            Id = 1,
            Title = new[] {"Snowboard Raider"},
            Type = "Figure Set",
            Theme = "Sport",
            Terrain = "Arctic",
            ReleaseDate = new DateOnly(1996, 01, 01),
            MainImageUri = "https://placehold.co/200",
            AdditionalImages = new[] {"https:placehold.co/100"},
            Items = new[] {"Figure", "Helmet", "Jacket", "Trousers", "Snowboots", "Rifle", "Roaring Saw"}
        },

        new Product()
        {
            Id = 2,
            Title = new[] {"Stealth Jet", "Action Jet"},
            Type = "Vehicle Set",
            Theme = "Mission",
            Terrain = "Air",
            ReleaseDate = new DateOnly(1996, 01, 01),
            MainImageUri = "https://placehold.co/200",
            AdditionalImages = new[] {"https:placehold.co/100"},
            Items = new[] {"Jet", "Bike"}
        },

        new Product()
        {
            Id = 3,
            Title = new[] {"Adventure Kit", "Equipo De Adventura"},
            Type = "Accessory Set",
            Theme = "Adventure",
            Terrain = "Mountain",
            ReleaseDate = new DateOnly(1994, 01, 01),
            MainImageUri = "https://placehold.co/200",
            AdditionalImages = new[] {"https:placehold.co/100"},
            Items = new[] {"knife", "Fork", "Spoon", "Water Bottle", "Hand Gun", "Dynamite", "Wrist Watch", "Wide Lens Camera", "Detonator"}
        },
    };

    public IEnumerable<Product> GetAll()
    {
        return products;
    }

    public Product? Get(int id)
    {
        return products.Find(product => product.Id == id);
    }

    public void Create(Product product)
    {
        product.Id = products.Max(product => product.Id) + 1;
        products.Add(product);
    }

    public void Update(Product updatedProduct)
    {
        var index = products.FindIndex(product => product.Id == updatedProduct.Id);
        products[index] = updatedProduct;
    }

    public void Delete(int id)
    {
        var index = products.FindIndex(product => product.Id == id);
        products.RemoveAt(index);
    }
}