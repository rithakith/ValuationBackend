using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class RentalEvidenceLA
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
        
        public string? AssessmentNo { get; set; }
        
        [Required]
        public string MasterFileRefNo { get; set; } = string.Empty;
        
        public string? Owner { get; set; }
        
        public string? Occupier { get; set; }
        
        public string? Description { get; set; }
        
        public string? FloorRateSQFT { get; set; }
        
        public string? RatePerSqft { get; set; }
        
        public string? RatePerMonth { get; set; }
        
        public string? LocationLongitude { get; set; }
        
        public string? LocationLatitude { get; set; }
        
        public string? HeadOfTerms { get; set; }
        
        public string? Situation { get; set; }
        
        public string? Remarks { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
    }
}