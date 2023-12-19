using StarStore.Application.DTOs;

namespace StarStore.Application.Interfaces;

public interface ITransactionService
{
    Task<IEnumerable<TransactionDto>> GetAllTransactions();
    Task<IEnumerable<TransactionDto>> GetTransactionsByClientId(Guid clientId);
    Task<TransactionDto> GetTransactionById(Guid id);
    Task<TransactionDto> Create(TransactionDto model);
    Task<TransactionDto> Update(TransactionDto model);
    Task<TransactionDto> Delete(Guid id);
}
