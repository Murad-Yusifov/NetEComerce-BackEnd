using Backend.Models;
using Microsoft.EntityFrameworkCore;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateOrder(int userId)
    {
        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Product)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null || !cart.CartItems.Any())
            return;

        var order = new Order
        {
            UserId = userId,
            Status = "Pending",
            OrderItems = cart.CartItems.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                Price = i.Product.Price
            }).ToList(),
            TotalPrice = cart.CartItems.Sum(i => i.Quantity * i.Product.Price)
        };

        _context.Orders.Add(order);

        _context.CartItems.RemoveRange(cart.CartItems);

        await _context.SaveChangesAsync();
    }
}