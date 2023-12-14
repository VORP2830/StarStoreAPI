using Microsoft.EntityFrameworkCore;
using StarStore.Domain.Entities;
using StarStore.Domain.Interfaces;
using StarStore.Infra.Data.Context;

namespace StarStore.Infra.Data.Repositories;
public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _context.Products
                                .AsNoTracking()
                                .Where(p => p.Active)
                                .ToListAsync();
    }

    public async Task<Product> GetProductById(Guid id)
    {
        return await _context.Products
                                .AsNoTracking()
                                .FirstOrDefaultAsync(p => p.Active && 
                                                            p.Id == id);
    }
}
