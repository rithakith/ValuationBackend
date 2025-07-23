using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Models;
using ValuationBackend.Services;
using System.Threading.Tasks;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly PasswordResetService _passwordResetService;

        public AuthController(IAuthService authService, PasswordResetService passwordResetService)
        {
            _authService = authService;
            _passwordResetService = passwordResetService;
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

        // --- New Password Reset Endpoints ---

        [HttpPost("request-password-reset")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] EmailDto dto)
        {
            await _passwordResetService.RequestPasswordResetAsync(dto.Email);
            return Ok(new { message = "If the email exists, an OTP has been sent." });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] OtpDto dto)
        {
            var valid = await _passwordResetService.VerifyOtpAsync(dto.Email, dto.Otp);
            if (!valid) return BadRequest(new { message = "Invalid or expired OTP." });
            return Ok(new { message = "OTP verified." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var success = await _passwordResetService.ResetPasswordAsync(dto.Email, dto.Otp, dto.NewPassword);
            if (!success) return BadRequest(new { message = "Invalid OTP or email." });
            return Ok(new { message = "Password reset successful." });
        }

        // --- DTOs for password reset ---
        public class EmailDto { public string Email { get; set; } }
        public class OtpDto { public string Email { get; set; } public string Otp { get; set; } }
        public class ResetPasswordDto { public string Email { get; set; } public string Otp { get; set; } public string NewPassword { get; set; } }
    }
}
