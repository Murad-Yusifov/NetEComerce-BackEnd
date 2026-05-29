using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _paymentService.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Add(Payment payment)
    {
        await _paymentService.Add(payment);

        return Ok(payment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _paymentService.Delete(id);

        return Ok("Deleted");
    }
}