using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class LMSalesEvidence
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

        public string? AssetNumber { get; set; }
        public string? Road { get; set; }
        public string? Village { get; set; }
        public string? Vendor { get; set; }
        public string? DeedNumber { get; set; }
        public string? DeedAttestedNumber { get; set; }
        public string? NotaryName { get; set; }
        public string? LotNumber { get; set; }
        public string? PlanNumber { get; set; }
        public string? PlanDate { get; set; } // Assuming string for flexibility, can be DateTime?
        public string? Extent { get; set; }
        public string? Consideration { get; set; }
        public string? Remarks { get; set; }
        public string? Rate { get; set; }
        public string? RateType { get; set; }
        public string? LocationLongitude { get; set; }
        public string? LocationLatitude { get; set; }
        public string? LandRegistryReferences { get; set; }
        public string? Situation { get; set; }
        public string? DescriptionOfProperty { get; set; }

        // Foreign key to LandMiscellaneousMasterFile table
        public int? LandMiscellaneousMasterFileId { get; set; }

        [ForeignKey("LandMiscellaneousMasterFileId")]
        public virtual LandMiscellaneousMasterFile? LandMiscellaneousMasterFile { get; set; }
    }
}
