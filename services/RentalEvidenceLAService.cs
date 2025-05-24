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
    public class RentalEvidenceLAService : IRentalEvidenceLAService
    {
        private readonly IRentalEvidenceLARepository _repository;
        private readonly AppDbContext _context;  // Temporarily needed for report lookup

        public RentalEvidenceLAService(IRentalEvidenceLARepository repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IEnumerable<RentalEvidenceLAResponseDto>> GetAllRentalEvidencesAsync()
        {
            var rentalEvidences = await _repository.GetAllAsync();
            return rentalEvidences.Select(r => MapToResponseDto(r));
        }

        public async Task<RentalEvidenceLAResponseDto> GetRentalEvidenceByIdAsync(int id)
        {
            var rentalEvidence = await _repository.GetByIdAsync(id);
            return rentalEvidence != null ? MapToResponseDto(rentalEvidence) : null;
        }

        public async Task<RentalEvidenceLAResponseDto> GetRentalEvidenceByReportIdAsync(int reportId)
        {
            var rentalEvidence = await _repository.GetByReportIdAsync(reportId);
            return rentalEvidence != null ? MapToResponseDto(rentalEvidence) : null;
        }

        public async Task<RentalEvidenceLAResponseDto> CreateRentalEvidenceAsync(RentalEvidenceLACreateDto rentalEvidenceDto)
        {
            // Create a new Report for this rental evidence
            var report = new Report
            {
                ReportType = "LA_rental_evidence",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Acquisition Rental Evidence for {rentalEvidenceDto.MasterFileRefNo}"
            };

            // Add the report first
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            // Create the rental evidence entity from the DTO
            var rentalEvidence = new RentalEvidenceLA
            {
                ReportId = report.ReportId,
                MasterFileId = rentalEvidenceDto.MasterFileId,
                MasterFileRefNo = rentalEvidenceDto.MasterFileRefNo,
                AssessmentNo = rentalEvidenceDto.AssessmentNo,
                Owner = rentalEvidenceDto.Owner,
                Occupier = rentalEvidenceDto.Occupier,
                Description = rentalEvidenceDto.Description,
                FloorRateSQFT = rentalEvidenceDto.FloorRateSQFT,
                RatePerSqft = rentalEvidenceDto.RatePerSqft,
                RatePerMonth = rentalEvidenceDto.RatePerMonth,
                LocationLongitude = rentalEvidenceDto.LocationLongitude,
                LocationLatitude = rentalEvidenceDto.LocationLatitude,
                HeadOfTerms = rentalEvidenceDto.HeadOfTerms,
                Situation = rentalEvidenceDto.Situation,
                Remarks = rentalEvidenceDto.Remarks,
                CreatedAt = DateTime.UtcNow
            };

            // Create entity through repository
            await _repository.CreateAsync(rentalEvidence, report);
            return MapToResponseDto(rentalEvidence);
        }

        public async Task<RentalEvidenceLAResponseDto> UpdateRentalEvidenceAsync(int id, RentalEvidenceLAUpdateDto rentalEvidenceDto)
        {
            var existingRentalEvidence = await _repository.GetByIdAsync(id);
            if (existingRentalEvidence == null)
            {
                return null;
            }

            // Update existing evidence with data from DTO
            existingRentalEvidence.MasterFileId = rentalEvidenceDto.MasterFileId;
            existingRentalEvidence.MasterFileRefNo = rentalEvidenceDto.MasterFileRefNo;
            existingRentalEvidence.AssessmentNo = rentalEvidenceDto.AssessmentNo;
            existingRentalEvidence.Owner = rentalEvidenceDto.Owner;
            existingRentalEvidence.Occupier = rentalEvidenceDto.Occupier;
            existingRentalEvidence.Description = rentalEvidenceDto.Description;
            existingRentalEvidence.FloorRateSQFT = rentalEvidenceDto.FloorRateSQFT;
            existingRentalEvidence.RatePerSqft = rentalEvidenceDto.RatePerSqft;
            existingRentalEvidence.RatePerMonth = rentalEvidenceDto.RatePerMonth;
            existingRentalEvidence.LocationLongitude = rentalEvidenceDto.LocationLongitude;
            existingRentalEvidence.LocationLatitude = rentalEvidenceDto.LocationLatitude;
            existingRentalEvidence.HeadOfTerms = rentalEvidenceDto.HeadOfTerms;
            existingRentalEvidence.Situation = rentalEvidenceDto.Situation;
            existingRentalEvidence.Remarks = rentalEvidenceDto.Remarks;
            existingRentalEvidence.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(existingRentalEvidence);
            return MapToResponseDto(existingRentalEvidence);
        }

        public async Task<bool> DeleteRentalEvidenceAsync(int id)
        {
            var rentalEvidence = await _repository.GetByIdAsync(id);
            if (rentalEvidence == null)
            {
                return false;
            }

            // Also delete the associated report
            var report = await _context.Reports.FindAsync(rentalEvidence.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            await _repository.DeleteAsync(rentalEvidence);
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }

        private RentalEvidenceLAResponseDto MapToResponseDto(RentalEvidenceLA evidence)
        {
            return new RentalEvidenceLAResponseDto
            {
                Id = evidence.Id,
                ReportId = evidence.ReportId,
                MasterFileId = evidence.MasterFileId,
                MasterFileRefNo = evidence.MasterFileRefNo,
                AssessmentNo = evidence.AssessmentNo,
                Owner = evidence.Owner,
                Occupier = evidence.Occupier,
                Description = evidence.Description,
                FloorRateSQFT = evidence.FloorRateSQFT,
                RatePerSqft = evidence.RatePerSqft,
                RatePerMonth = evidence.RatePerMonth,
                LocationLongitude = evidence.LocationLongitude,
                LocationLatitude = evidence.LocationLatitude,
                HeadOfTerms = evidence.HeadOfTerms,
                Situation = evidence.Situation,
                Remarks = evidence.Remarks,
                CreatedAt = evidence.CreatedAt,
                UpdatedAt = evidence.UpdatedAt
            };
        }
    }
}
