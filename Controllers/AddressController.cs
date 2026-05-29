using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles ="Admin")]
[ApiController]
[Route("api/[controller]")]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressesController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _addressService.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Add(Address address)
    {
        await _addressService.Add(address);

        return Ok(address);
    }
}