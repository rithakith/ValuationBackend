using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class Reconciliation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        [Required]
        [StringLength(200)]
        public string StreetName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string ObsoleteNo { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string NewNo { get; set; } = string.Empty;

        [Required]        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("AssetId")]
        public virtual Asset? Asset { get; set; }
    }
}
