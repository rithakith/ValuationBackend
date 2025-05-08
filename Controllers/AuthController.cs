using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Data;
using ValuationBackend.Models;
using System.Security.Cryptography;
using System.Text;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

            if (!computedHash.SequenceEqual(user.PasswordHash))
                return Unauthorized(new { message = "Invalid credentials" });

            return Ok(new LoginResponse { Username = user.Username });
        }

        [HttpPost("logout")]
        public IActionResult Logout([FromBody] LogoutRequest request)
        {
            var userExists = _context.Users.Any(u => u.Username == request.Username);
            if (!userExists)
                return NotFound(new { msg = "User not found" });

            return Ok(new { msg = "success" });
        }
    }
}
