using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Models;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var (user, token) = await _authService.LoginAsync(request.Username, request.Password);

            if (user == null || token == null)
                return Unauthorized(new { message = "Invalid credentials" });

            return Ok(new
            {
                token,
                username = user.Username,
                empName = user.EmpName,
                empEmail = user.EmpEmail,
                empId = user.EmpId,
                id = user.Id,
                position = user.Position,
                division = user.AssignedDivision
            });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            var result = await _authService.LogoutAsync(request.Username);
            if (!result)
                return NotFound(new { msg = "User not found" });

            return Ok(new { msg = "success" });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var result = await _authService.ForgotPasswordAsync(request.Username);
            if (!result)
                return NotFound(new { msg = "User not found" });

            return Ok(new { msg = "success" });
        }
    }
}
