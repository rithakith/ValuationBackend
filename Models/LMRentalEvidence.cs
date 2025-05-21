using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class LMRentalEvidence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary Key

        // Foreign key to Report table
        [Required]
        public int ReportId { get; set; }

        [ForeignKey("ReportId")]
        public virtual Report Report { get; set; }

        [Required]
        public string MasterFileRefNo { get; set; }

        public string? AssessmentNo { get; set; }
        public string? Owner { get; set; }
        public string? Occupier { get; set; }
        public string? Description { get; set; }
        public string? FloorRate { get; set; } // Assuming string type as per example
        public string? RatePer { get; set; }   // Assuming string type
        public string? RatePerMonth { get; set; } // Assuming string type
        public string? LocationLongitude { get; set; } // Assuming string type
        public string? LocationLatitude { get; set; }  // Assuming string type
        public string? HeadOfTerms { get; set; }
        public string? Situation { get; set; }
        public string? Remarks { get; set; }
    }
}
