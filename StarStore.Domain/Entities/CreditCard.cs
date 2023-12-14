namespace StarStore.Domain.Entities;

public class CreditCard : BaseEntity
{
    public string CardNumber { get; protected set; }
    public string CardName { get; protected set; }
    public int CVV { get; protected set; }
    public DateOnly ExpirationDate { get; protected set; }
    public Guid ClientId { get; protected set; }
    public Client Client { get; protected set; }
    protected CreditCard() { }
}

