using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class SpecialRatingCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        public Asset? Asset { get; set; }

        /// <summary>
        /// Auto-generated number for the rating card
        /// </summary>
        [Required]
        public required string NewNumber { get; set; }

        /// <summary>
        /// Automatically filled from Asset.Owner
        /// </summary>
        [Required]
        public required string Owner { get; set; }

        /// <summary>
        /// Automatically filled from Asset.Description
        /// </summary>
        [Required]
        public required string Description { get; set; }

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

        public DateTime CreatedAt { get; set; } = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
    }
}