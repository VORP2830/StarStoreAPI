using StarStore.Domain.Entities;

namespace StarStore.Domain.Interfaces;
public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> GetProductById(Guid id);
}

