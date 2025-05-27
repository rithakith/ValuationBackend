using ValuationBackend.Models;

namespace ValuationBackend.Services
{
    public interface IAuthService
    {
        Task<(User? user, string? token)> LoginAsync(string username, string password);
        Task<bool> LogoutAsync(string username);
        Task<bool> ForgotPasswordAsync(string username);
        string GenerateJwtToken(User user);
    }
} 