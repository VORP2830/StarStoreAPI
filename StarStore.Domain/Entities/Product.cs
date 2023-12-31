namespace StarStore.Domain.Entities;

public class Product : BaseEntity
{
    public string Title { get; protected set; }
    public double Price { get; protected set; }
    public string ZipCode { get; protected set; }
    public string Seller { get; protected set; }
    public string ThumbnailHd { get; protected set; }
    protected Product() { }
}