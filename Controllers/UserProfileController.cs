using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;

namespace ValuationBackend.Controllers
{
    public class ProfilePictureUploadDto
    {
        public int UserId { get; set; }
        public IFormFile Image { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserProfileController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("upload-profile-picture")]
        public async Task<IActionResult> UploadProfilePicture([FromForm] ProfilePictureUploadDto dto)
        {
            if (dto.Image == null || dto.Image.Length == 0)
                return BadRequest("No image uploaded.");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == dto.UserId);
            if (user == null)
                return NotFound("User not found.");

            using var ms = new MemoryStream();
            await dto.Image.CopyToAsync(ms);
            user.ProfilePicture = ms.ToArray();

            await _context.SaveChangesAsync();

            return Ok("Profile picture updated.");
        }
    }
} 