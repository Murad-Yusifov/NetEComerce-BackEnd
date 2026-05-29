using Backend.Models;
using Microsoft.EntityFrameworkCore;

public class CartService : ICartService
{
    private readonly AppDbContext _context;

    public CartService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddToCart(int userId, int productId, int quantity)
    {
        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            cart = new Cart { UserId = userId };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        var item = cart.CartItems
            .FirstOrDefault(x => x.ProductId == productId);

        if (item != null)
        {
            item.Quantity += quantity;
        }
        else
        {
            cart.CartItems.Add(new CartItem
            {
                ProductId = productId,
                Quantity = quantity
            });
        }

        await _context.SaveChangesAsync();
    }
}