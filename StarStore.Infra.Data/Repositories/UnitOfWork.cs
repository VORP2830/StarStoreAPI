using StarStore.Domain.Interfaces;
using StarStore.Infra.Data.Context;

namespace StarStore.Infra.Data.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    public IClientRepository ClientRepository => throw new NotImplementedException();

    public ICreditCardRepository CreditCardRepository => throw new NotImplementedException();

    public IProductRepository ProductRepository => throw new NotImplementedException();

    public ITransactionRepository TransactionRepository => throw new NotImplementedException();

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }
}
