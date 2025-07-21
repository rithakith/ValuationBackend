using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class BuildingRatesLA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public int ReportId { get; set; }
        
        [ForeignKey("ReportId")]
        public Report? Report { get; set; }
        
        [Required]
        public string MasterFileId { get; set; } = string.Empty;
        
        [Required]
        public string AssessmentNumber { get; set; } = string.Empty;
        
        [Required]
        public string Owner { get; set; } = string.Empty;
        
        public string? ConstructedBy { get; set; }
        
        [Required]
        public string YearOfConstruction { get; set; } = string.Empty;
        
        public string? DescriptionOfProperty { get; set; }
        
        [Required]
        public string FloorAreaSQFT { get; set; } = string.Empty;
        
        [Required]
        public string RatePerSQFT { get; set; } = string.Empty;
        
        [Required]
        public string Cost { get; set; } = string.Empty;
        
        public string? Remarks { get; set; }
        
        public string? LocationLatitude { get; set; }
        
        public string? LocationLongitude { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
    }
}