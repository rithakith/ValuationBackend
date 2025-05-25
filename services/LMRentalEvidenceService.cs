using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class LMRentalEvidenceService : ILMRentalEvidenceService
    {
        private readonly ILMRentalEvidenceRepository _repository;

        public LMRentalEvidenceService(ILMRentalEvidenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LMRentalEvidenceResponseDto>> GetAllAsync()
        {
            var lmRentalEvidences = await _repository.GetAllAsync();
            return lmRentalEvidences.Select(MapToResponseDto).ToList();
        }

        public async Task<LMRentalEvidenceResponseDto> GetByIdAsync(int id)
        {
            var lmRentalEvidence = await _repository.GetByIdAsync(id);
            return lmRentalEvidence == null ? null : MapToResponseDto(lmRentalEvidence);
        }

        public async Task<LMRentalEvidenceResponseDto> GetByReportIdAsync(int reportId)
        {
            var lmRentalEvidence = await _repository.GetByReportIdAsync(reportId);
            return lmRentalEvidence == null ? null : MapToResponseDto(lmRentalEvidence);
        }

        public async Task<LMRentalEvidenceResponseDto> CreateAsync(LMRentalEvidenceCreateDto dto)
        {
            // Create a new Report for this LM rental evidence
            var report = new Report
            {
                ReportType = "LM_RentalEvidence",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Miscellaneous Rental Evidence for {dto.MasterFileRefNo}"
            };

            // Add the report first
            report = await _repository.CreateReportAsync(report);

            // Create the LM rental evidence entity from the DTO
            var lmRentalEvidence = new LMRentalEvidence
            {
                ReportId = report.ReportId,
                MasterFileRefNo = dto.MasterFileRefNo,
                AssessmentNo = dto.AssessmentNo,
                Owner = dto.Owner,
                Occupier = dto.Occupier,
                Description = dto.Description,
                FloorRate = dto.FloorRate,
                RatePer = dto.RatePer,
                RatePerMonth = dto.RatePerMonth,
                LocationLongitude = dto.LocationLongitude,
                LocationLatitude = dto.LocationLatitude,
                HeadOfTerms = dto.HeadOfTerms,
                Situation = dto.Situation,
                Remarks = dto.Remarks
            };

            lmRentalEvidence = await _repository.CreateAsync(lmRentalEvidence);
            return MapToResponseDto(lmRentalEvidence);
        }

        public async Task<bool> UpdateAsync(int reportId, LMRentalEvidenceUpdateDto dto)
        {
            // Verify LM rental evidence exists
            var existingLMRentalEvidence = await _repository.GetByReportIdAsync(reportId);

            if (existingLMRentalEvidence == null)
            {
                return false;
            }

            // Update existing LM rental evidence with data from DTO
            existingLMRentalEvidence.MasterFileRefNo = dto.MasterFileRefNo;
            existingLMRentalEvidence.AssessmentNo = dto.AssessmentNo;
            existingLMRentalEvidence.Owner = dto.Owner;
            existingLMRentalEvidence.Occupier = dto.Occupier;
            existingLMRentalEvidence.Description = dto.Description;
            existingLMRentalEvidence.FloorRate = dto.FloorRate;
            existingLMRentalEvidence.RatePer = dto.RatePer;
            existingLMRentalEvidence.RatePerMonth = dto.RatePerMonth;
            existingLMRentalEvidence.LocationLongitude = dto.LocationLongitude;
            existingLMRentalEvidence.LocationLatitude = dto.LocationLatitude;
            existingLMRentalEvidence.HeadOfTerms = dto.HeadOfTerms;
            existingLMRentalEvidence.Situation = dto.Situation;
            existingLMRentalEvidence.Remarks = dto.Remarks;

            return await _repository.UpdateAsync(existingLMRentalEvidence);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private LMRentalEvidenceResponseDto MapToResponseDto(LMRentalEvidence lmRentalEvidence)
        {
            return new LMRentalEvidenceResponseDto
            {
                Id = lmRentalEvidence.Id,
                ReportId = lmRentalEvidence.ReportId,
                MasterFileRefNo = lmRentalEvidence.MasterFileRefNo,
                AssessmentNo = lmRentalEvidence.AssessmentNo,
                Owner = lmRentalEvidence.Owner,
                Occupier = lmRentalEvidence.Occupier,
                Description = lmRentalEvidence.Description,
                FloorRate = lmRentalEvidence.FloorRate,
                RatePer = lmRentalEvidence.RatePer,
                RatePerMonth = lmRentalEvidence.RatePerMonth,
                LocationLongitude = lmRentalEvidence.LocationLongitude,
                LocationLatitude = lmRentalEvidence.LocationLatitude,
                HeadOfTerms = lmRentalEvidence.HeadOfTerms,
                Situation = lmRentalEvidence.Situation,
                Remarks = lmRentalEvidence.Remarks
            };
        }
    }
}
