using System.ComponentModel.DataAnnotations;

namespace ValuationBackend.Models.DTOs
{
    public class LMRentalEvidenceCreateDto
    {
        [Required]
        public string MasterFileRefNo { get; set; }

        // NEW: Optional foreign key to LandMiscellaneousMasterFile
        public int? LandMiscellaneousMasterFileId { get; set; }

        public string? AssessmentNo { get; set; }
        public string? Owner { get; set; }
        public string? Occupier { get; set; }
        public string? Description { get; set; }
        public string? FloorRate { get; set; }
        public string? RatePer { get; set; }
        public string? RatePerMonth { get; set; }
        public string? LocationLongitude { get; set; }
        public string? LocationLatitude { get; set; }
        public string? HeadOfTerms { get; set; }
        public string? Situation { get; set; }
        public string? Remarks { get; set; }
    }

    public class LMRentalEvidenceUpdateDto
    {
        [Required]
        public int ReportId { get; set; }
        [Required]
        public string MasterFileRefNo { get; set; }

        // NEW: Optional foreign key to LandMiscellaneousMasterFile
        public int? LandMiscellaneousMasterFileId { get; set; }

        public string? AssessmentNo { get; set; }
        public string? Owner { get; set; }
        public string? Occupier { get; set; }
        public string? Description { get; set; }
        public string? FloorRate { get; set; }
        public string? RatePer { get; set; }
        public string? RatePerMonth { get; set; }
        public string? LocationLongitude { get; set; }
        public string? LocationLatitude { get; set; }
        public string? HeadOfTerms { get; set; }
        public string? Situation { get; set; }
        public string? Remarks { get; set; }
    }

    public class LMRentalEvidenceResponseDto
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string MasterFileRefNo { get; set; }

        // NEW: Foreign key to LandMiscellaneousMasterFile
        public int? LandMiscellaneousMasterFileId { get; set; }

        // NEW: Navigation property for related master file data
        public LandMiscellaneousMasterFileDto? LandMiscellaneousMasterFile { get; set; }

        public string? AssessmentNo { get; set; }
        public string? Owner { get; set; }
        public string? Occupier { get; set; }
        public string? Description { get; set; }
        public string? FloorRate { get; set; }
        public string? RatePer { get; set; }
        public string? RatePerMonth { get; set; }
        public string? LocationLongitude { get; set; }
        public string? LocationLatitude { get; set; }
        public string? HeadOfTerms { get; set; }
        public string? Situation { get; set; }
        public string? Remarks { get; set; }
    }

    // NEW: DTO for LandMiscellaneousMasterFile navigation property
    public class LandMiscellaneousMasterFileDto
    {
        public int Id { get; set; }
        public int MasterFileNo { get; set; }
        public string? MasterFileRefNo { get; set; }
        public string? PlanType { get; set; }
        public string? PlanNo { get; set; }
        public string? RequestingAuthorityReferenceNo { get; set; }
        public string? Status { get; set; }
        public int Lots { get; set; }
    }
}
