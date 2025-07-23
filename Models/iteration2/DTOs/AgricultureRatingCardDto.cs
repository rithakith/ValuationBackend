using System;

namespace ValuationBackend.Models.DTOs
{
    public class AgricultureRatingCardDto
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
        public string? CropType { get; set; }
        public string? SoilType { get; set; }
        public string? IrrigationType { get; set; }
        public string? TopographyType { get; set; }
        public string? AccessType { get; set; }
        public string? PropertySubCategory { get; set; }
        public string? PropertyType { get; set; }
        public int? WardNumber { get; set; }
        public string? RoadName { get; set; }
        public DateTime? Date { get; set; }
        public string? Occupier { get; set; }
        public decimal? RentPM { get; set; }
        public string? Terms { get; set; }
        public decimal? TotalAcreage { get; set; }
        public decimal? CultivatedArea { get; set; }
        public decimal? YieldPerAcre { get; set; }
        public string? WaterSource { get; set; }
        public decimal? SuggestedRate { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateAgricultureRatingCardDto
    {
        public string? LocalAuthority { get; set; }
        public string? LocalAuthorityCode { get; set; }
        public string? AssessmentNumber { get; set; }
        public string? ObsoleteNumber { get; set; }
        public string? CropType { get; set; }
        public string? SoilType { get; set; }
        public string? IrrigationType { get; set; }
        public string? TopographyType { get; set; }
        public string? AccessType { get; set; }
        public string? PropertySubCategory { get; set; }
        public string? PropertyType { get; set; }
        public int? WardNumber { get; set; }
        public string? RoadName { get; set; }
        public DateTime? Date { get; set; }
        public string? Occupier { get; set; }
        public decimal? RentPM { get; set; }
        public string? Terms { get; set; }
        public decimal? TotalAcreage { get; set; }
        public decimal? CultivatedArea { get; set; }
        public decimal? YieldPerAcre { get; set; }
        public string? WaterSource { get; set; }
        public decimal? SuggestedRate { get; set; }
        public string? Notes { get; set; }
    }

    public class UpdateAgricultureRatingCardDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string? LocalAuthority { get; set; }
        public string? LocalAuthorityCode { get; set; }
        public string? AssessmentNumber { get; set; }
        public string? ObsoleteNumber { get; set; }
        public string? CropType { get; set; }
        public string? SoilType { get; set; }
        public string? IrrigationType { get; set; }
        public string? TopographyType { get; set; }
        public string? AccessType { get; set; }
        public string? PropertySubCategory { get; set; }
        public string? PropertyType { get; set; }
        public int? WardNumber { get; set; }
        public string? RoadName { get; set; }
        public DateTime? Date { get; set; }
        public string? Occupier { get; set; }
        public decimal? RentPM { get; set; }
        public string? Terms { get; set; }
        public decimal? TotalAcreage { get; set; }
        public decimal? CultivatedArea { get; set; }
        public decimal? YieldPerAcre { get; set; }
        public string? WaterSource { get; set; }
        public decimal? SuggestedRate { get; set; }
        public string? Notes { get; set; }
    }
}