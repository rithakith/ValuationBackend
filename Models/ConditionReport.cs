using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class ConditionReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ReportId { get; set; }
        
        [ForeignKey("ReportId")]
        public Report? Report { get; set; }
        
        [Required]
        public required string MasterFileId { get; set; }
        
        // Land Info
        [Required]
        public required string NameOfTheVillage { get; set; }
        [Required]
        public required string NameOfTheLand { get; set; }
        [Required]
        public required string AtPlanNumber { get; set; }
        [Required]
        public required string AtLotNumber { get; set; }
        [Required]
        public required string PpCadNumber { get; set; }
        [Required]
        public required string PpCadLotNumber { get; set; }
        [Required]
        public required string AcquiredExtent { get; set; }
        [Required]
        public required string AssessmentNumber { get; set; }
        [Required]
        public required string RoadName { get; set; }
        [Required]
        public required string AccessCategory { get; set; }
        [Required]
        public required string AccessCategoryDescription { get; set; }
        [Required]
        public required string DescriptionOfLand { get; set; }
        [Required]
        public required string LandUseDescription { get; set; }
        [Required]
        public required string LandUseType { get; set; }
        [Required]
        public required string Frontage { get; set; }
        [Required]
        public required string DepthOfLand { get; set; }
        [Required]
        public required string LevelWithAccess { get; set; }
        [Required]
        public required string PlantationDetails { get; set; }
        [Required]
        public required string DetailsOfBusiness { get; set; }
        [Required]
        public required string AcquisitionName { get; set; }
        [Required]
        public required string DatePrepared { get; set; }
        [Required]
        public required string DateOfSection3BA { get; set; }
        
        // Boundaries
        [Required]
        public required string BoundaryNorth { get; set; }
        [Required]
        public required string BoundaryEast { get; set; }
        [Required]
        public required string BoundaryWest { get; set; }
        [Required]
        public required string BoundarySouth { get; set; }
        [Required]
        public required string BoundaryBottom { get; set; }
        
        // Building Info
        [Required]
        public required string BuildingDescription { get; set; }
        [Required]
        public required string BuildingInfo { get; set; } // JSON string containing all buildings
        
        // Other Constructions
        [Required]
        public required string OtherConstructionsDescription { get; set; }
        [Required]
        public required string OtherConstructionsInfo { get; set; } // JSON string containing other constructions
        
        // Signatures
        [Required]
        public required string AcquiringOfficerSignature { get; set; }
        [Required]
        public required string GramasewakaSignature { get; set; }
        [Required]
        public required string ChiefValuerRepresentativeSignature { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}