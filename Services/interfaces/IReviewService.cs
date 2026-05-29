using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IReviewService
{
    Task<List<Review>> GetAll();

    Task Add(Review review);

    Task Delete(int id);
}