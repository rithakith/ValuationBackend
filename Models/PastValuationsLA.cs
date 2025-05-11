using System;
using System.ComponentModel.DataAnnotations;

namespace ValuationBackend.Models
{
    public class PastValuationsLA
    {
        [Key]
        public int Id { get; set; }
        
        public string MasterFileId { get; set; }
        
        public string MasterFileRefNo { get; set; }
        
        public string FileNoGNDivision { get; set; }
        
        public string Situation { get; set; }
        
        public string DateOfValuation { get; set; }
        
        public string PurposeOfValuation { get; set; }
        
        public string PlanOfParticulars { get; set; }
        
        public string Extent { get; set; }
        
        public string Rate { get; set; }
        
        public string RateType { get; set; }
        
        public string Remarks { get; set; }
        
        public string LocationLongitude { get; set; }
        
        public string LocationLatitude { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
    }
}