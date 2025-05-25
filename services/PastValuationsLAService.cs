using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Repositories;
using ValuationBackend.Data;

namespace ValuationBackend.Services
{
    public class PastValuationsLAService : IPastValuationsLAService
    {
        private readonly IPastValuationsLARepository _repository;
        private readonly AppDbContext _context;  // Temporarily needed for report lookup

        public PastValuationsLAService(IPastValuationsLARepository repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IEnumerable<PastValuationsLAReadDto>> GetAllPastValuationsAsync()
        {
            var pastValuations = await _repository.GetAllAsync();
            return pastValuations.Select(p => MapToReadDto(p));
        }

        public async Task<PastValuationsLAReadDto?> GetPastValuationByIdAsync(int id)
        {
            var pastValuation = await _repository.GetByIdAsync(id);
            return pastValuation != null ? MapToReadDto(pastValuation) : null;
        }

        public async Task<PastValuationsLAReadDto?> GetPastValuationByReportIdAsync(int reportId)
        {
            var pastValuation = await _repository.GetByReportIdAsync(reportId);
            return pastValuation != null ? MapToReadDto(pastValuation) : null;
        }

        public async Task<PastValuationsLAReadDto> CreatePastValuationAsync(PastValuationsLACreateDto pastValuationDto)
        {
            // Create a new Report for this past valuation
            var report = new Report
            {
                ReportType = "LA_past_valuations",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Acquisition Past Valuations for {pastValuationDto.MasterFileRefNo}"
            };

            // Add the report first
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            // Map DTO to entity
            var pastValuation = new PastValuationsLA
            {
                ReportId = report.ReportId,
                MasterFileId = pastValuationDto.MasterFileId,
                MasterFileRefNo = pastValuationDto.MasterFileRefNo,
                FileNoGNDivision = pastValuationDto.FileNoGNDivision,
                Situation = pastValuationDto.Situation,
                DateOfValuation = pastValuationDto.DateOfValuation,
                PurposeOfValuation = pastValuationDto.PurposeOfValuation,
                PlanOfParticulars = pastValuationDto.PlanOfParticulars,
                Extent = pastValuationDto.Extent,
                Rate = pastValuationDto.Rate,
                RateType = pastValuationDto.RateType,
                Remarks = pastValuationDto.Remarks,
                LocationLongitude = pastValuationDto.LocationLongitude,
                LocationLatitude = pastValuationDto.LocationLatitude,
                CreatedAt = DateTime.UtcNow
            };

            // Create entity
            await _repository.CreateAsync(pastValuation, report);
            return MapToReadDto(pastValuation);
        }

        public async Task<PastValuationsLAReadDto?> UpdatePastValuationAsync(int id, PastValuationsLAUpdateDto pastValuationDto)
        {
            var existingPastValuation = await _repository.GetByIdAsync(id);
            if (existingPastValuation == null)
            {
                return null;
            }

            // Update properties
            existingPastValuation.MasterFileId = pastValuationDto.MasterFileId;
            existingPastValuation.MasterFileRefNo = pastValuationDto.MasterFileRefNo;
            existingPastValuation.FileNoGNDivision = pastValuationDto.FileNoGNDivision;
            existingPastValuation.Situation = pastValuationDto.Situation;
            existingPastValuation.DateOfValuation = pastValuationDto.DateOfValuation;
            existingPastValuation.PurposeOfValuation = pastValuationDto.PurposeOfValuation;
            existingPastValuation.PlanOfParticulars = pastValuationDto.PlanOfParticulars;
            existingPastValuation.Extent = pastValuationDto.Extent;
            existingPastValuation.Rate = pastValuationDto.Rate;
            existingPastValuation.RateType = pastValuationDto.RateType;
            existingPastValuation.Remarks = pastValuationDto.Remarks;
            existingPastValuation.LocationLongitude = pastValuationDto.LocationLongitude;
            existingPastValuation.LocationLatitude = pastValuationDto.LocationLatitude;
            existingPastValuation.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(existingPastValuation);
            return MapToReadDto(existingPastValuation);
        }

        public async Task<bool> DeletePastValuationAsync(int id)
        {
            var pastValuation = await _repository.GetByIdAsync(id);
            if (pastValuation == null)
            {
                return false;
            }

            await _repository.DeleteAsync(pastValuation);
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }

        private PastValuationsLAReadDto MapToReadDto(PastValuationsLA pastValuation)
        {
            return new PastValuationsLAReadDto
            {
                Id = pastValuation.Id,
                ReportId = pastValuation.ReportId,
                MasterFileId = pastValuation.MasterFileId,
                MasterFileRefNo = pastValuation.MasterFileRefNo,
                FileNoGNDivision = pastValuation.FileNoGNDivision,
                Situation = pastValuation.Situation,
                DateOfValuation = pastValuation.DateOfValuation,
                PurposeOfValuation = pastValuation.PurposeOfValuation,
                PlanOfParticulars = pastValuation.PlanOfParticulars,
                Extent = pastValuation.Extent,
                Rate = pastValuation.Rate,
                RateType = pastValuation.RateType,
                Remarks = pastValuation.Remarks,
                LocationLongitude = pastValuation.LocationLongitude,
                LocationLatitude = pastValuation.LocationLatitude,
                CreatedAt = pastValuation.CreatedAt,
                UpdatedAt = pastValuation.UpdatedAt
            };
        }
    }
}
