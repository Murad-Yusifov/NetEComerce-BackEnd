using Backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAll()
    {
        return await _context.Products
            .Include(p => p.Images)
            .ToListAsync();
    }

    public async Task<Product?> GetById(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task Add(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if(product ==null)
        throw new Exception("Didn't find the product");

        _context.Products.Remove(product);
          await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Product updatedProduct)
{
    var product = await _context.Products.FindAsync(id);

    if (product == null)
        return;

    product.Title = updatedProduct.Title;
    product.Description = updatedProduct.Description;
    product.Price = updatedProduct.Price;
    product.Brand = updatedProduct.Brand;
    product.CategoryId = updatedProduct.CategoryId;

    await _context.SaveChangesAsync();
}
}