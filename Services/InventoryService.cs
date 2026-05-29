using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class InventoryService : IInventoryService
{
    private readonly AppDbContext _context;

    public InventoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Inventory>> GetAll()
    {
        return await _context.Inventories.ToListAsync();
    }

    public async Task Add(Inventory inventory)
    {
        _context.Inventories.Add(inventory);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var inventory = await _context.Inventories.FindAsync(id);

        if (inventory == null)
            return;

        _context.Inventories.Remove(inventory);

        await _context.SaveChangesAsync();
    }
}