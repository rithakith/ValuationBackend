using System;
using ValuationBackend.Models.Enums;

namespace ValuationBackend.Models.DTOs
{
    public class DomesticRatingCardDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string AssetNo { get; set; }
        public string NewNumber { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public WallType SelectWalls { get; set; }
        public FloorType Floor { get; set; }
        public ConvenienceType Conveniences { get; set; }
        public ConditionType Condition { get; set; }
        public int? Age { get; set; }
        public AccessType Access { get; set; }
        public string TsBop { get; set; }
        public string ParkingSpace { get; set; }
        public PropertySubCategory PropertySubCategory { get; set; }
        public ResidentialPropertyType PropertyType { get; set; }
        public string Plantations { get; set; }
        public string WardNumber { get; set; }
        public string RoadName { get; set; }
        public DateTime? Date { get; set; }
        public string Occupier { get; set; }
        public decimal? RentPM { get; set; }
        public string Terms { get; set; }
        public decimal? SuggestedRate { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateDomesticRatingCardDto
    {
        public int AssetId { get; set; }
        public WallType SelectWalls { get; set; }
        public FloorType Floor { get; set; }
        public ConvenienceType Conveniences { get; set; }
        public ConditionType Condition { get; set; }
        public int? Age { get; set; }
        public AccessType Access { get; set; }
        public string TsBop { get; set; }
        public string ParkingSpace { get; set; }
        public PropertySubCategory PropertySubCategory { get; set; }
        public ResidentialPropertyType PropertyType { get; set; }
        public string Plantations { get; set; }
        public string WardNumber { get; set; }
        public string RoadName { get; set; }
        public DateTime? Date { get; set; }
        public string Occupier { get; set; }
        public decimal? RentPM { get; set; }
        public string Terms { get; set; }
        public decimal? SuggestedRate { get; set; }
        public string Notes { get; set; }
    }

    public class UpdateDomesticRatingCardDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public WallType SelectWalls { get; set; }
        public FloorType Floor { get; set; }
        public ConvenienceType Conveniences { get; set; }
        public ConditionType Condition { get; set; }
        public int? Age { get; set; }
        public AccessType Access { get; set; }
        public string TsBop { get; set; }
        public string ParkingSpace { get; set; }
        public PropertySubCategory PropertySubCategory { get; set; }
        public ResidentialPropertyType PropertyType { get; set; }
        public string Plantations { get; set; }
        public string WardNumber { get; set; }
        public string RoadName { get; set; }
        public DateTime? Date { get; set; }
        public string Occupier { get; set; }
        public decimal? RentPM { get; set; }
        public string Terms { get; set; }
        public decimal? SuggestedRate { get; set; }
        public string Notes { get; set; }
    }
}
