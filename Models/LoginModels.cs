namespace ValuationBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }

        // Profile-related fields
        public required string EmpName { get; set; }
        public required string EmpEmail { get; set; }
        public required string EmpId { get; set; }
        public required string Position { get; set; }
        public required string AssignedDivision { get; set; }

        public byte[]? ProfilePicture { get; set; }
    }

    public class LoginRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public class LoginResponse
    {
        public required string Username { get; set; }
        public string Message { get; set; } = "Login successful";
    }

    public class ForgotPasswordRequest
    {
        public required string Username { get; set; }
    }
}
