using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class PastValuationsLACoordinate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary Key (auto increment)

        // Foreign key to PastValuationsLA table
        [Required]
        public int PastValuationId { get; set; }

        [ForeignKey("PastValuationId")]
        public virtual PastValuationsLA? PastValuation { get; set; }

        // Map coordinates from frontend (stored as JSON string)
        [Required]
        public string Coordinates { get; set; } = string.Empty;

        // Optional: Additional metadata
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

    public class BuildingRatesLACoordinate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary Key (auto increment)

        // Foreign key to BuildingRatesLA table
        [Required]
        public int BuildingRateId { get; set; }

        [ForeignKey("BuildingRateId")]
        public virtual BuildingRatesLA? BuildingRate { get; set; }

        // Map coordinates from frontend (stored as JSON string)
        [Required]
        public string Coordinates { get; set; } = string.Empty;

        // Optional: Additional metadata
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

    public class SalesEvidenceLACoordinate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary Key (auto increment)

        // Foreign key to SalesEvidenceLA table
        [Required]
        public int SalesEvidenceId { get; set; }

        [ForeignKey("SalesEvidenceId")]
        public virtual SalesEvidenceLA? SalesEvidence { get; set; }

        // Map coordinates from frontend (stored as JSON string)
        [Required]
        public string Coordinates { get; set; } = string.Empty;

        // Optional: Additional metadata
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

    public class RentalEvidenceLACoordinate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary Key (auto increment)

        // Foreign key to RentalEvidenceLA table
        [Required]
        public int RentalEvidenceId { get; set; }

        [ForeignKey("RentalEvidenceId")]
        public virtual RentalEvidenceLA? RentalEvidence { get; set; }

        // Map coordinates from frontend (stored as JSON string)
        [Required]
        public string Coordinates { get; set; } = string.Empty;

        // Optional: Additional metadata
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
