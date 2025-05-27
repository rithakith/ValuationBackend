using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ValuationBackend.Models;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly JwtSettings _jwtSettings;

        public AuthService(IAuthRepository authRepository, IOptions<JwtSettings> jwtOptions)
        {
            _authRepository = authRepository;
            _jwtSettings = jwtOptions.Value;
        }

        public async Task<(User? user, string? token)> LoginAsync(string username, string password)
        {
            var user = await _authRepository.GetUserByUsernameAsync(username);
            if (user == null)
                return (null, null);

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            if (!computedHash.SequenceEqual(user.PasswordHash))
                return (null, null);

            var token = GenerateJwtToken(user);
            return (user, token);
        }

        public async Task<bool> LogoutAsync(string username)
        {
            var user = await _authRepository.GetUserByUsernameAsync(username);
            return user != null;
        }

        public async Task<bool> ForgotPasswordAsync(string username)
        {
            var user = await _authRepository.GetUserByUsernameAsync(username);
            if (user == null)
                return false;

            // In a real application, implement password reset logic here
            return true;
        }

        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Position),
                new Claim("EmpId", user.EmpId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
} 