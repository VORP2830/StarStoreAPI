namespace StarStore.Application.DTOs;

public class TransactionDto
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public double TotalPay { get; set; }
    public Guid CreditCardId { get; set; }
}
