using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class InspectionReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InspectionReportId { get; set; }

        // Foreign key to Report table
        [Required]
        public int ReportId { get; set; }
        
        [ForeignKey("ReportId")]
        public Report Report { get; set; }

        // Master file information
        [Required]
        public string MasterFileId { get; set; }

        [Required]
        public string MasterFileRefNo { get; set; }

        // Inspection details
        [Required]
        public DateTime InspectionDate { get; set; }        // Location information
        public string? DsDivision { get; set; }
        public string? District { get; set; }
        public string? Province { get; set; }
        public string? GnDivision { get; set; }
        public string? Village { get; set; }

        // Collection of buildings
        public virtual ICollection<InspectionBuilding> Buildings { get; set; } = new List<InspectionBuilding>();        // Additional information
        public string? OtherInformation { get; set; }
        public string? OtherConstructionDetails { get; set; }
        
        [Column("DetailsOfAssestsInventoryItems")]
        public string? DetailsOfAssestsInventoryItems { get; set; }
        
        public string? DetailsOfBusiness { get; set; }
        public string? Remark { get; set; }
    }
}
