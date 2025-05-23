using System;

namespace ValuationBackend.Models.DTOs
{
    // Input DTO for creating a new rental evidence
    public class RentalEvidenceLACreateDto
    {
        // Master file information
        public string MasterFileId { get; set; } = string.Empty;
        public string MasterFileRefNo { get; set; } = string.Empty;
        
        public string? AssessmentNo { get; set; }
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
    }

    // Input DTO for updating an existing rental evidence
    public class RentalEvidenceLAUpdateDto
    {
        public string MasterFileId { get; set; } = string.Empty;
        public string MasterFileRefNo { get; set; } = string.Empty;
        
        public string? AssessmentNo { get; set; }
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
    }

    // Response DTO with evidence ID information
    public class RentalEvidenceLAResponseDto
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        
        public string MasterFileId { get; set; } = string.Empty;
        public string MasterFileRefNo { get; set; } = string.Empty;
        
        public string? AssessmentNo { get; set; }
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
        
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
