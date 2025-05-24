// filepath: d:\Projects\vd\vd backend\ValuationBackend\services\InspectionReportService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class InspectionReportService : IInspectionReportService
    {
        private readonly IInspectionReportRepository _repository;

        public InspectionReportService(IInspectionReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<InspectionReportResponseDto>> GetAllAsync()
        {
            var reports = await _repository.GetAllAsync();
            return reports.Select(MapToResponseDto).ToList();
        }

        public async Task<InspectionReportResponseDto> GetByIdAsync(int id)
        {
            var report = await _repository.GetByIdAsync(id);
            return report == null ? null : MapToResponseDto(report);
        }

        public async Task<InspectionReportResponseDto> GetByReportIdAsync(int reportId)
        {
            var report = await _repository.GetByReportIdAsync(reportId);
            return report == null ? null : MapToResponseDto(report);
        }

        public async Task<InspectionReportResponseDto> CreateAsync(InspectionReportCreateDto dto)
        {
            var reportEntity = new Report
            {
                ReportType = "LM_inspection",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Miscellaneous Inspection Report for {dto.MasterFileRefNo}"
            };

            var inspectionReport = new InspectionReport
            {
                MasterFileId = dto.MasterFileId,
                MasterFileRefNo = dto.MasterFileRefNo,
                InspectionDate = dto.InspectionDate,
                DsDivision = dto.DsDivision,
                District = dto.District,
                Province = dto.Province,
                GnDivision = dto.GnDivision,
                Village = dto.Village,
                OtherInformation = dto.OtherInformation,
                OtherConstructionDetails = dto.OtherConstructionDetails,
                DetailsOfAssestsInventoryItems = dto.DetailsOfAssestsInventoryItems,
                DetailsOfBusiness = dto.DetailsOfBusiness,
                Remark = dto.Remark,
                Buildings = dto.Buildings.Select(MapDtoToBuilding).ToList()
            };

            var createdReport = await _repository.CreateAsync(inspectionReport, reportEntity);
            return MapToResponseDto(createdReport);
        }

        public async Task<bool> UpdateAsync(int id, InspectionReportUpdateDto dto)
        {
            var existingReport = await _repository.GetByIdAsync(id);
            if (existingReport == null)
            {
                return false;
            }

            existingReport.MasterFileId = dto.MasterFileId;
            existingReport.MasterFileRefNo = dto.MasterFileRefNo;
            existingReport.InspectionDate = dto.InspectionDate;
            existingReport.DsDivision = dto.DsDivision;
            existingReport.District = dto.District;
            existingReport.Province = dto.Province;
            existingReport.GnDivision = dto.GnDivision;
            existingReport.Village = dto.Village;
            existingReport.OtherInformation = dto.OtherInformation;
            existingReport.OtherConstructionDetails = dto.OtherConstructionDetails;
            existingReport.DetailsOfAssestsInventoryItems = dto.DetailsOfAssestsInventoryItems;
            existingReport.DetailsOfBusiness = dto.DetailsOfBusiness;
            existingReport.Remark = dto.Remark;

            var buildingsToKeepIds = new HashSet<int>();

            // Process existing buildings and identify new ones
            var newBuildingDtos = new List<BuildingDto>();
            foreach (var buildingDto in dto.Buildings)
            {
                if (buildingDto.Id.HasValue && buildingDto.Id.Value > 0)
                {
                    var existingBuilding = existingReport.Buildings.FirstOrDefault(b => b.Id == buildingDto.Id.Value);
                    if (existingBuilding != null)
                    {
                        UpdateBuildingFromDto(existingBuilding, buildingDto);
                        buildingsToKeepIds.Add(existingBuilding.Id);
                    }
                    // If an existing building DTO has an ID but isn't found, it might be an error or a new building with a mis-set ID.
                    // For simplicity, we'll assume valid data or that it should be treated as new if not found.
                }
                else
                {
                    newBuildingDtos.Add(buildingDto); // Collect new buildings
                }
            }

            // Remove buildings that are no longer present
            var buildingsToRemove = existingReport.Buildings
                .Where(b => b.Id > 0 && !buildingsToKeepIds.Contains(b.Id))
                .ToList();
            if (buildingsToRemove.Any())
            {
                _repository.RemoveBuildingRange(buildingsToRemove);
            }

            // Add new buildings
            foreach (var buildingDto in newBuildingDtos)
            {
                var newBuilding = MapDtoToBuilding(buildingDto);
                newBuilding.InspectionReportId = existingReport.InspectionReportId; // Link to parent
                existingReport.Buildings.Add(newBuilding); // Add to the collection for EF to track
                                                           // The repository's UpdateAsync will save these changes as part of the parent entity.
            }

            try
            {
                await _repository.UpdateAsync(existingReport);
                await _repository.SaveChangesAsync(); // Ensure all changes (add/remove/update buildings) are persisted
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!_repository.InspectionReportExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var inspectionReport = await _repository.GetByIdAsync(id);
            if (inspectionReport == null)
            {
                return false;
            }

            if (inspectionReport.Buildings.Any())
            {
                _repository.RemoveBuildingRange(inspectionReport.Buildings);
            }

            await _repository.DeleteAsync(inspectionReport);

            var report = await _repository.GetReportByIdAsync(inspectionReport.ReportId);
            if (report != null)
            {
                await _repository.DeleteReportAsync(report);
            }

            return true;
        }

        private InspectionReportResponseDto MapToResponseDto(InspectionReport report)
        {
            return new InspectionReportResponseDto
            {
                InspectionReportId = report.InspectionReportId,
                ReportId = report.ReportId,
                MasterFileId = report.MasterFileId,
                MasterFileRefNo = report.MasterFileRefNo,
                InspectionDate = report.InspectionDate,
                DsDivision = report.DsDivision,
                District = report.District,
                Province = report.Province,
                GnDivision = report.GnDivision,
                Village = report.Village,
                OtherInformation = report.OtherInformation,
                OtherConstructionDetails = report.OtherConstructionDetails,
                DetailsOfAssestsInventoryItems = report.DetailsOfAssestsInventoryItems,
                DetailsOfBusiness = report.DetailsOfBusiness,
                Remark = report.Remark,
                Buildings = report.Buildings.Select(b => new BuildingDto
                {
                    Id = b.Id,
                    BuildingId = b.BuildingId,
                    BuildingName = b.BuildingName,
                    BuildingCategory = b.BuildingCategory,
                    BuildingClass = b.BuildingClass,
                    DetailOfBuilding = b.DetailOfBuilding,
                    NoOfFloorsAboveGround = b.NoOfFloorsAboveGround,
                    NoOfFloorsBelowGround = b.NoOfFloorsBelowGround,
                    AgeYears = b.AgeYears,
                    ExpectedLifePeriodYears = b.ExpectedLifePeriodYears,
                    ParkingSpace = b.ParkingSpace,
                    Design = b.Design,
                    Conveniences = b.Conveniences,
                    Structure = b.Structure,
                    BuildingConditions = b.BuildingConditions,
                    NatureOfConstruction = b.NatureOfConstruction,
                    Condition = b.Condition,
                    RoofMaterial = b.RoofMaterial,
                    RoofFrame = b.RoofFrame,
                    RoofFinisher = b.RoofFinisher,
                    Ceiling = b.Ceiling,
                    FoundationStructure = b.FoundationStructure,
                    WallStructure = b.WallStructure,
                    FloorStructure = b.FloorStructure,
                    Door = b.Door,
                    Window = b.Window,
                    WindowProtection = b.WindowProtection,
                    BathroomToiletDoorsFittings = b.BathroomToiletDoorsFittings,
                    HandRail = b.HandRail,
                    PantryCupboard = b.PantryCupboard,
                    OtherDoors = b.OtherDoors,
                    WallFinisher = b.WallFinisher,
                    FloorFinisher = b.FloorFinisher,
                    BathroomToilet = b.BathroomToilet,
                    Services = b.Services
                }).ToList()
            };
        }

        private InspectionBuilding MapDtoToBuilding(BuildingDto dto)
        {
            return new InspectionBuilding
            {
                BuildingId = dto.BuildingId,
                BuildingName = dto.BuildingName,
                BuildingCategory = dto.BuildingCategory,
                BuildingClass = dto.BuildingClass,
                DetailOfBuilding = dto.DetailOfBuilding,
                NoOfFloorsAboveGround = dto.NoOfFloorsAboveGround,
                NoOfFloorsBelowGround = dto.NoOfFloorsBelowGround,
                AgeYears = dto.AgeYears,
                ExpectedLifePeriodYears = dto.ExpectedLifePeriodYears,
                ParkingSpace = dto.ParkingSpace,
                Design = dto.Design,
                Conveniences = dto.Conveniences,
                Structure = dto.Structure,
                BuildingConditions = dto.BuildingConditions,
                NatureOfConstruction = dto.NatureOfConstruction,
                Condition = dto.Condition,
                RoofMaterial = dto.RoofMaterial,
                RoofFrame = dto.RoofFrame,
                RoofFinisher = dto.RoofFinisher,
                Ceiling = dto.Ceiling,
                FoundationStructure = dto.FoundationStructure,
                WallStructure = dto.WallStructure,
                FloorStructure = dto.FloorStructure,
                Door = dto.Door,
                Window = dto.Window,
                WindowProtection = dto.WindowProtection,
                BathroomToiletDoorsFittings = dto.BathroomToiletDoorsFittings,
                HandRail = dto.HandRail,
                PantryCupboard = dto.PantryCupboard,
                OtherDoors = dto.OtherDoors,
                WallFinisher = dto.WallFinisher,
                FloorFinisher = dto.FloorFinisher,
                BathroomToilet = dto.BathroomToilet,
                Services = dto.Services
            };
        }

        private void UpdateBuildingFromDto(InspectionBuilding building, BuildingDto dto)
        {
            building.BuildingId = dto.BuildingId;
            building.BuildingName = dto.BuildingName;
            building.BuildingCategory = dto.BuildingCategory;
            building.BuildingClass = dto.BuildingClass;
            building.DetailOfBuilding = dto.DetailOfBuilding;
            building.NoOfFloorsAboveGround = dto.NoOfFloorsAboveGround;
            building.NoOfFloorsBelowGround = dto.NoOfFloorsBelowGround;
            building.AgeYears = dto.AgeYears;
            building.ExpectedLifePeriodYears = dto.ExpectedLifePeriodYears;
            building.ParkingSpace = dto.ParkingSpace;
            building.Design = dto.Design;
            building.Conveniences = dto.Conveniences;
            building.Structure = dto.Structure;
            building.BuildingConditions = dto.BuildingConditions;
            building.NatureOfConstruction = dto.NatureOfConstruction;
            building.Condition = dto.Condition;
            building.RoofMaterial = dto.RoofMaterial;
            building.RoofFrame = dto.RoofFrame;
            building.RoofFinisher = dto.RoofFinisher;
            building.Ceiling = dto.Ceiling;
            building.FoundationStructure = dto.FoundationStructure;
            building.WallStructure = dto.WallStructure;
            building.FloorStructure = dto.FloorStructure;
            building.Door = dto.Door;
            building.Window = dto.Window;
            building.WindowProtection = dto.WindowProtection;
            building.BathroomToiletDoorsFittings = dto.BathroomToiletDoorsFittings;
            building.HandRail = dto.HandRail;
            building.PantryCupboard = dto.PantryCupboard;
            building.OtherDoors = dto.OtherDoors;
            building.WallFinisher = dto.WallFinisher;
            building.FloorFinisher = dto.FloorFinisher;
            building.BathroomToilet = dto.BathroomToilet;
            building.Services = dto.Services;
        }
    }
}
