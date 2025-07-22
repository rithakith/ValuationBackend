using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class PastValuationsLACoordinate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary Key (auto increment)

        // Foreign key to PastValuationsLA table via ReportId
        [Required]
        public int ReportId { get; set; }

        [ForeignKey("ReportId")]
        public virtual Report Report { get; set; }

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

        // Foreign key to BuildingRatesLA table via ReportId
        [Required]
        public int ReportId { get; set; }

        [ForeignKey("ReportId")]
        public virtual Report Report { get; set; }

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

        // Foreign key to SalesEvidenceLA table via ReportId
        [Required]
        public int ReportId { get; set; }

        [ForeignKey("ReportId")]
        public virtual Report Report { get; set; }

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

        // Foreign key to RentalEvidenceLA table via ReportId
        [Required]
        public int ReportId { get; set; }

        [ForeignKey("ReportId")]
        public virtual Report Report { get; set; }

        // Map coordinates from frontend (stored as JSON string)
        [Required]
        public string Coordinates { get; set; } = string.Empty;

        // Optional: Additional metadata
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
