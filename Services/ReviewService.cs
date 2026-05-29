using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class ReviewService : IReviewService
{
    private readonly AppDbContext _context;

    public ReviewService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Review>> GetAll()
    {
        return await _context.Reviews.ToListAsync();
    }

    public async Task Add(Review review)
    {
        _context.Reviews.Add(review);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var review = await _context.Reviews.FindAsync(id);

        if (review == null)
            return;

        _context.Reviews.Remove(review);

        await _context.SaveChangesAsync();
    }
}