using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class LALot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary Key (auto increment)

        // Foreign key to LandAquisitionMasterFile table
        [Required]
        public int MasterFileId { get; set; }

        [ForeignKey("MasterFileId")]
        public virtual LandAquisitionMasterFile MasterFile { get; set; }

        // Map coordinates from frontend (stored as JSON string)
        [Required]
        public string Coordinates { get; set; } = string.Empty;

        // Optional: Additional metadata
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
