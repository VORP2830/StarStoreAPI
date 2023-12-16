namespace StarStore.Application.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string ZipCode { get; set; }
    public string Seller { get; set; }
    public string ThumbnailHd { get; set; }
}
