using Backend.Models;

public interface IAuthService
{
    string GenerateToken(User user);
}