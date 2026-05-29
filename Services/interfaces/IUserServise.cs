using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IUserService
{
    Task<List<User>> GetAll();
    Task<User?> GetById(int id);
    Task Add(User user);
    Task Update(int id, User user);
    Task Delete(int id);
}