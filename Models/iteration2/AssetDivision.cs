using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class AssetDivision
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        [Required]
        public string NewAssetNo { get; set; }

        [Required]
        public decimal Area { get; set; }

        public string LandType { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Asset Asset { get; set; }
    }
}
