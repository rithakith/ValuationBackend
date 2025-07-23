using System.ComponentModel.DataAnnotations;

namespace ValuationBackend.Models.DTOs
{
    public class LMPastValuationCreateDto
    {
        [Required]
        public string MasterFileRefNo { get; set; }
        public string? FileNo_GnDivision { get; set; }
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
        public int? LandMiscellaneousMasterFileId { get; set; }
    }

    public class LMPastValuationUpdateDto
    {
        [Required]
        public int ReportId { get; set; }
        [Required]
        public string MasterFileRefNo { get; set; }
        public string? FileNo_GnDivision { get; set; }
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
        public int? LandMiscellaneousMasterFileId { get; set; }
    }

    public class LMPastValuationResponseDto
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string MasterFileRefNo { get; set; }
        public string? FileNo_GnDivision { get; set; }
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
        public int? LandMiscellaneousMasterFileId { get; set; }
        public LandMiscellaneousMasterFileDto? LandMiscellaneousMasterFile { get; set; }
    }
}
