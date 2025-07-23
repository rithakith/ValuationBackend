using System;

namespace ValuationBackend.Models.DTOs
{
    // Input DTO for creating a new past valuation record
    public class PastValuationsLACreateDto
    {
        // Master file information
        public int MasterFileId { get; set; }
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
    }

    // Input DTO for updating an existing past valuation record
    public class PastValuationsLAUpdateDto
    {
        public int MasterFileId { get; set; }
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
    }

    // Read DTO for consistent naming with other services
    public class PastValuationsLAReadDto
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        
        public int MasterFileId { get; set; }
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
        
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
