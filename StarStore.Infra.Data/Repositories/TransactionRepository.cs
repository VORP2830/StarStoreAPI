using Microsoft.EntityFrameworkCore;
using StarStore.Domain.Entities;
using StarStore.Domain.Interfaces;
using StarStore.Infra.Data.Context;

namespace StarStore.Infra.Data.Repositories;

public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
{
    private readonly ApplicationDbContext _context;
    public TransactionRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Transaction>> GetAllTransactions()
    {
        return await _context.Transactions
                                .AsNoTracking()
                                .Where(t => t.Active)
                                .ToListAsync();
    }

    public async Task<Transaction> GetTransactionById(Guid id)
    {
        return await _context.Transactions
                                .AsNoTracking()
                                .FirstOrDefaultAsync(t => t.Active && 
                                                            t.Id == id);
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsByClientId(Guid clientId)
    {
        return await _context.Transactions
                                .AsNoTracking()
                                .Where(t => t.Active && 
                                            t.ClientId == clientId)
                                .ToListAsync();
    }
}
