using System;

namespace ValuationBackend.Models.DTOs
{
    public class ShopsRatingCardDto
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
        public string? WallType { get; set; }
        public string? FloorType { get; set; }
        public string? Conveniences { get; set; }
        public string? Condition { get; set; }
        public int? Age { get; set; }
        public string? AccessType { get; set; }
        public string? ShopGrade { get; set; }
        public string? ParkingSpace { get; set; }
        public string? PropertySubCategory { get; set; }
        public string? PropertyType { get; set; }
        public int? WardNumber { get; set; }
        public string? RoadName { get; set; }
        public DateTime? Date { get; set; }
        public string? Occupier { get; set; }
        public decimal? RentPM { get; set; }
        public string? Terms { get; set; }
        public string? DisplayArea { get; set; }
        public decimal? FrontageWidth { get; set; }
        public decimal? ShopDepth { get; set; }
        public decimal? TotalArea { get; set; }
        public decimal? SuggestedRate { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateShopsRatingCardDto
    {
        public string? LocalAuthority { get; set; }
        public string? LocalAuthorityCode { get; set; }
        public string? AssessmentNumber { get; set; }
        public string? ObsoleteNumber { get; set; }
        public string? WallType { get; set; }
        public string? FloorType { get; set; }
        public string? Conveniences { get; set; }
        public string? Condition { get; set; }
        public int? Age { get; set; }
        public string? AccessType { get; set; }
        public string? ShopGrade { get; set; }
        public string? ParkingSpace { get; set; }
        public string? PropertySubCategory { get; set; }
        public string? PropertyType { get; set; }
        public int? WardNumber { get; set; }
        public string? RoadName { get; set; }
        public DateTime? Date { get; set; }
        public string? Occupier { get; set; }
        public decimal? RentPM { get; set; }
        public string? Terms { get; set; }
        public string? DisplayArea { get; set; }
        public decimal? FrontageWidth { get; set; }
        public decimal? ShopDepth { get; set; }
        public decimal? TotalArea { get; set; }
        public decimal? SuggestedRate { get; set; }
        public string? Notes { get; set; }
    }

    public class UpdateShopsRatingCardDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string? LocalAuthority { get; set; }
        public string? LocalAuthorityCode { get; set; }
        public string? AssessmentNumber { get; set; }
        public string? ObsoleteNumber { get; set; }
        public string? WallType { get; set; }
        public string? FloorType { get; set; }
        public string? Conveniences { get; set; }
        public string? Condition { get; set; }
        public int? Age { get; set; }
        public string? AccessType { get; set; }
        public string? ShopGrade { get; set; }
        public string? ParkingSpace { get; set; }
        public string? PropertySubCategory { get; set; }
        public string? PropertyType { get; set; }
        public int? WardNumber { get; set; }
        public string? RoadName { get; set; }
        public DateTime? Date { get; set; }
        public string? Occupier { get; set; }
        public decimal? RentPM { get; set; }
        public string? Terms { get; set; }
        public string? DisplayArea { get; set; }
        public decimal? FrontageWidth { get; set; }
        public decimal? ShopDepth { get; set; }
        public decimal? TotalArea { get; set; }
        public decimal? SuggestedRate { get; set; }
        public string? Notes { get; set; }
    }
}