using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class BuildingRatesLAService : IBuildingRatesLAService
    {
        private readonly IBuildingRatesLARepository _repository;

        public BuildingRatesLAService(IBuildingRatesLARepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BuildingRatesLAResponseDto>> GetAllAsync()
        {
            var buildingRates = await _repository.GetAllAsync();
            return buildingRates.Select(MapToResponseDto).ToList();
        }

        public async Task<BuildingRatesLAResponseDto> GetByIdAsync(int id)
        {
            var buildingRate = await _repository.GetByIdAsync(id);
            return buildingRate == null ? null : MapToResponseDto(buildingRate);
        }

        public async Task<BuildingRatesLAResponseDto> GetByReportIdAsync(int reportId)
        {
            var buildingRate = await _repository.GetByReportIdAsync(reportId);
            return buildingRate == null ? null : MapToResponseDto(buildingRate);
        }

        public async Task<BuildingRatesLAResponseDto> CreateAsync(BuildingRatesLACreateDto dto)
        {
            // Create a new Report for this building rate
            var report = new Report
            {
                ReportType = "LA_building_rate",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Acquisition Building Rate for {dto.MasterFileId}"
            };

            // Add the report first
            report = await _repository.CreateReportAsync(report);

            // Create the building rate entity from the DTO
            var buildingRate = new BuildingRatesLA
            {
                ReportId = report.ReportId,
                MasterFileId = dto.MasterFileId,
                AssessmentNumber = dto.AssessmentNumber,
                Owner = dto.Owner,
                ConstructedBy = dto.ConstructedBy,
                YearOfConstruction = dto.YearOfConstruction,
                DescriptionOfProperty = dto.DescriptionOfProperty,
                FloorAreaSQFT = dto.FloorAreaSQFT,
                RatePerSQFT = dto.RatePerSQFT,
                Cost = dto.Cost,
                Remarks = dto.Remarks,
                LocationLatitude = dto.LocationLatitude,
                LocationLongitude = dto.LocationLongitude,
                CreatedAt = DateTime.UtcNow
            };
            
            buildingRate = await _repository.CreateAsync(buildingRate);
            return MapToResponseDto(buildingRate);
        }

        public async Task<bool> UpdateAsync(int id, BuildingRatesLAUpdateDto dto)
        {
            // Verify building rate exists
            var existingBuildingRate = await _repository.GetByIdAsync(id);

            if (existingBuildingRate == null)
            {
                return false;
            }

            // Update existing building rate with data from DTO
            existingBuildingRate.MasterFileId = dto.MasterFileId;
            existingBuildingRate.AssessmentNumber = dto.AssessmentNumber;
            existingBuildingRate.Owner = dto.Owner;
            existingBuildingRate.ConstructedBy = dto.ConstructedBy;
            existingBuildingRate.YearOfConstruction = dto.YearOfConstruction;
            existingBuildingRate.DescriptionOfProperty = dto.DescriptionOfProperty;
            existingBuildingRate.FloorAreaSQFT = dto.FloorAreaSQFT;
            existingBuildingRate.RatePerSQFT = dto.RatePerSQFT;
            existingBuildingRate.Cost = dto.Cost;
            existingBuildingRate.Remarks = dto.Remarks;
            existingBuildingRate.LocationLatitude = dto.LocationLatitude;
            existingBuildingRate.LocationLongitude = dto.LocationLongitude;
            existingBuildingRate.UpdatedAt = DateTime.UtcNow;

            return await _repository.UpdateAsync(existingBuildingRate);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private BuildingRatesLAResponseDto MapToResponseDto(BuildingRatesLA buildingRate)
        {
            return new BuildingRatesLAResponseDto
            {
                Id = buildingRate.Id,
                ReportId = buildingRate.ReportId,
                MasterFileId = buildingRate.MasterFileId,
                AssessmentNumber = buildingRate.AssessmentNumber,
                Owner = buildingRate.Owner,
                ConstructedBy = buildingRate.ConstructedBy,
                YearOfConstruction = buildingRate.YearOfConstruction,
                DescriptionOfProperty = buildingRate.DescriptionOfProperty,
                FloorAreaSQFT = buildingRate.FloorAreaSQFT,
                RatePerSQFT = buildingRate.RatePerSQFT,
                Cost = buildingRate.Cost,
                Remarks = buildingRate.Remarks,
                LocationLatitude = buildingRate.LocationLatitude,
                LocationLongitude = buildingRate.LocationLongitude,
                CreatedAt = buildingRate.CreatedAt,
                UpdatedAt = buildingRate.UpdatedAt
            };
        }
    }
}
