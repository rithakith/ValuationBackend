using System.ComponentModel.DataAnnotations;

namespace ValuationBackend.Models.DTOs
{
    public class LMBuildingRatesCreateDto
    {
        [Required]
        public string MasterFileRefNo { get; set; }
        public string? AssessmentNumber { get; set; }
        public string? Owner { get; set; }
        public string? ConstructedBy { get; set; }
        public string? YearOfConstruction { get; set; }
        public string? DescriptionOfProperty { get; set; }
        public string? FloorArea { get; set; }
        public string? RatePerSQFT { get; set; }
        public string? Cost { get; set; }
        public string? Remarks { get; set; }
        public string? LocationLatitude { get; set; }
        public string? LocationLongitude { get; set; }
        public int? LandMiscellaneousMasterFileId { get; set; }
    }

    public class LMBuildingRatesUpdateDto
    {
        [Required]
        public int ReportId { get; set; }
        [Required]
        public string MasterFileRefNo { get; set; }
        public string? AssessmentNumber { get; set; }
        public string? Owner { get; set; }
        public string? ConstructedBy { get; set; }
        public string? YearOfConstruction { get; set; }
        public string? DescriptionOfProperty { get; set; }
        public string? FloorArea { get; set; }
        public string? RatePerSQFT { get; set; }
        public string? Cost { get; set; }
        public string? Remarks { get; set; }
        public string? LocationLatitude { get; set; }
        public string? LocationLongitude { get; set; }
        public int? LandMiscellaneousMasterFileId { get; set; }
    }

    public class LMBuildingRatesResponseDto
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string MasterFileRefNo { get; set; }
        public string? AssessmentNumber { get; set; }
        public string? Owner { get; set; }
        public string? ConstructedBy { get; set; }
        public string? YearOfConstruction { get; set; }
        public string? DescriptionOfProperty { get; set; }
        public string? FloorArea { get; set; }
        public string? RatePerSQFT { get; set; }
        public string? Cost { get; set; }
        public string? Remarks { get; set; }
        public string? LocationLatitude { get; set; }
        public string? LocationLongitude { get; set; }
        public int? LandMiscellaneousMasterFileId { get; set; }
        public LandMiscellaneousMasterFileDto? LandMiscellaneousMasterFile { get; set; }
    }
}
