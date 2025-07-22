using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;
using ValuationBackend.Models;
using ValuationBackend.Services;

namespace ValuationBackend.Services
{
    public class PasswordResetService
    {
        private readonly AppDbContext _context;
        private readonly IEmailSender _emailSender;

        public PasswordResetService(AppDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public async Task RequestPasswordResetAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.EmpEmail == email);
            if (user == null) return; // Don't reveal user existence

            var otp = GenerateOtp();
            var expiresAt = DateTime.UtcNow.AddMinutes(10);

            var reset = new PasswordReset
            {
                Email = email,
                Otp = otp,
                ExpiresAt = expiresAt,
                Used = false
            };
            _context.PasswordResets.Add(reset);
            await _context.SaveChangesAsync();

            var body = $"Your OTP is: {otp}\nThis OTP will expire in 10 minutes.";
            await _emailSender.SendAsync(email, "Your OTP Code", body);
        }

        public async Task<bool> VerifyOtpAsync(string email, string otp)
        {
            var reset = await _context.PasswordResets
                .Where(r => r.Email == email && !r.Used && r.ExpiresAt > DateTime.UtcNow)
                .OrderByDescending(r => r.ExpiresAt)
                .FirstOrDefaultAsync();

            if (reset == null || reset.Otp != otp) return false;
            return true;
        }

        public async Task<bool> ResetPasswordAsync(string email, string otp, string newPassword)
        {
            var reset = await _context.PasswordResets
                .Where(r => r.Email == email && !r.Used && r.ExpiresAt > DateTime.UtcNow)
                .OrderByDescending(r => r.ExpiresAt)
                .FirstOrDefaultAsync();

            if (reset == null || reset.Otp != otp) return false;

            var user = await _context.Users.FirstOrDefaultAsync(u => u.EmpEmail == email);
            if (user == null) return false;

            // Hash the password using HMACSHA512
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(newPassword));
            }

            reset.Used = true;
            await _context.SaveChangesAsync();
            return true;
        }

        private string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
} 