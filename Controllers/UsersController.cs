using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;
[Authorize(Roles ="Admin")]
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

        return Ok(users);
    }

    // GET: api/users/1

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetById(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    // POST: api/users

    [HttpPost]
    public async Task<IActionResult> Add(User user)
    {
        await _userService.Add(user);

        return Ok(user);
    }

    // PUT: api/users/1

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        User updatedUser
    )
    {
        var user = await _userService.GetById(id);

        if (user == null)
            return NotFound();

        await _userService.Update(id, updatedUser);

        return Ok(updatedUser);
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
}