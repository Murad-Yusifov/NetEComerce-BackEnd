namespace Backend.Models;

public class Order
{
    public int Id { get; set; }

    public decimal TotalPrice { get; set; }

    public  string Status { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }

    public  User? User { get; set; }

    public ICollection<OrderItem>? OrderItems { get; set; }

    public Payment? Payment { get; set; }
}