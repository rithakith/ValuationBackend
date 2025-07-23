using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models.iteration2.RatingCards
{
    public class OfficesRatingCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AssetId { get; set; }
        
        [ForeignKey("AssetId")]
        public virtual Asset Asset { get; set; }

        [StringLength(100)]
        public string BuildingSelection { get; set; }

        [StringLength(200)]
        public string LocalAuthority { get; set; }

        [StringLength(50)]
        public string LocalAuthorityCode { get; set; }

        [StringLength(50)]
        public string AssessmentNumber { get; set; }

        [StringLength(50)]
        public string NewNumber { get; set; }

        [StringLength(50)]
        public string ObsoleteNumber { get; set; }

        [StringLength(200)]
        public string Owner { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(100)]
        public string WallType { get; set; }

        [StringLength(100)]
        public string FloorType { get; set; }

        [StringLength(100)]
        public string Conveniences { get; set; }

        [StringLength(50)]
        public string Condition { get; set; }

        public int? Age { get; set; }

        [StringLength(100)]
        public string AccessType { get; set; }

        [StringLength(50)]
        public string OfficeGrade { get; set; }

        [StringLength(200)]
        public string ParkingSpace { get; set; }

        [StringLength(100)]
        public string PropertySubCategory { get; set; }

        [StringLength(100)]
        public string PropertyType { get; set; }

        public int? WardNumber { get; set; }

        [StringLength(200)]
        public string RoadName { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(200)]
        public string Occupier { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? RentPM { get; set; }

        [StringLength(500)]
        public string Terms { get; set; }

        public int? FloorNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? CeilingHeight { get; set; }

        [StringLength(1000)]
        public string OfficeSuite { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalArea { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? UsableFloorArea { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? SuggestedRate { get; set; }

        [StringLength(2000)]
        public string Notes { get; set; }

        // Audit fields
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}