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

            var body = $@"<html>
<head>
  <meta charset='UTF-8'>
  <title>Password Reset OTP</title>
</head>
<body style='background:#F5DDB3;padding:0;margin:0;font-family:sans-serif;'>
  <div style='max-width:480px;margin:40px auto;background:#fff;border-radius:12px;box-shadow:0 2px 8px #0001;padding:32px 24px;'>
    <div style='text-align:center;'>
      <h2 style='color:#041B4D;margin-bottom:8px;'>Password Reset Request</h2>
      <p style='color:#6D7986;font-size:16px;margin-bottom:24px;'>We received a request to reset your password for your Valuation Department account.</p>
      <div style='background:#F5DDB3;border-radius:8px;padding:24px 0;margin-bottom:24px;'>
        <span style='color:#8B4219;font-size:15px;'>Your One-Time Password (OTP):</span><br>
        <span style='display:inline-block;font-size:32px;letter-spacing:8px;color:#041B4D;font-weight:bold;margin-top:8px;margin-bottom:8px;'>{otp}</span>
        <div style='color:#818180;font-size:13px;'>This OTP will expire in 10 minutes.</div>
      </div>
      <a href='#' style='display:inline-block;background:#DA8F3E;color:#fff;text-decoration:none;padding:12px 32px;border-radius:6px;font-size:16px;font-weight:600;margin-bottom:24px;'>Reset Password</a>
      <p style='color:#6D7986;font-size:14px;margin-top:32px;'>If you did not request a password reset, you can safely ignore this email. Someone else might have typed your email address by mistake.</p>
      <hr style='border:none;border-top:1px solid #E9E9E9;margin:32px 0;'>
      <div style='color:#C6CFD7;font-size:12px;'>Valuation Department &bull; This is an automated message, please do not reply.</div>
    </div>
  </div>
</body>
</html>";
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