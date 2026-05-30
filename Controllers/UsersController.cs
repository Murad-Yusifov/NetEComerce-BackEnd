using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/users

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAll();

        var result = users.Select(p => new UserDto
        {
            Id = p.Id,
            Username = p.Username,
            Email = p.Email,
            Role = p.Role,
        });

        return Ok(result);
    }

    // GET: api/users/1

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetById(id);

        if (user == null)
            return NotFound();

        var result = new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role,
        };
        return Ok(result);
    }

    // POST: api/users


    // PUT: api/users/1

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateUserDto dto
    )
    {
        var user = await _userService.GetById(id);

        if (user == null)
            return NotFound();

        user.Username = dto.Username;
        user.Email = dto.Email;
        user.Role = dto.Role;

        await _userService.Update(id, user);

        return Ok(new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role
        });
    }

    // DELETE: api/users/1

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _userService.GetById(id);

        if (user == null)
            return NotFound();

        await _userService.Delete(id);

        return Ok("User deleted");
    }




    
    // [HttpPost]
    // public async Task<IActionResult> Add(CreateUserDto dto)
    // {
    //     var user = new User
    //     {
    //         Username = dto.Username,
    //         Email = dto.Email,
    //         PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
    //         Role = dto.Role,
    //     };

    //     await _userService.Add(user);


    //     var result = new UserDto
    //     {
    //         Id = user.Id,
    //         Username = user.Username,
    //         Email = user.Email,
    //         Role = user.Role,

    //     };

    //     return Ok(result);

    // }
}