using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class DomesticRatingCard
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

        public string? SelectWalls { get; set; }

        public string? Floor { get; set; }

        public string? Conveniences { get; set; }

        public string? Condition { get; set; }

        public int? Age { get; set; }

        public string? Access { get; set; }
        
        public string? TsBop { get; set; }

        public string? ParkingSpace { get; set; }

        public string? PropertySubCategory { get; set; }

        public string? PropertyType { get; set; }

        public string? Plantations { get; set; }

        public string? WardNumber { get; set; }

        public string? RoadName { get; set; }

        public DateTime? Date { get; set; }

        public string? Occupier { get; set; }

        public decimal? RentPM { get; set; }

        public string? Terms { get; set; }

        public decimal? SuggestedRate { get; set; }
        
        public string? Notes { get; set; }        public DateTime CreatedAt { get; set; } = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
    }
}
