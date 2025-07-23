using System;

namespace ValuationBackend.Models.DTOs
{
    public class SpecialRatingCardDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string AssetNo { get; set; }
        public string NewNumber { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public string? LocalAuthority { get; set; }
        public string? LocalAuthorityCode { get; set; }
        public string? AssessmentNumber { get; set; }
        public string? ObsoleteNumber { get; set; }
        public string? SpecialPropertyType { get; set; }
        public string? SpecialCategory { get; set; }
        public string? FacilityType { get; set; }
        public string? OperatingStatus { get; set; }
        public string? LicenseStatus { get; set; }
        public int? Capacity { get; set; }
        public string? AccessType { get; set; }
        public string? PropertySubCategory { get; set; }
        public string? PropertyType { get; set; }
        public int? WardNumber { get; set; }
        public string? RoadName { get; set; }
        public DateTime? Date { get; set; }
        public string? Occupier { get; set; }
        public decimal? RentPM { get; set; }
        public string? Terms { get; set; }
        public decimal? AnnualRevenue { get; set; }
        public decimal? OperatingCosts { get; set; }
        public decimal? TotalArea { get; set; }
        public string? SpecialFeatures { get; set; }
        public decimal? SuggestedRate { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateSpecialRatingCardDto
    {
        public string? LocalAuthority { get; set; }
        public string? LocalAuthorityCode { get; set; }
        public string? AssessmentNumber { get; set; }
        public string? ObsoleteNumber { get; set; }
        public string? SpecialPropertyType { get; set; }
        public string? SpecialCategory { get; set; }
        public string? FacilityType { get; set; }
        public string? OperatingStatus { get; set; }
        public string? LicenseStatus { get; set; }
        public int? Capacity { get; set; }
        public string? AccessType { get; set; }
        public string? PropertySubCategory { get; set; }
        public string? PropertyType { get; set; }
        public int? WardNumber { get; set; }
        public string? RoadName { get; set; }
        public DateTime? Date { get; set; }
        public string? Occupier { get; set; }
        public decimal? RentPM { get; set; }
        public string? Terms { get; set; }
        public decimal? AnnualRevenue { get; set; }
        public decimal? OperatingCosts { get; set; }
        public decimal? TotalArea { get; set; }
        public string? SpecialFeatures { get; set; }
        public decimal? SuggestedRate { get; set; }
        public string? Notes { get; set; }
    }

    public class UpdateSpecialRatingCardDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string? LocalAuthority { get; set; }
        public string? LocalAuthorityCode { get; set; }
        public string? AssessmentNumber { get; set; }
        public string? ObsoleteNumber { get; set; }
        public string? SpecialPropertyType { get; set; }
        public string? SpecialCategory { get; set; }
        public string? FacilityType { get; set; }
        public string? OperatingStatus { get; set; }
        public string? LicenseStatus { get; set; }
        public int? Capacity { get; set; }
        public string? AccessType { get; set; }
        public string? PropertySubCategory { get; set; }
        public string? PropertyType { get; set; }
        public int? WardNumber { get; set; }
        public string? RoadName { get; set; }
        public DateTime? Date { get; set; }
        public string? Occupier { get; set; }
        public decimal? RentPM { get; set; }
        public string? Terms { get; set; }
        public decimal? AnnualRevenue { get; set; }
        public decimal? OperatingCosts { get; set; }
        public decimal? TotalArea { get; set; }
        public string? SpecialFeatures { get; set; }
        public decimal? SuggestedRate { get; set; }
        public string? Notes { get; set; }
    }
}