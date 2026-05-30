using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IAuthService _authService;

    public AuthController(
        AppDbContext context,
        IAuthService authService
    )
    {
        _context = context;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = "Customer"
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        var jwt = _authService.GenerateToken(user);

        return Ok(new
        {
            token = jwt
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginDto dto
    )
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(
                x => x.Email == dto.Email
            );

        if (
            user == null
            || !BCrypt.Net.BCrypt.Verify(
                dto.Password,
                user.PasswordHash
            )
        )
        {
            return Unauthorized();
        }

        var jwt = _authService.GenerateToken(user);

        return Ok(new { token = jwt });
    }
}