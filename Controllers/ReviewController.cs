using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reviews = await _reviewService.GetAll();

        return Ok(reviews);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add(Review review)
    {
        await _reviewService.Add(review);

        return Ok(review);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        await _reviewService.Delete(id);

        return Ok("Deleted");
    }
}