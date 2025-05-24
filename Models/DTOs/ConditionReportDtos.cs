using System;

namespace ValuationBackend.Models.DTOs
{
    // Input DTO for creating a new condition report
    public class ConditionReportCreateDto
    {
        // Master file information
        public string MasterFileId { get; set; }
        public string MasterFileRefNo { get; set; }
        
        // Land Info
        public string NameOfTheVillage { get; set; }
        public string NameOfTheLand { get; set; }
        public string AtPlanNumber { get; set; }
        public string AtLotNumber { get; set; }
        public string PpCadNumber { get; set; }
        public string PpCadLotNumber { get; set; }
        public string AcquiredExtent { get; set; }
        public string AssessmentNumber { get; set; }
        public string RoadName { get; set; }
        public string AccessCategory { get; set; }
        public string AccessCategoryDescription { get; set; }
        public string DescriptionOfLand { get; set; }
        public string LandUseDescription { get; set; }
        public string LandUseType { get; set; }
        public string Frontage { get; set; }
        public string DepthOfLand { get; set; }
        public string LevelWithAccess { get; set; }
        public string PlantationDetails { get; set; }
        public string DetailsOfBusiness { get; set; }
        public string AcquisitionName { get; set; }
        public string DatePrepared { get; set; }
        public string DateOfSection3BA { get; set; }
        
        // Boundaries
        public string BoundaryNorth { get; set; }
        public string BoundaryEast { get; set; }
        public string BoundaryWest { get; set; }
        public string BoundarySouth { get; set; }
        public string BoundaryBottom { get; set; }
        
        // Building Info
        public string BuildingDescription { get; set; }
        public string BuildingInfo { get; set; } // JSON string containing all buildings
        
        // Other Constructions
        public string OtherConstructionsDescription { get; set; }
        public string OtherConstructionsInfo { get; set; } // JSON string containing other constructions
        
        // Signatures
        public string AcquiringOfficerSignature { get; set; }
        public string GramasewakaSignature { get; set; }
        public string ChiefValuerRepresentativeSignature { get; set; }
    }

    // Input DTO for updating an existing condition report
    public class ConditionReportUpdateDto
    {
        // Master file information
        public string MasterFileId { get; set; }
        public string MasterFileRefNo { get; set; }
        
        // Land Info
        public string NameOfTheVillage { get; set; }
        public string NameOfTheLand { get; set; }
        public string AtPlanNumber { get; set; }
        public string AtLotNumber { get; set; }
        public string PpCadNumber { get; set; }
        public string PpCadLotNumber { get; set; }
        public string AcquiredExtent { get; set; }
        public string AssessmentNumber { get; set; }
        public string RoadName { get; set; }
        public string AccessCategory { get; set; }
        public string AccessCategoryDescription { get; set; }
        public string DescriptionOfLand { get; set; }
        public string LandUseDescription { get; set; }
        public string LandUseType { get; set; }
        public string Frontage { get; set; }
        public string DepthOfLand { get; set; }
        public string LevelWithAccess { get; set; }
        public string PlantationDetails { get; set; }
        public string DetailsOfBusiness { get; set; }
        public string AcquisitionName { get; set; }
        public string DatePrepared { get; set; }
        public string DateOfSection3BA { get; set; }
        
        // Boundaries
        public string BoundaryNorth { get; set; }
        public string BoundaryEast { get; set; }
        public string BoundaryWest { get; set; }
        public string BoundarySouth { get; set; }
        public string BoundaryBottom { get; set; }
        
        // Building Info
        public string BuildingDescription { get; set; }
        public string BuildingInfo { get; set; } // JSON string containing all buildings
        
        // Other Constructions
        public string OtherConstructionsDescription { get; set; }
        public string OtherConstructionsInfo { get; set; } // JSON string containing other constructions
        
        // Signatures
        public string AcquiringOfficerSignature { get; set; }
        public string GramasewakaSignature { get; set; }
        public string ChiefValuerRepresentativeSignature { get; set; }
    }

    // Response DTO with report ID information
    public class ConditionReportResponseDto
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        
        // Master file information
        public string MasterFileId { get; set; }
        public string MasterFileRefNo { get; set; }
        
        // Land Info
        public string NameOfTheVillage { get; set; }
        public string NameOfTheLand { get; set; }
        public string AtPlanNumber { get; set; }
        public string AtLotNumber { get; set; }
        public string PpCadNumber { get; set; }
        public string PpCadLotNumber { get; set; }
        public string AcquiredExtent { get; set; }
        public string AssessmentNumber { get; set; }
        public string RoadName { get; set; }
        public string AccessCategory { get; set; }
        public string AccessCategoryDescription { get; set; }
        public string DescriptionOfLand { get; set; }
        public string LandUseDescription { get; set; }
        public string LandUseType { get; set; }
        public string Frontage { get; set; }
        public string DepthOfLand { get; set; }
        public string LevelWithAccess { get; set; }
        public string PlantationDetails { get; set; }
        public string DetailsOfBusiness { get; set; }
        public string AcquisitionName { get; set; }
        public string DatePrepared { get; set; }
        public string DateOfSection3BA { get; set; }
        
        // Boundaries
        public string BoundaryNorth { get; set; }
        public string BoundaryEast { get; set; }
        public string BoundaryWest { get; set; }
        public string BoundarySouth { get; set; }
        public string BoundaryBottom { get; set; }
        
        // Building Info
        public string BuildingDescription { get; set; }
        public string BuildingInfo { get; set; } // JSON string containing all buildings
        
        // Other Constructions
        public string OtherConstructionsDescription { get; set; }
        public string OtherConstructionsInfo { get; set; } // JSON string containing other constructions
        
        // Signatures
        public string AcquiringOfficerSignature { get; set; }
        public string GramasewakaSignature { get; set; }
        public string ChiefValuerRepresentativeSignature { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
