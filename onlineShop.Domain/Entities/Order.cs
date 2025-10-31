namespace onlineShop.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public decimal TotalPrice { get; set; }


    public ICollection<Product> Products { get; set; } = new List<Product>();
}
