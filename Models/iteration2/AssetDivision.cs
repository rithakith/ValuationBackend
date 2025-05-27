using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    /// <summary>
    /// Represents a division of an existing asset
    /// </summary>
    public class AssetDivision
    {
        /// <summary>
        /// The unique identifier for the asset division
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The ID of the parent asset being divided. Must reference an existing asset.
        /// Example: 1 (for asset AST-001-2024)
        /// </summary>
        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        /// <summary>
        /// The new asset number for this division
        /// Example: ASSET-001-A
        /// </summary>
        [Required]
        public string NewAssetNo { get; set; }        /// <summary>
        /// The area of the divided portion in square meters
        /// Example: 1500.50
        /// </summary>
        [Required]
        public decimal Area { get; set; }/// <summary>
        /// The type of land in this division (e.g., Residential, Commercial, Agricultural, Industrial)
        /// Example: Residential
        /// </summary>
        [Required]
        [StringLength(100)]
        public string LandType { get; set; } = string.Empty;

        /// <summary>
        /// A description of the divided portion
        /// Example: North portion of original asset
        /// </summary>
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The timestamp when this division was created
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Asset? Asset { get; set; }
    }
}
