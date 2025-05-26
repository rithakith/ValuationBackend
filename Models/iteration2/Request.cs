using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("RequestType")]
        public int RequestTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string RatingReferenceNo { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LocalAuthority { get; set; } = string.Empty;

        [Required]
        [Range(1000, 9999)]
        public int YearOfRevision { get; set; }

        [Required]
        public bool Status { get; set; } // true = success, false = pending

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public virtual RequestType? RequestType { get; set; }
    }
}