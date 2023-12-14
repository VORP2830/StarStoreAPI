using StarStore.Domain.Entities;

namespace StarStore.Domain.Interfaces;
public interface ITransactionRepository : IGenericRepository<Transaction>
{
    Task<IEnumerable<Transaction>> GetAllTransactions();
    Task<Transaction> GetTransactionById(Guid id);
    Task<IEnumerable<Transaction>> GetTransactionsByClientId(Guid clientId);
}
