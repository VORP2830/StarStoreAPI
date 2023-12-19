using StarStore.Application.DTOs;

namespace StarStore.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProducts(Guid id);
    Task<ProductDto> GetProductById(Guid id);
    Task<ProductDto> Create(ProductDto model);
    Task<ProductDto> Update(ProductDto model);
    Task<ProductDto> Delete(Guid id);
}
