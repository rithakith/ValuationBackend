using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class LMBuildingRates
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

        public string? AssessmentNumber { get; set; }
        public string? Owner { get; set; }
        public string? ConstructedBy { get; set; }
        public string? YearOfConstruction { get; set; }
        public string? DescriptionOfProperty { get; set; }
        public string? FloorArea { get; set; }
        public string? RatePerSQFT { get; set; }
        public string? Cost { get; set; }
        public string? Remarks { get; set; }
        public string? LocationLatitude { get; set; }
        public string? LocationLongitude { get; set; }

        // Foreign key to LandMiscellaneousMasterFile table
        public int? LandMiscellaneousMasterFileId { get; set; }

        [ForeignKey("LandMiscellaneousMasterFileId")]
        public virtual LandMiscellaneousMasterFile? LandMiscellaneousMasterFile { get; set; }
    }
}
