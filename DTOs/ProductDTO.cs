namespace Backend.DTOs;

public class ProductDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Brand { get; set; } = string.Empty;

    public int CategoryId { get; set; }
}