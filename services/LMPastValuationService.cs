using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class LMPastValuationService : ILMPastValuationService
    {
        private readonly ILMPastValuationRepository _repository;

        public LMPastValuationService(ILMPastValuationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LMPastValuationResponseDto>> GetAllAsync()
        {
            var lmPastValuations = await _repository.GetAllAsync();
            return lmPastValuations.Select(MapToResponseDto).ToList();
        }

        public async Task<LMPastValuationResponseDto> GetByIdAsync(int id)
        {
            var lmPastValuation = await _repository.GetByIdAsync(id);
            return lmPastValuation == null ? null : MapToResponseDto(lmPastValuation);
        }

        public async Task<LMPastValuationResponseDto> GetByReportIdAsync(int reportId)
        {
            var lmPastValuation = await _repository.GetByReportIdAsync(reportId);
            return lmPastValuation == null ? null : MapToResponseDto(lmPastValuation);
        }

        public async Task<LMPastValuationResponseDto> CreateAsync(LMPastValuationCreateDto dto)
        {
            // Create a new Report for this LM past valuation
            var report = new Report
            {
                ReportType = "LM_PastValuation",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Miscellaneous Past Valuation for {dto.MasterFileRefNo}"
            };

            // Add the report first
            report = await _repository.CreateReportAsync(report);

            // Create the LM past valuation entity from the DTO
            var lmPastValuation = new LMPastValuation
            {
                ReportId = report.ReportId,
                MasterFileRefNo = dto.MasterFileRefNo,
                FileNo_GnDivision = dto.FileNo_GnDivision,
                Situation = dto.Situation,
                DateOfValuation = dto.DateOfValuation,
                PurposeOfValuation = dto.PurposeOfValuation,
                PlanOfParticulars = dto.PlanOfParticulars,
                Extent = dto.Extent,
                Rate = dto.Rate,
                RateType = dto.RateType,
                Remarks = dto.Remarks,
                LocationLongitude = dto.LocationLongitude,
                LocationLatitude = dto.LocationLatitude
            };

            lmPastValuation = await _repository.CreateAsync(lmPastValuation);
            return MapToResponseDto(lmPastValuation);
        }

        public async Task<bool> UpdateAsync(int reportId, LMPastValuationUpdateDto dto)
        {
            // Verify LM past valuation exists
            var existingLMPastValuation = await _repository.GetByReportIdAsync(reportId);

            if (existingLMPastValuation == null)
            {
                return false;
            }

            // Update existing LM past valuation with data from DTO
            existingLMPastValuation.MasterFileRefNo = dto.MasterFileRefNo;
            existingLMPastValuation.FileNo_GnDivision = dto.FileNo_GnDivision;
            existingLMPastValuation.Situation = dto.Situation;
            existingLMPastValuation.DateOfValuation = dto.DateOfValuation;
            existingLMPastValuation.PurposeOfValuation = dto.PurposeOfValuation;
            existingLMPastValuation.PlanOfParticulars = dto.PlanOfParticulars;
            existingLMPastValuation.Extent = dto.Extent;
            existingLMPastValuation.Rate = dto.Rate;
            existingLMPastValuation.RateType = dto.RateType;
            existingLMPastValuation.Remarks = dto.Remarks;
            existingLMPastValuation.LocationLongitude = dto.LocationLongitude;
            existingLMPastValuation.LocationLatitude = dto.LocationLatitude;

            return await _repository.UpdateAsync(existingLMPastValuation);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private LMPastValuationResponseDto MapToResponseDto(LMPastValuation lmPastValuation)
        {
            return new LMPastValuationResponseDto
            {
                Id = lmPastValuation.Id,
                ReportId = lmPastValuation.ReportId,
                MasterFileRefNo = lmPastValuation.MasterFileRefNo,
                FileNo_GnDivision = lmPastValuation.FileNo_GnDivision,
                Situation = lmPastValuation.Situation,
                DateOfValuation = lmPastValuation.DateOfValuation,
                PurposeOfValuation = lmPastValuation.PurposeOfValuation,
                PlanOfParticulars = lmPastValuation.PlanOfParticulars,
                Extent = lmPastValuation.Extent,
                Rate = lmPastValuation.Rate,
                RateType = lmPastValuation.RateType,
                Remarks = lmPastValuation.Remarks,
                LocationLongitude = lmPastValuation.LocationLongitude,
                LocationLatitude = lmPastValuation.LocationLatitude
            };
        }
    }
}
