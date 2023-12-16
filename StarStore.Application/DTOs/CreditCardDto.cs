namespace StarStore.Application.DTOs;

public class CreditCardDto
{
    public Guid Id { get; set; }
    public string CardNumber { get; set; }
    public string CardName { get; set; }
    public int CVV { get; set; }
    public DateOnly ExpirationDate { get; set; }
    public Guid ClientId { get; set; }
}
