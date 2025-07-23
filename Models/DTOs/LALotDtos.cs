using System.ComponentModel.DataAnnotations;

namespace ValuationBackend.Models.DTOs
{
    public class LALotCreateDto
    {
        [Required]
        public int MasterFileId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Coordinates cannot be empty")]
        public string Coordinates { get; set; } = string.Empty;
    }

    public class LALotUpdateDto
    {
        [Required]
        public int MasterFileId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Coordinates cannot be empty")]
        public string Coordinates { get; set; } = string.Empty;
    }

    public class LALotResponseDto
    {
        public int Id { get; set; }
        public int MasterFileId { get; set; }
        public string Coordinates { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        // Optional: Include MasterFile details
        public string MasterFileRefNo { get; set; } = string.Empty;
    }
}
