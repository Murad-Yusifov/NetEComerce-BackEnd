using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Authorize(Roles ="Admin")]
[ApiController]
[Route("api/[controller]")]
public class InventoriesController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoriesController(
        IInventoryService inventoryService
    )
    {
        _inventoryService = inventoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _inventoryService.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Add(Inventory inventory)
    {
        await _inventoryService.Add(inventory);

        return Ok(inventory);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _inventoryService.Delete(id);

        return Ok("Deleted");
    }
}