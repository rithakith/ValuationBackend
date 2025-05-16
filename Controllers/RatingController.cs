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

        [HttpGet("massrating")]
        public async Task<IActionResult> GetMassRatingRequests()
        {
            var massRatings = await _context.RatingRequests
                .Where(r => r.RequestType == "Mass Rating")
                .ToListAsync();

            return Ok(massRatings);
        }

        [HttpGet("ratingassessment")]
        public async Task<IActionResult> GetRatingAssessmentRequests()
        {
            var ratingAssessments = await _context.RatingRequests
                .Where(r => r.RequestType == "Rating Assessment")
                .ToListAsync();

            return Ok(ratingAssessments);
        }

        [HttpGet("ratingbuilding")]
        public async Task<IActionResult> GetRatingBuildingRequests()
        {
            var ratingBuildings = await _context.RatingRequests
                .Where(r => r.RequestType == "Rating Building")
                .ToListAsync();

            return Ok(ratingBuildings);
        }

        [HttpGet("ratingobjection")]
        public async Task<IActionResult> GetRatingObjectionRequests()
        {
            var ratingObjections = await _context.RatingRequests
                .Where(r => r.RequestType == "Rating Objection")
                .ToListAsync();

            return Ok(ratingObjections);
        }



    }
}