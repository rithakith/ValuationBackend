using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult GetUserProfile([FromBody] UserProfileRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return Ok(new
            {
                empName = user.EmpName,
                empEmail = user.EmpEmail,
                empId = user.EmpId,
                position = user.Position,
                assignedDivision = user.AssignedDivision,
                profilePicture = user.ProfilePicture != null ? Convert.ToBase64String(user.ProfilePicture) : null
            });
        }
    }
}
