using Backend.DTOs;
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

        var result = products.Select(p => new ProductDto
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            Price = p.Price,
            Brand = p.Brand,
            CategoryId = p.CategoryId
        });
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetById(id);

        if (product == null)
            return NotFound();

        var result = new ProductDto
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            Brand = product.Brand,
            CategoryId = product.CategoryId
        };

        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add(CreateProductDto dto)
    {
        var product = new Product
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
            Brand = dto.Brand,
            CategoryId = dto.CategoryId
        };

        await _productService.Add(product);

        var result = new ProductDto
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            Brand = product.Brand,
            CategoryId = product.CategoryId
        };

        return Ok(result);
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
    UpdateProductDto dto
)
    {
        var product = await _productService.GetById(id);

        if (product == null)
            return NotFound();

        product.Title = dto.Title;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.Brand = dto.Brand;
        product.CategoryId = dto.CategoryId;

        await _productService.Update(id, product);

        var result = new ProductDto
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            Brand = product.Brand,
            CategoryId = product.CategoryId
        };

        return Ok(result);
    }
}