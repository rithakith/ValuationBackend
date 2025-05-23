using System;

namespace ValuationBackend.Models.DTOs
{
    // Input DTO for creating a new past valuation record
    public class PastValuationsLACreateDto
    {
        // Master file information
        public string MasterFileId { get; set; } = string.Empty;
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
        public string MasterFileId { get; set; } = string.Empty;
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

    // Response DTO with past valuation ID information
    public class PastValuationsLAResponseDto
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        
        public string MasterFileId { get; set; } = string.Empty;
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
