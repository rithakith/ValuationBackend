using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class LMPastValuation
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

        public string? FileNo_GnDivision { get; set; }
        public string? Situation { get; set; }
        public string? DateOfValuation { get; set; } // Assuming string for flexibility, can be DateTime?
        public string? PurposeOfValuation { get; set; }
        public string? PlanOfParticulars { get; set; }
        public string? Extent { get; set; }
        public string? Rate { get; set; }
        public string? RateType { get; set; }
        public string? Remarks { get; set; }
        public string? LocationLongitude { get; set; }
        public string? LocationLatitude { get; set; }
    }
}
