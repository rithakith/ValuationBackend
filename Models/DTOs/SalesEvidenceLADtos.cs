using System;

namespace ValuationBackend.Models.DTOs
{
    // Input DTO for creating a new sales evidence
    public class SalesEvidenceLACreateDto
    {
        // Master file information
        public int MasterFileId { get; set; }
        public string MasterFileRefNo { get; set; } = string.Empty;
        
        public string? AssetNumber { get; set; }
        public string? Road { get; set; }
        public string? Village { get; set; }
        public string? Owner { get; set; }
        public string? Occupier { get; set; }
        public string? Vendor { get; set; }
        public string? DeedNumber { get; set; }
        public string? Description { get; set; }
        public string? FloorRate { get; set; }
        public string? DeedAttestedNumber { get; set; }
        public string? NotaryName { get; set; }
        public string? LotNumber { get; set; }
        public string? PlanNumber { get; set; }
        public string? PlanDate { get; set; }
        public string? Extent { get; set; }
        public string? Consideration { get; set; }
        public string? Remarks { get; set; }
        public string? Rate { get; set; }
        public string? RateType { get; set; }
        public string? LocationLongitude { get; set; }
        public string? LocationLatitude { get; set; }
        public string? LandRegistryReferences { get; set; }
        public string? Situation { get; set; }
        public string? DescriptionOfProperty { get; set; }
    }

    // Input DTO for updating an existing sales evidence
    public class SalesEvidenceLAUpdateDto
    {
        public int MasterFileId { get; set; }
        public string MasterFileRefNo { get; set; } = string.Empty;
        
        public string? AssetNumber { get; set; }
        public string? Road { get; set; }
        public string? Village { get; set; }
        public string? Owner { get; set; }
        public string? Occupier { get; set; }
        public string? Vendor { get; set; }
        public string? DeedNumber { get; set; }
        public string? Description { get; set; }
        public string? FloorRate { get; set; }
        public string? DeedAttestedNumber { get; set; }
        public string? NotaryName { get; set; }
        public string? LotNumber { get; set; }
        public string? PlanNumber { get; set; }
        public string? PlanDate { get; set; }
        public string? Extent { get; set; }
        public string? Consideration { get; set; }
        public string? Remarks { get; set; }
        public string? Rate { get; set; }
        public string? RateType { get; set; }
        public string? LocationLongitude { get; set; }
        public string? LocationLatitude { get; set; }
        public string? LandRegistryReferences { get; set; }
        public string? Situation { get; set; }
        public string? DescriptionOfProperty { get; set; }
    }

    // Response DTO with evidence ID information
    public class SalesEvidenceLAResponseDto
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        
        public int MasterFileId { get; set; }
        public string MasterFileRefNo { get; set; } = string.Empty;
        
        public string? AssetNumber { get; set; }
        public string? Road { get; set; }
        public string? Village { get; set; }
        public string? Owner { get; set; }
        public string? Occupier { get; set; }
        public string? Vendor { get; set; }
        public string? DeedNumber { get; set; }
        public string? Description { get; set; }
        public string? FloorRate { get; set; }
        public string? DeedAttestedNumber { get; set; }
        public string? NotaryName { get; set; }
        public string? LotNumber { get; set; }
        public string? PlanNumber { get; set; }
        public string? PlanDate { get; set; }
        public string? Extent { get; set; }
        public string? Consideration { get; set; }
        public string? Remarks { get; set; }
        public string? Rate { get; set; }
        public string? RateType { get; set; }
        public string? LocationLongitude { get; set; }
        public string? LocationLatitude { get; set; }
        public string? LandRegistryReferences { get; set; }
        public string? Situation { get; set; }
        public string? DescriptionOfProperty { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
