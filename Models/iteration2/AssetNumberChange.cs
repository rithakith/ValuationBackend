using System.ComponentModel.DataAnnotations;

namespace ValuationBackend.Models
{
    public class AssetNumberChange
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OldAssetNo { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string NewAssetNo { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Reason { get; set; }

        public DateTime? ChangedDate { get; set; }


        public DateTime DateOfChange { get; set; } = DateTime.UtcNow;
    }
}
