using Backend.Models;
using Microsoft.EntityFrameworkCore;

public class AddressService : IAddressService
{
    private readonly AppDbContext _context;

    public AddressService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Address>> GetAll()
    {
        return await _context.Addresses.Include(x=>x.User).ToListAsync();
    }

    public async Task Add(Address address)
    {
        _context.Addresses.Add(address);

        await _context.SaveChangesAsync();
    }
}