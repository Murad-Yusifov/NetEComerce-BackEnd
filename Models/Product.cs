namespace Backend.Models;

public class Product
{
    public int Id { get; set; }

    public  string Title { get; set; }

    public  string Description { get; set; }

    public decimal Price { get; set; }

    public  string Brand { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int CategoryId { get; set; }

    public  Category? Category { get; set; }

    public  ICollection<ProductImage>? Images { get; set; }

    public  ICollection<Review>? Reviews { get; set; }

    public  ICollection<CartItem>? CartItems { get; set; }

    public  ICollection<OrderItem>? OrderItems { get; set; }

    public  Inventory? Inventory { get; set; }
}