using System;
using System.Collections.Generic;

namespace ValuationBackend.Models.DTOs
{
    // Input DTO for creating a new inspection report
    public class InspectionReportCreateDto
    {
        public string MasterFileId { get; set; }
        public string MasterFileRefNo { get; set; }
        public DateTime InspectionDate { get; set; }
        public string DsDivision { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string GnDivision { get; set; }
        public string Village { get; set; }
        public List<BuildingDto> Buildings { get; set; } = new List<BuildingDto>();
        public string OtherInformation { get; set; }
        public string OtherConstructionDetails { get; set; }
        public string DetailsOfAssestsInventoryItems { get; set; }
        public string DetailsOfBusiness { get; set; }
        public string Remark { get; set; }
    }

    // Input DTO for updating an existing inspection report
    public class InspectionReportUpdateDto
    {
        public int ReportId { get; set; }
        public string MasterFileId { get; set; }
        public string MasterFileRefNo { get; set; }
        public DateTime InspectionDate { get; set; }
        public string DsDivision { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string GnDivision { get; set; }
        public string Village { get; set; }
        public List<BuildingDto> Buildings { get; set; } = new List<BuildingDto>();
        public string OtherInformation { get; set; }
        public string OtherConstructionDetails { get; set; }
        public string DetailsOfAssestsInventoryItems { get; set; }
        public string DetailsOfBusiness { get; set; }
        public string Remark { get; set; }
    }

    // DTO for building information
    public class BuildingDto
    {
        public int? Id { get; set; } // Optional, used for updates
        public string BuildingId { get; set; }
        public string BuildingName { get; set; }
        public string BuildingCategory { get; set; }
        public string BuildingClass { get; set; }
        public string DetailOfBuilding { get; set; }
        public string NoOfFloorsAboveGround { get; set; }
        public string NoOfFloorsBelowGround { get; set; }
        public string AgeYears { get; set; }
        public string ExpectedLifePeriodYears { get; set; }
        public string ParkingSpace { get; set; }
        public string Design { get; set; }
        public string Conveniences { get; set; }
        public string Structure { get; set; }
        public string BuildingConditions { get; set; }
        public string NatureOfConstruction { get; set; }
        public string Condition { get; set; }
        public string RoofMaterial { get; set; }
        public string RoofFrame { get; set; }
        public string RoofFinisher { get; set; }
        public string Ceiling { get; set; }
        public string FoundationStructure { get; set; }
        public string WallStructure { get; set; }
        public string FloorStructure { get; set; }
        public string Door { get; set; }
        public string Window { get; set; }
        public string WindowProtection { get; set; }
        public string BathroomToiletDoorsFittings { get; set; }
        public string HandRail { get; set; }
        public string PantryCupboard { get; set; }
        public string OtherDoors { get; set; }
        public string WallFinisher { get; set; }
        public string FloorFinisher { get; set; }
        public string BathroomToilet { get; set; }
        public string Services { get; set; }
    }

    // Response DTO with report ID information
    public class InspectionReportResponseDto
    {
        public int InspectionReportId { get; set; }
        public int ReportId { get; set; }
        public string MasterFileId { get; set; }
        public string MasterFileRefNo { get; set; }
        public DateTime InspectionDate { get; set; }
        public string DsDivision { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string GnDivision { get; set; }
        public string Village { get; set; }
        public List<BuildingDto> Buildings { get; set; } = new List<BuildingDto>();
        public string OtherInformation { get; set; }
        public string OtherConstructionDetails { get; set; }
        public string DetailsOfAssestsInventoryItems { get; set; }
        public string DetailsOfBusiness { get; set; }
        public string Remark { get; set; }
    }
}
