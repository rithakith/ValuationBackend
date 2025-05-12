using System;
using System.ComponentModel.DataAnnotations;

namespace ValuationBackend.Models
{
    public class BuildingRatesLA
    {
        [Key]
        public int Id { get; set; }
        
        public string MasterFileId { get; set; }
        
        public string AssessmentNumber { get; set; }
        
        public string Owner { get; set; }
        
        public string ConstructedBy { get; set; }
        
        public string YearOfConstruction { get; set; }
        
        public string DescriptionOfProperty { get; set; }
        
        public string FloorAreaSQFT { get; set; }
        
        public string RatePerSQFT { get; set; }
        
        public string Cost { get; set; }
        
        public string Remarks { get; set; }
        
        public string LocationLatitude { get; set; }
        
        public string LocationLongitude { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
    }
}