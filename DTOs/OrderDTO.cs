namespace Backend.DTOs;

public class OrderDto
{
    public int Id { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = string.Empty;

    public int UserId { get; set; }
}