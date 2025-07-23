using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class SalesEvidenceLA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public int ReportId { get; set; }
        
        [ForeignKey("ReportId")]
        public Report? Report { get; set; }
        
        [Required]
        public int MasterFileId { get; set; }
        
        [ForeignKey("MasterFileId")]
        public LandAquisitionMasterFile? MasterFile { get; set; }
        
        [Required]
        public string MasterFileRefNo { get; set; } = string.Empty;

        public string? AssetNumber { get; set; }
        
        public string? Road { get; set; }
        
        public string? Village { get; set; }
        
        public string? Owner { get; set; }
        
        public string? Occupier { get; set; }
        
        public string? Vendor { get; set; }
        
        public string? DeedNumber { get; set; }
        
        public string? Description { get; set; }
        
        public string? FloorRate { get; set; }
        
        public string? DeedAttestedNumber { get; set; }
        
        public string? NotaryName { get; set; }
        
        public string? LotNumber { get; set; }
        
        public string? PlanNumber { get; set; }
        
        public string? PlanDate { get; set; }
        
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
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
    }
}