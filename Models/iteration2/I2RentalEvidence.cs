using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models.iteration2
{
    [Table("I2RentalEvidences")]
    public class I2RentalEvidence
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AssetId { get; set; }

        [ForeignKey("AssetId")]
        public virtual Asset Asset { get; set; }

        [StringLength(50)]
        public string AssessmentNumber { get; set; }

        [StringLength(100)]
        public string OwnerName { get; set; }

        [StringLength(100)]
        public string OccupierName { get; set; }

        [StringLength(255)]
        public string DescriptionOfProperty { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        [StringLength(100)]
        public string Building { get; set; }

        [StringLength(100)]
        public string PropertyCategory { get; set; }

        [StringLength(100)]
        public string PropertySubcategory { get; set; }

        [StringLength(100)]
        public string PropertyType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? FloorRate { get; set; }

        [StringLength(50)]
        public string RatePer { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? RatePerMonth { get; set; }

        [StringLength(200)]
        public string HeadOfTerms { get; set; }

        [StringLength(200)]
        public string Situation { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        // Audit fields
        [Required]
        public DateTime CreatedAt { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [StringLength(100)]
        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}