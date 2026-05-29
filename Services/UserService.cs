using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAll()
    {
        return await _context.Users.Include(x=>x.Cart!).ThenInclude(x=>x.CartItems).ToListAsync();
    // .Include(x => x.Cart!)
    //     .ThenInclude(x => x.CartItems!)
    //         .ThenInclude(x => x.Product)

    // .Include(x => x.Addresses)

    // .Include(x => x.Orders)

    // .Include(x => x.Reviews)

    // .Include(x => x.Wishlists)
    }

    public async Task<User?> GetById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task Add(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, User updatedUser)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
            return;

        user.Username = updatedUser.Username;
        user.Email = updatedUser.Email;
        user.PasswordHash = updatedUser.PasswordHash;
        user.Role = updatedUser.Role;

        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
            return;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}