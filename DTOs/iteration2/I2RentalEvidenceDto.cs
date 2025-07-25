using System;

namespace ValuationBackend.DTOs.iteration2
{
    public class I2RentalEvidenceDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string AssessmentNumber { get; set; }
        public string OwnerName { get; set; }
        public string OccupierName { get; set; }
        public string DescriptionOfProperty { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Building { get; set; }
        public string PropertyCategory { get; set; }
        public string PropertySubcategory { get; set; }
        public string PropertyType { get; set; }
        public decimal? FloorRate { get; set; }
        public string RatePer { get; set; }
        public decimal? RatePerMonth { get; set; }
        public string HeadOfTerms { get; set; }
        public string Situation { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class CreateI2RentalEvidenceDto
    {
        public int AssetId { get; set; }
        public string AssessmentNumber { get; set; }
        public string OwnerName { get; set; }
        public string OccupierName { get; set; }
        public string DescriptionOfProperty { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Building { get; set; }
        public string PropertyCategory { get; set; }
        public string PropertySubcategory { get; set; }
        public string PropertyType { get; set; }
        public decimal? FloorRate { get; set; }
        public string RatePer { get; set; }
        public decimal? RatePerMonth { get; set; }
        public string HeadOfTerms { get; set; }
        public string Situation { get; set; }
        public string Remarks { get; set; }
    }

    public class UpdateI2RentalEvidenceDto
    {
        public string AssessmentNumber { get; set; }
        public string OwnerName { get; set; }
        public string OccupierName { get; set; }
        public string DescriptionOfProperty { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Building { get; set; }
        public string PropertyCategory { get; set; }
        public string PropertySubcategory { get; set; }
        public string PropertyType { get; set; }
        public decimal? FloorRate { get; set; }
        public string RatePer { get; set; }
        public decimal? RatePerMonth { get; set; }
        public string HeadOfTerms { get; set; }
        public string Situation { get; set; }
        public string Remarks { get; set; }
    }
}