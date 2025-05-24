using System;

namespace ValuationBackend.Models.DTOs
{
    // Input DTO for creating a new building rate
    public class BuildingRatesLACreateDto
    {
        // Master file information
        public string MasterFileId { get; set; } = string.Empty;
        
        public string? AssessmentNumber { get; set; }
        public string? Owner { get; set; }
        public string? ConstructedBy { get; set; }
        public string? YearOfConstruction { get; set; }
        public string? DescriptionOfProperty { get; set; }
        public string? FloorAreaSQFT { get; set; }
        public string? RatePerSQFT { get; set; }
        public string? Cost { get; set; }
        public string? Remarks { get; set; }
        public string? LocationLatitude { get; set; }
        public string? LocationLongitude { get; set; }
    }

    // Input DTO for updating an existing building rate
    public class BuildingRatesLAUpdateDto
    {
        public string MasterFileId { get; set; } = string.Empty;
        
        public string? AssessmentNumber { get; set; }
        public string? Owner { get; set; }
        public string? ConstructedBy { get; set; }
        public string? YearOfConstruction { get; set; }
        public string? DescriptionOfProperty { get; set; }
        public string? FloorAreaSQFT { get; set; }
        public string? RatePerSQFT { get; set; }
        public string? Cost { get; set; }
        public string? Remarks { get; set; }
        public string? LocationLatitude { get; set; }
        public string? LocationLongitude { get; set; }
    }

    // Response DTO with building rate ID information
    public class BuildingRatesLAResponseDto
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        
        public string MasterFileId { get; set; } = string.Empty;
        
        public string? AssessmentNumber { get; set; }
        public string? Owner { get; set; }
        public string? ConstructedBy { get; set; }
        public string? YearOfConstruction { get; set; }
        public string? DescriptionOfProperty { get; set; }
        public string? FloorAreaSQFT { get; set; }
        public string? RatePerSQFT { get; set; }
        public string? Cost { get; set; }
        public string? Remarks { get; set; }
        public string? LocationLatitude { get; set; }
        public string? LocationLongitude { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
