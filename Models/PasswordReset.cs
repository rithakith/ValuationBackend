using System;
using System.ComponentModel.DataAnnotations;

namespace ValuationBackend.Models
{
    public class PasswordReset
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Otp { get; set; }
        [Required]
        public DateTime ExpiresAt { get; set; }
        public bool Used { get; set; } = false;
    }
} 