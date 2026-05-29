using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductImagesController : ControllerBase
{
    private readonly IProductImageService _imageService;

    public ProductImagesController(
        IProductImageService imageService
    )
    {
        _imageService = imageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _imageService.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductImage image)
    {
        await _imageService.Add(image);

        return Ok(image);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _imageService.Delete(id);

        return Ok("Deleted");
    }
}