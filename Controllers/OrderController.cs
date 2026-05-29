using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [Authorize]
    [HttpPost("{userId}")]
    public async Task<IActionResult> CreateOrder(int userId)
    {
        await _orderService.CreateOrder(userId);

        return Ok("Order created");
    }
}