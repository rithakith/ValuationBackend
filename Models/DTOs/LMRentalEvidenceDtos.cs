using System.ComponentModel.DataAnnotations;

namespace ValuationBackend.Models.DTOs
{
    public class LMRentalEvidenceCreateDto
    {
        [Required]
        public string MasterFileRefNo { get; set; }
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
}
