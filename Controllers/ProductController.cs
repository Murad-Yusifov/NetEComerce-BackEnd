using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAll();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetById(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add(Product product)
    {
        await _productService.Add(product);

        return Ok(product);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetById(id);

        if (product == null)
            return NotFound();

        await _productService.Delete(id);

        return Ok("Deleted");
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(
    int id,
    Product updatedProduct
)
    {
        var product = await _productService.GetById(id);

        if (product == null)
            return NotFound();

        await _productService.Update(id, updatedProduct);

        return Ok(updatedProduct);
    }
}