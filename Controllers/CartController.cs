using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddToCart(
        int productId,
        int quantity
    )
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if(userId is null)
        {
            return Unauthorized();
        }
        await _cartService.AddToCart(
            int.Parse(userId),
            productId,
            quantity
        );

        return Ok("Added to cart");
    }
}