using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class PastValuationsLA
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
        
        public string? FileNoGNDivision { get; set; }
        
        public string? Situation { get; set; }
        
        public string? DateOfValuation { get; set; }
        
        public string? PurposeOfValuation { get; set; }
        
        public string? PlanOfParticulars { get; set; }
        
        public string? Extent { get; set; }
        
        public string? Rate { get; set; }
        
        public string? RateType { get; set; }
        
        public string? Remarks { get; set; }
        
        public string? LocationLongitude { get; set; }
        
        public string? LocationLatitude { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
    }
}