using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class LMBuildingRatesService : ILMBuildingRatesService
    {
        private readonly ILMBuildingRatesRepository _repository;

        public LMBuildingRatesService(ILMBuildingRatesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LMBuildingRatesResponseDto>> GetAllAsync()
        {
            var lmBuildingRates = await _repository.GetAllAsync();
            return lmBuildingRates.Select(MapToResponseDto).ToList();
        }

        public async Task<LMBuildingRatesResponseDto> GetByIdAsync(int id)
        {
            var lmBuildingRate = await _repository.GetByIdAsync(id);
            return lmBuildingRate == null ? null : MapToResponseDto(lmBuildingRate);
        }

        public async Task<LMBuildingRatesResponseDto> GetByReportIdAsync(int reportId)
        {
            var lmBuildingRate = await _repository.GetByReportIdAsync(reportId);
            return lmBuildingRate == null ? null : MapToResponseDto(lmBuildingRate);
        }

        public async Task<LMBuildingRatesResponseDto> CreateAsync(LMBuildingRatesCreateDto dto)
        {
            // Create a new Report for this LM building rate
            var report = new Report
            {
                ReportType = "LM_BuildingRates",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Miscellaneous Building Rates for {dto.MasterFileRefNo}"
            };

            // Add the report first
            report = await _repository.CreateReportAsync(report);

            // Create the LM building rate entity from the DTO
            var lmBuildingRate = new LMBuildingRates
            {
                ReportId = report.ReportId,
                MasterFileRefNo = dto.MasterFileRefNo,
                AssessmentNumber = dto.AssessmentNumber,
                Owner = dto.Owner,
                ConstructedBy = dto.ConstructedBy,
                YearOfConstruction = dto.YearOfConstruction,
                DescriptionOfProperty = dto.DescriptionOfProperty,
                FloorArea = dto.FloorArea,
                RatePerSQFT = dto.RatePerSQFT,
                Cost = dto.Cost,
                Remarks = dto.Remarks,
                LocationLatitude = dto.LocationLatitude,
                LocationLongitude = dto.LocationLongitude
            };

            lmBuildingRate = await _repository.CreateAsync(lmBuildingRate);
            return MapToResponseDto(lmBuildingRate);
        }

        public async Task<bool> UpdateAsync(int reportId, LMBuildingRatesUpdateDto dto)
        {
            // Verify LM building rate exists
            var existingLMBuildingRate = await _repository.GetByReportIdAsync(reportId);

            if (existingLMBuildingRate == null)
            {
                return false;
            }

            // Update existing LM building rate with data from DTO
            existingLMBuildingRate.MasterFileRefNo = dto.MasterFileRefNo;
            existingLMBuildingRate.AssessmentNumber = dto.AssessmentNumber;
            existingLMBuildingRate.Owner = dto.Owner;
            existingLMBuildingRate.ConstructedBy = dto.ConstructedBy;
            existingLMBuildingRate.YearOfConstruction = dto.YearOfConstruction;
            existingLMBuildingRate.DescriptionOfProperty = dto.DescriptionOfProperty;
            existingLMBuildingRate.FloorArea = dto.FloorArea;
            existingLMBuildingRate.RatePerSQFT = dto.RatePerSQFT;
            existingLMBuildingRate.Cost = dto.Cost;
            existingLMBuildingRate.Remarks = dto.Remarks;
            existingLMBuildingRate.LocationLatitude = dto.LocationLatitude;
            existingLMBuildingRate.LocationLongitude = dto.LocationLongitude;

            return await _repository.UpdateAsync(existingLMBuildingRate);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private LMBuildingRatesResponseDto MapToResponseDto(LMBuildingRates lmBuildingRate)
        {
            return new LMBuildingRatesResponseDto
            {
                Id = lmBuildingRate.Id,
                ReportId = lmBuildingRate.ReportId,
                MasterFileRefNo = lmBuildingRate.MasterFileRefNo,
                AssessmentNumber = lmBuildingRate.AssessmentNumber,
                Owner = lmBuildingRate.Owner,
                ConstructedBy = lmBuildingRate.ConstructedBy,
                YearOfConstruction = lmBuildingRate.YearOfConstruction,
                DescriptionOfProperty = lmBuildingRate.DescriptionOfProperty,
                FloorArea = lmBuildingRate.FloorArea,
                RatePerSQFT = lmBuildingRate.RatePerSQFT,
                Cost = lmBuildingRate.Cost,
                Remarks = lmBuildingRate.Remarks,
                LocationLatitude = lmBuildingRate.LocationLatitude,
                LocationLongitude = lmBuildingRate.LocationLongitude
            };
        }
    }
}
