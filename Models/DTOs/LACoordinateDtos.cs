using System.ComponentModel.DataAnnotations;

namespace ValuationBackend.Models.DTOs
{
    // PastValuationsLA Coordinate DTOs
    public class PastValuationsLACoordinateCreateDto
    {
        [Required]
        public int MasterfileId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Coordinates cannot be empty")]
        public string Coordinates { get; set; } = string.Empty;
    }

    public class PastValuationsLACoordinateUpdateDto
    {
        [Required]
        public int MasterfileId { get; set; }

        [Required]
        public int PastValuationId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Coordinates cannot be empty")]
        public string Coordinates { get; set; } = string.Empty;
    }

    public class PastValuationsLACoordinateResponseDto
    {
        public int Id { get; set; }
        public int MasterfileId { get; set; }
        public int PastValuationId { get; set; }
        public string Coordinates { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    // BuildingRatesLA Coordinate DTOs
    public class BuildingRatesLACoordinateCreateDto
    {
        [Required]
        public int MasterfileId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Coordinates cannot be empty")]
        public string Coordinates { get; set; } = string.Empty;
    }

    public class BuildingRatesLACoordinateUpdateDto
    {
        [Required]
        public int MasterfileId { get; set; }

        [Required]
        public int BuildingRateId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Coordinates cannot be empty")]
        public string Coordinates { get; set; } = string.Empty;
    }

    public class BuildingRatesLACoordinateResponseDto
    {
        public int Id { get; set; }
        public int MasterfileId { get; set; }
        public int BuildingRateId { get; set; }
        public string Coordinates { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    // SalesEvidenceLA Coordinate DTOs
    public class SalesEvidenceLACoordinateCreateDto
    {
        [Required]
        public int MasterfileId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Coordinates cannot be empty")]
        public string Coordinates { get; set; } = string.Empty;
    }

    public class SalesEvidenceLACoordinateUpdateDto
    {
        [Required]
        public int MasterfileId { get; set; }

        [Required]
        public int SalesEvidenceId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Coordinates cannot be empty")]
        public string Coordinates { get; set; } = string.Empty;
    }

    public class SalesEvidenceLACoordinateResponseDto
    {
        public int Id { get; set; }
        public int MasterfileId { get; set; }
        public int SalesEvidenceId { get; set; }
        public string Coordinates { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    // RentalEvidenceLA Coordinate DTOs
    public class RentalEvidenceLACoordinateCreateDto
    {
        [Required]
        public int MasterfileId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Coordinates cannot be empty")]
        public string Coordinates { get; set; } = string.Empty;
    }

    public class RentalEvidenceLACoordinateUpdateDto
    {
        [Required]
        public int MasterfileId { get; set; }

        [Required]
        public int RentalEvidenceId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Coordinates cannot be empty")]
        public string Coordinates { get; set; } = string.Empty;
    }

    public class RentalEvidenceLACoordinateResponseDto
    {
        public int Id { get; set; }
        public int MasterfileId { get; set; }
        public int RentalEvidenceId { get; set; }
        public string Coordinates { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
