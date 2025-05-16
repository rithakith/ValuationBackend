using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReportId { get; set; }  // Primary key with auto-generated ID
        
        [Required]
        [StringLength(50)]
        public string ReportType { get; set; }
        
        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;  // Default to current UTC time when created
        
        // Additional fields can be added here based on requirements
        public string Description { get; set; }
        
        // You might want to add relationships to other entities
        // For example, if a report is related to a rating request:
        // public int? RatingRequestId { get; set; }
        // public RatingRequest RatingRequest { get; set; }
    }
}
