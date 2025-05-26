using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public enum PropertyType
    {
        CommercialProperty,
        ResidentialProperty
    }

    public class Asset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Request")]
        public int RequestId { get; set; }

        [Required]
        [StringLength(100)]
        public string AssetNo { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Ward { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string RdSt { get; set; } = string.Empty;

        [Required]
        public PropertyType Description { get; set; }

        [Required]
        [StringLength(200)]
        public string Owner { get; set; } = string.Empty;

        [Required]
        public bool IsRatingCard { get; set; } = false;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public virtual Request? Request { get; set; }
    }
}
