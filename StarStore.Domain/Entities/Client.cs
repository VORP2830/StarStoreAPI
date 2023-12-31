namespace StarStore.Domain.Entities;

public class Client : BaseEntity
{
    public string Title { get; protected set; }
    public double Price { get; protected set; }
    public string ZipCode { get; protected set; }
    public string Seller { get; protected set; }
    public string ThumbnailHd { get; protected set; }
    public IEnumerable<CreditCard> CreditCards { get; protected set; }
    public IEnumerable<Transaction> Transactions { get; protected set; }
    protected Client() { }
}