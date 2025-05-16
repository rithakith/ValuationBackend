using System;
using System.ComponentModel.DataAnnotations;

namespace ValuationBackend.Models
{
    public class RentalEvidenceLA
    {
        [Key]
        public int Id { get; set; }
        
        public string MasterFileId { get; set; }
        
        public string AssessmentNo { get; set; }
        
        public string MasterFileRefNo { get; set; }
        
        public string Owner { get; set; }
        
        public string Occupier { get; set; }
        
        public string Description { get; set; }
        
        public string FloorRateSQFT { get; set; }
        
        public string RatePerSqft { get; set; }
        
        public string RatePerMonth { get; set; }
        
        public string LocationLongitude { get; set; }
        
        public string LocationLatitude { get; set; }
        
        public string HeadOfTerms { get; set; }
        
        public string Situation { get; set; }
        
        public string Remarks { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
    }
}