using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValuationBackend.Models
{
    public class InspectionBuilding
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Foreign key to InspectionReport
        public int InspectionReportId { get; set; }
        
        [ForeignKey("InspectionReportId")]
        public InspectionReport InspectionReport { get; set; }        // Building information
        public string? BuildingId { get; set; }
        public string? BuildingName { get; set; }
        public string? BuildingCategory { get; set; }
        public string? BuildingClass { get; set; }
        public string? DetailOfBuilding { get; set; }
        
        [Column("NoOfFloorsAboveGround")]
        public string? NoOfFloorsAboveGround { get; set; }
        
        [Column("NoOfFloorsBelowGround")]
        public string? NoOfFloorsBelowGround { get; set; }
          public string? AgeYears { get; set; }
        public string? ExpectedLifePeriodYears { get; set; }
        public string? ParkingSpace { get; set; }
        public string? Design { get; set; }
        public string? Conveniences { get; set; }
        public string? Structure { get; set; }
        public string? BuildingConditions { get; set; }
        public string? NatureOfConstruction { get; set; }
        public string? Condition { get; set; }
          // Roof information
        public string? RoofMaterial { get; set; }
        public string? RoofFrame { get; set; }
        public string? RoofFinisher { get; set; }
        public string? Ceiling { get; set; }
        
        // Structure information
        public string? FoundationStructure { get; set; }
        public string? WallStructure { get; set; }
        public string? FloorStructure { get; set; }
          // Doors and windows
        public string? Door { get; set; }
        public string? Window { get; set; }
        public string? WindowProtection { get; set; }
        public string? BathroomToiletDoorsFittings { get; set; }
        public string? HandRail { get; set; }
        public string? PantryCupboard { get; set; }
        public string? OtherDoors { get; set; }
        
        // Finishers
        public string? WallFinisher { get; set; }
        public string? FloorFinisher { get; set; }
        public string? BathroomToilet { get; set; }
        
        // Services
        public string? Services { get; set; }
    }
}
