using AutoMapper;
using StarStore.Application.DTOs;
using StarStore.Application.Interfaces;
using StarStore.Domain.Entities;
using StarStore.Domain.Exceptions;
using StarStore.Domain.Interfaces;

namespace StarStore.Application.Services;
public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProducts(Guid id)
    {
        IEnumerable<Product> products = await _unitOfWork.ProductRepository.GetAllProducts();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto> GetProductById(Guid id)
    {
        Product product = await _unitOfWork.ProductRepository.GetProductById(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> Create(ProductDto model)
    {
        Product product = _mapper.Map<Product>(model);
        _unitOfWork.ProductRepository.Add(product);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> Update(ProductDto model)
    {
        Product product = await _unitOfWork.ProductRepository.GetProductById(model.Id);
        if(product is null) throw new StarStoreException("Produto não encontrado");
        _mapper.Map(product, model);
        _unitOfWork.ProductRepository.Update(product);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> Delete(Guid id)
    {
        Product product = await _unitOfWork.ProductRepository.GetProductById(id);
        if(product is null) throw new StarStoreException("Produto não encontrado");
        product.SetActive(false);
        _unitOfWork.ProductRepository.Update(product);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ProductDto>(product);
    }
}
