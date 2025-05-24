using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class ConditionReportService : IConditionReportService
    {
        private readonly IConditionReportRepository _repository;

        public ConditionReportService(IConditionReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ConditionReportResponseDto>> GetAllAsync()
        {
            var reports = await _repository.GetAllAsync();
            return reports.Select(MapToResponseDto).ToList();
        }

        public async Task<ConditionReportResponseDto> GetByIdAsync(int id)
        {
            var report = await _repository.GetByIdAsync(id);
            return report == null ? null : MapToResponseDto(report);
        }

        public async Task<ConditionReportResponseDto> GetByReportIdAsync(int reportId)
        {
            var report = await _repository.GetByReportIdAsync(reportId);
            return report == null ? null : MapToResponseDto(report);
        }

        public async Task<ConditionReportResponseDto> CreateAsync(ConditionReportCreateDto dto)
        {
            // Create a new Report for this condition report
            var report = new Report
            {
                ReportType = "LA_condition",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Acquisition Condition Report for {dto.MasterFileRefNo}"
            };

            // Add the report first
            report = await _repository.CreateReportAsync(report);

            // Create the condition report entity from the DTO
            var conditionReport = new ConditionReport
            {
                ReportId = report.ReportId,
                MasterFileId = dto.MasterFileId,
                MasterFileRefNo = dto.MasterFileRefNo,
                NameOfTheVillage = dto.NameOfTheVillage,
                NameOfTheLand = dto.NameOfTheLand,
                AtPlanNumber = dto.AtPlanNumber,
                AtLotNumber = dto.AtLotNumber,
                PpCadNumber = dto.PpCadNumber,
                PpCadLotNumber = dto.PpCadLotNumber,
                AcquiredExtent = dto.AcquiredExtent,
                AssessmentNumber = dto.AssessmentNumber,
                RoadName = dto.RoadName,
                AccessCategory = dto.AccessCategory,
                AccessCategoryDescription = dto.AccessCategoryDescription,
                DescriptionOfLand = dto.DescriptionOfLand,
                LandUseDescription = dto.LandUseDescription,
                LandUseType = dto.LandUseType,
                Frontage = dto.Frontage,
                DepthOfLand = dto.DepthOfLand,
                LevelWithAccess = dto.LevelWithAccess,
                PlantationDetails = dto.PlantationDetails,
                DetailsOfBusiness = dto.DetailsOfBusiness,
                AcquisitionName = dto.AcquisitionName,
                DatePrepared = dto.DatePrepared,
                DateOfSection3BA = dto.DateOfSection3BA,
                BoundaryNorth = dto.BoundaryNorth,
                BoundaryEast = dto.BoundaryEast,
                BoundaryWest = dto.BoundaryWest,
                BoundarySouth = dto.BoundarySouth,
                BoundaryBottom = dto.BoundaryBottom,
                BuildingDescription = dto.BuildingDescription,
                BuildingInfo = dto.BuildingInfo,
                OtherConstructionsDescription = dto.OtherConstructionsDescription,
                OtherConstructionsInfo = dto.OtherConstructionsInfo,
                AcquiringOfficerSignature = dto.AcquiringOfficerSignature,
                GramasewakaSignature = dto.GramasewakaSignature,
                ChiefValuerRepresentativeSignature = dto.ChiefValuerRepresentativeSignature,
                CreatedAt = DateTime.UtcNow
            };
            
            conditionReport = await _repository.CreateAsync(conditionReport);
            return MapToResponseDto(conditionReport);
        }

        public async Task<bool> UpdateAsync(int id, ConditionReportUpdateDto dto)
        {
            // Verify report exists
            var existingReport = await _repository.GetByIdAsync(id);

            if (existingReport == null)
            {
                return false;
            }

            // Update existing report with data from DTO
            existingReport.MasterFileId = dto.MasterFileId;
            existingReport.MasterFileRefNo = dto.MasterFileRefNo;
            existingReport.NameOfTheVillage = dto.NameOfTheVillage;
            existingReport.NameOfTheLand = dto.NameOfTheLand;
            existingReport.AtPlanNumber = dto.AtPlanNumber;
            existingReport.AtLotNumber = dto.AtLotNumber;
            existingReport.PpCadNumber = dto.PpCadNumber;
            existingReport.PpCadLotNumber = dto.PpCadLotNumber;
            existingReport.AcquiredExtent = dto.AcquiredExtent;
            existingReport.AssessmentNumber = dto.AssessmentNumber;
            existingReport.RoadName = dto.RoadName;
            existingReport.AccessCategory = dto.AccessCategory;
            existingReport.AccessCategoryDescription = dto.AccessCategoryDescription;
            existingReport.DescriptionOfLand = dto.DescriptionOfLand;
            existingReport.LandUseDescription = dto.LandUseDescription;
            existingReport.LandUseType = dto.LandUseType;
            existingReport.Frontage = dto.Frontage;
            existingReport.DepthOfLand = dto.DepthOfLand;
            existingReport.LevelWithAccess = dto.LevelWithAccess;
            existingReport.PlantationDetails = dto.PlantationDetails;
            existingReport.DetailsOfBusiness = dto.DetailsOfBusiness;
            existingReport.AcquisitionName = dto.AcquisitionName;
            existingReport.DatePrepared = dto.DatePrepared;
            existingReport.DateOfSection3BA = dto.DateOfSection3BA;
            existingReport.BoundaryNorth = dto.BoundaryNorth;
            existingReport.BoundaryEast = dto.BoundaryEast;
            existingReport.BoundaryWest = dto.BoundaryWest;
            existingReport.BoundarySouth = dto.BoundarySouth;
            existingReport.BoundaryBottom = dto.BoundaryBottom;
            existingReport.BuildingDescription = dto.BuildingDescription;
            existingReport.BuildingInfo = dto.BuildingInfo;
            existingReport.OtherConstructionsDescription = dto.OtherConstructionsDescription;
            existingReport.OtherConstructionsInfo = dto.OtherConstructionsInfo;
            existingReport.AcquiringOfficerSignature = dto.AcquiringOfficerSignature;
            existingReport.GramasewakaSignature = dto.GramasewakaSignature;
            existingReport.ChiefValuerRepresentativeSignature = dto.ChiefValuerRepresentativeSignature;

            return await _repository.UpdateAsync(existingReport);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private ConditionReportResponseDto MapToResponseDto(ConditionReport report)
        {
            return new ConditionReportResponseDto
            {
                Id = report.Id,
                ReportId = report.ReportId,
                MasterFileId = report.MasterFileId,
                MasterFileRefNo = report.MasterFileRefNo,
                NameOfTheVillage = report.NameOfTheVillage,
                NameOfTheLand = report.NameOfTheLand,
                AtPlanNumber = report.AtPlanNumber,
                AtLotNumber = report.AtLotNumber,
                PpCadNumber = report.PpCadNumber,
                PpCadLotNumber = report.PpCadLotNumber,
                AcquiredExtent = report.AcquiredExtent,
                AssessmentNumber = report.AssessmentNumber,
                RoadName = report.RoadName,
                AccessCategory = report.AccessCategory,
                AccessCategoryDescription = report.AccessCategoryDescription,
                DescriptionOfLand = report.DescriptionOfLand,
                LandUseDescription = report.LandUseDescription,
                LandUseType = report.LandUseType,
                Frontage = report.Frontage,
                DepthOfLand = report.DepthOfLand,
                LevelWithAccess = report.LevelWithAccess,
                PlantationDetails = report.PlantationDetails,
                DetailsOfBusiness = report.DetailsOfBusiness,
                AcquisitionName = report.AcquisitionName,
                DatePrepared = report.DatePrepared,
                DateOfSection3BA = report.DateOfSection3BA,
                BoundaryNorth = report.BoundaryNorth,
                BoundaryEast = report.BoundaryEast,
                BoundaryWest = report.BoundaryWest,
                BoundarySouth = report.BoundarySouth,
                BoundaryBottom = report.BoundaryBottom,
                BuildingDescription = report.BuildingDescription,
                BuildingInfo = report.BuildingInfo,
                OtherConstructionsDescription = report.OtherConstructionsDescription,
                OtherConstructionsInfo = report.OtherConstructionsInfo,
                AcquiringOfficerSignature = report.AcquiringOfficerSignature,
                GramasewakaSignature = report.GramasewakaSignature,
                ChiefValuerRepresentativeSignature = report.ChiefValuerRepresentativeSignature,
                CreatedAt = report.CreatedAt
            };
        }
    }
}
