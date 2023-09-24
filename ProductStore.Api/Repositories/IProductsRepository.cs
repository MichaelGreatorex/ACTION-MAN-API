using ProductStore.Api.Entities;

namespace ProductStore.Api.Repositories;

public interface IProductsRepository
{
    void Create(Product product);
    void Delete(int id);
    Product? Get(int id);
    IEnumerable<Product> GetAll();
    void Update(Product updatedProduct);
}
