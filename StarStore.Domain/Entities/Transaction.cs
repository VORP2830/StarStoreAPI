namespace StarStore.Domain.Entities;

public class Transaction : BaseEntity
{
    public Guid ClientId { get; protected set; }
    public double TotalPay { get; protected set; }
    public Guid CreditCardId { get; protected set; }
    public Client Client { get; protected set; }
    public CreditCard CreditCard { get; protected set; }
    protected Transaction() { }
}