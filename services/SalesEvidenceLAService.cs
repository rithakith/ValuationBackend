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
    public class SalesEvidenceLAService : ISalesEvidenceLAService
    {
        private readonly ISalesEvidenceLARepository _repository;
        private readonly AppDbContext _context;  // Temporarily needed for report creation

        public SalesEvidenceLAService(ISalesEvidenceLARepository repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IEnumerable<SalesEvidenceLAResponseDto>> GetAllSalesEvidencesAsync()
        {
            var salesEvidences = await _repository.GetAllAsync();
            return salesEvidences.Select(s => MapToResponseDto(s));
        }

        public async Task<SalesEvidenceLAResponseDto> GetSalesEvidenceByIdAsync(int id)
        {
            var salesEvidence = await _repository.GetByIdAsync(id);
            return salesEvidence != null ? MapToResponseDto(salesEvidence) : null;
        }

        public async Task<SalesEvidenceLAResponseDto> GetSalesEvidenceByReportIdAsync(int reportId)
        {
            var salesEvidence = await _repository.GetByReportIdAsync(reportId);
            return salesEvidence != null ? MapToResponseDto(salesEvidence) : null;
        }

        public async Task<SalesEvidenceLAResponseDto> CreateSalesEvidenceAsync(SalesEvidenceLACreateDto salesEvidenceDto)
        {
            // Create a new Report for this sales evidence
            var report = new Report
            {
                ReportType = "LA_sales_evidence",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Acquisition Sales Evidence for {salesEvidenceDto.MasterFileRefNo}"
            };

            // Add the report first
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            // Create the sales evidence entity from the DTO
            var salesEvidence = new SalesEvidenceLA
            {
                ReportId = report.ReportId,
                MasterFileId = salesEvidenceDto.MasterFileId,
                MasterFileRefNo = salesEvidenceDto.MasterFileRefNo,
                AssetNumber = salesEvidenceDto.AssetNumber,
                Road = salesEvidenceDto.Road,
                Village = salesEvidenceDto.Village,
                Owner = salesEvidenceDto.Owner,
                Occupier = salesEvidenceDto.Occupier,
                Vendor = salesEvidenceDto.Vendor,
                DeedNumber = salesEvidenceDto.DeedNumber,
                Description = salesEvidenceDto.Description,
                FloorRate = salesEvidenceDto.FloorRate,
                DeedAttestedNumber = salesEvidenceDto.DeedAttestedNumber,
                NotaryName = salesEvidenceDto.NotaryName,
                LotNumber = salesEvidenceDto.LotNumber,
                PlanNumber = salesEvidenceDto.PlanNumber,
                PlanDate = salesEvidenceDto.PlanDate,
                Extent = salesEvidenceDto.Extent,
                Consideration = salesEvidenceDto.Consideration,
                Remarks = salesEvidenceDto.Remarks,
                Rate = salesEvidenceDto.Rate,
                RateType = salesEvidenceDto.RateType,
                LocationLongitude = salesEvidenceDto.LocationLongitude,
                LocationLatitude = salesEvidenceDto.LocationLatitude,
                LandRegistryReferences = salesEvidenceDto.LandRegistryReferences,
                Situation = salesEvidenceDto.Situation,
                DescriptionOfProperty = salesEvidenceDto.DescriptionOfProperty,
                CreatedAt = DateTime.UtcNow
            };

            // Create entity through repository
            await _repository.CreateAsync(salesEvidence, report);
            return MapToResponseDto(salesEvidence);
        }

        public async Task<SalesEvidenceLAResponseDto> UpdateSalesEvidenceAsync(int id, SalesEvidenceLAUpdateDto salesEvidenceDto)
        {
            var existingSalesEvidence = await _repository.GetByIdAsync(id);
            if (existingSalesEvidence == null)
            {
                return null;
            }

            // Update existing evidence with data from DTO
            existingSalesEvidence.MasterFileId = salesEvidenceDto.MasterFileId;
            existingSalesEvidence.MasterFileRefNo = salesEvidenceDto.MasterFileRefNo;
            existingSalesEvidence.AssetNumber = salesEvidenceDto.AssetNumber;
            existingSalesEvidence.Road = salesEvidenceDto.Road;
            existingSalesEvidence.Village = salesEvidenceDto.Village;
            existingSalesEvidence.Owner = salesEvidenceDto.Owner;
            existingSalesEvidence.Occupier = salesEvidenceDto.Occupier;
            existingSalesEvidence.Vendor = salesEvidenceDto.Vendor;
            existingSalesEvidence.DeedNumber = salesEvidenceDto.DeedNumber;
            existingSalesEvidence.Description = salesEvidenceDto.Description;
            existingSalesEvidence.FloorRate = salesEvidenceDto.FloorRate;
            existingSalesEvidence.DeedAttestedNumber = salesEvidenceDto.DeedAttestedNumber;
            existingSalesEvidence.NotaryName = salesEvidenceDto.NotaryName;
            existingSalesEvidence.LotNumber = salesEvidenceDto.LotNumber;
            existingSalesEvidence.PlanNumber = salesEvidenceDto.PlanNumber;
            existingSalesEvidence.PlanDate = salesEvidenceDto.PlanDate;
            existingSalesEvidence.Extent = salesEvidenceDto.Extent;
            existingSalesEvidence.Consideration = salesEvidenceDto.Consideration;
            existingSalesEvidence.Remarks = salesEvidenceDto.Remarks;
            existingSalesEvidence.Rate = salesEvidenceDto.Rate;
            existingSalesEvidence.RateType = salesEvidenceDto.RateType;
            existingSalesEvidence.LocationLongitude = salesEvidenceDto.LocationLongitude;
            existingSalesEvidence.LocationLatitude = salesEvidenceDto.LocationLatitude;
            existingSalesEvidence.LandRegistryReferences = salesEvidenceDto.LandRegistryReferences;
            existingSalesEvidence.Situation = salesEvidenceDto.Situation;
            existingSalesEvidence.DescriptionOfProperty = salesEvidenceDto.DescriptionOfProperty;
            existingSalesEvidence.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(existingSalesEvidence);
            return MapToResponseDto(existingSalesEvidence);
        }

        public async Task<bool> DeleteSalesEvidenceAsync(int id)
        {
            var salesEvidence = await _repository.GetByIdAsync(id);
            if (salesEvidence == null)
            {
                return false;
            }

            // Also delete the associated report
            var report = await _context.Reports.FindAsync(salesEvidence.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            await _repository.DeleteAsync(salesEvidence);
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }

        private SalesEvidenceLAResponseDto MapToResponseDto(SalesEvidenceLA evidence)
        {
            return new SalesEvidenceLAResponseDto
            {
                Id = evidence.Id,
                ReportId = evidence.ReportId,
                MasterFileId = evidence.MasterFileId,
                MasterFileRefNo = evidence.MasterFileRefNo,
                AssetNumber = evidence.AssetNumber,
                Road = evidence.Road,
                Village = evidence.Village,
                Owner = evidence.Owner,
                Occupier = evidence.Occupier,
                Vendor = evidence.Vendor,
                DeedNumber = evidence.DeedNumber,
                Description = evidence.Description,
                FloorRate = evidence.FloorRate,
                DeedAttestedNumber = evidence.DeedAttestedNumber,
                NotaryName = evidence.NotaryName,
                LotNumber = evidence.LotNumber,
                PlanNumber = evidence.PlanNumber,
                PlanDate = evidence.PlanDate,
                Extent = evidence.Extent,
                Consideration = evidence.Consideration,
                Remarks = evidence.Remarks,
                Rate = evidence.Rate,
                RateType = evidence.RateType,
                LocationLongitude = evidence.LocationLongitude,
                LocationLatitude = evidence.LocationLatitude,
                LandRegistryReferences = evidence.LandRegistryReferences,
                Situation = evidence.Situation,
                DescriptionOfProperty = evidence.DescriptionOfProperty,
                CreatedAt = evidence.CreatedAt,
                UpdatedAt = evidence.UpdatedAt
            };
        }
    }
}
