namespace StarStore.Domain.Interfaces;
public interface IUnitOfWork
{
    IClientRepository ClientRepository { get; }
    ICreditCardRepository CreditCardRepository { get; }
    IProductRepository ProductRepository { get; }
    ITransactionRepository TransactionRepository { get; }
    Task<bool> SaveChangesAsync();
}
