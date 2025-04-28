using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RatingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitRating([FromBody] RatingRequest request)
        {
            _context.RatingRequests.Add(request);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Saved to DB", request });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.RatingRequests.ToListAsync();
            return Ok(list);
        }
    }
}