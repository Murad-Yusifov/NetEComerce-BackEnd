using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class ProductImageService : IProductImageService
{
    private readonly AppDbContext _context;

    public ProductImageService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductImage>> GetAll()
    {
        return await _context.ProductImages.ToListAsync();
    }

    public async Task Add(ProductImage image)
    {
        _context.ProductImages.Add(image);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var image = await _context.ProductImages.FindAsync(id);

        if (image == null)
            return;

        _context.ProductImages.Remove(image);

        await _context.SaveChangesAsync();
    }
}