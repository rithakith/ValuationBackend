using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Repositories;

namespace ValuationBackend.Services
{
    public class LMSalesEvidenceService : ILMSalesEvidenceService
    {
        private readonly ILMSalesEvidenceRepository _repository;

        public LMSalesEvidenceService(ILMSalesEvidenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LMSalesEvidenceResponseDto>> GetAllAsync()
        {
            var lmSalesEvidences = await _repository.GetAllAsync();
            return lmSalesEvidences.Select(MapToResponseDto).ToList();
        }

        public async Task<LMSalesEvidenceResponseDto> GetByIdAsync(int id)
        {
            var lmSalesEvidence = await _repository.GetByIdWithMasterFileAsync(id);
            return lmSalesEvidence == null ? null : MapToResponseDto(lmSalesEvidence);
        }

        public async Task<IEnumerable<LMSalesEvidenceResponseDto>> GetByMasterFileIdAsync(int masterFileId)
        {
            var lmSalesEvidences = await _repository.GetByMasterFileIdAsync(masterFileId);
            return lmSalesEvidences.Select(MapToResponseDto).ToList();
        }

        public async Task<LMSalesEvidenceResponseDto> GetByReportIdAsync(int reportId)
        {
            var lmSalesEvidence = await _repository.GetByReportIdAsync(reportId);
            return lmSalesEvidence == null ? null : MapToResponseDto(lmSalesEvidence);
        }

        public async Task<LMSalesEvidenceResponseDto> CreateAsync(LMSalesEvidenceCreateDto dto)
        {
            // Create a new Report for this LM sales evidence
            var report = new Report
            {
                ReportType = "LM_SalesEvidence",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Miscellaneous Sales Evidence for {dto.MasterFileRefNo}"
            };

            // Add the report first
            report = await _repository.CreateReportAsync(report);

            // Create the LM sales evidence entity from the DTO
            var lmSalesEvidence = new LMSalesEvidence
            {
                ReportId = report.ReportId,
                MasterFileRefNo = dto.MasterFileRefNo,
                AssetNumber = dto.AssetNumber,
                Road = dto.Road,
                Village = dto.Village,
                Vendor = dto.Vendor,
                DeedNumber = dto.DeedNumber,
                DeedAttestedNumber = dto.DeedAttestedNumber,
                NotaryName = dto.NotaryName,
                LotNumber = dto.LotNumber,
                PlanNumber = dto.PlanNumber,
                PlanDate = dto.PlanDate,
                Extent = dto.Extent,
                Consideration = dto.Consideration,
                Remarks = dto.Remarks,
                Rate = dto.Rate,
                RateType = dto.RateType,
                LocationLongitude = dto.LocationLongitude,
                LocationLatitude = dto.LocationLatitude,
                LandRegistryReferences = dto.LandRegistryReferences,
                Situation = dto.Situation,
                DescriptionOfProperty = dto.DescriptionOfProperty,
                LandMiscellaneousMasterFileId = dto.LandMiscellaneousMasterFileId
            };

            lmSalesEvidence = await _repository.CreateAsync(lmSalesEvidence);
            return MapToResponseDto(lmSalesEvidence);
        }

        public async Task<bool> UpdateAsync(int reportId, LMSalesEvidenceUpdateDto dto)
        {
            // Verify LM sales evidence exists
            var existingLMSalesEvidence = await _repository.GetByReportIdAsync(reportId);

            if (existingLMSalesEvidence == null)
            {
                return false;
            }

            // Update existing LM sales evidence with data from DTO
            existingLMSalesEvidence.MasterFileRefNo = dto.MasterFileRefNo;
            existingLMSalesEvidence.AssetNumber = dto.AssetNumber;
            existingLMSalesEvidence.Road = dto.Road;
            existingLMSalesEvidence.Village = dto.Village;
            existingLMSalesEvidence.Vendor = dto.Vendor;
            existingLMSalesEvidence.DeedNumber = dto.DeedNumber;
            existingLMSalesEvidence.DeedAttestedNumber = dto.DeedAttestedNumber;
            existingLMSalesEvidence.NotaryName = dto.NotaryName;
            existingLMSalesEvidence.LotNumber = dto.LotNumber;
            existingLMSalesEvidence.PlanNumber = dto.PlanNumber;
            existingLMSalesEvidence.PlanDate = dto.PlanDate;
            existingLMSalesEvidence.Extent = dto.Extent;
            existingLMSalesEvidence.Consideration = dto.Consideration;
            existingLMSalesEvidence.Remarks = dto.Remarks;
            existingLMSalesEvidence.Rate = dto.Rate;
            existingLMSalesEvidence.RateType = dto.RateType;
            existingLMSalesEvidence.LocationLongitude = dto.LocationLongitude;
            existingLMSalesEvidence.LocationLatitude = dto.LocationLatitude;
            existingLMSalesEvidence.LandRegistryReferences = dto.LandRegistryReferences;
            existingLMSalesEvidence.Situation = dto.Situation;
            existingLMSalesEvidence.DescriptionOfProperty = dto.DescriptionOfProperty;
            existingLMSalesEvidence.LandMiscellaneousMasterFileId = dto.LandMiscellaneousMasterFileId;

            return await _repository.UpdateAsync(existingLMSalesEvidence);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private LMSalesEvidenceResponseDto MapToResponseDto(LMSalesEvidence lmSalesEvidence)
        {
            return new LMSalesEvidenceResponseDto
            {
                Id = lmSalesEvidence.Id,
                ReportId = lmSalesEvidence.ReportId,
                MasterFileRefNo = lmSalesEvidence.MasterFileRefNo,
                AssetNumber = lmSalesEvidence.AssetNumber,
                Road = lmSalesEvidence.Road,
                Village = lmSalesEvidence.Village,
                Vendor = lmSalesEvidence.Vendor,
                DeedNumber = lmSalesEvidence.DeedNumber,
                DeedAttestedNumber = lmSalesEvidence.DeedAttestedNumber,
                NotaryName = lmSalesEvidence.NotaryName,
                LotNumber = lmSalesEvidence.LotNumber,
                PlanNumber = lmSalesEvidence.PlanNumber,
                PlanDate = lmSalesEvidence.PlanDate,
                Extent = lmSalesEvidence.Extent,
                Consideration = lmSalesEvidence.Consideration,
                Remarks = lmSalesEvidence.Remarks,
                Rate = lmSalesEvidence.Rate,
                RateType = lmSalesEvidence.RateType,
                LocationLongitude = lmSalesEvidence.LocationLongitude,
                LocationLatitude = lmSalesEvidence.LocationLatitude,
                LandRegistryReferences = lmSalesEvidence.LandRegistryReferences,
                Situation = lmSalesEvidence.Situation,
                DescriptionOfProperty = lmSalesEvidence.DescriptionOfProperty,
                LandMiscellaneousMasterFileId = lmSalesEvidence.LandMiscellaneousMasterFileId,
                LandMiscellaneousMasterFile = lmSalesEvidence.LandMiscellaneousMasterFile != null
                    ? MapMasterFileToDto(lmSalesEvidence.LandMiscellaneousMasterFile)
                    : null
            };
        }

        private LandMiscellaneousMasterFileDto MapMasterFileToDto(LandMiscellaneousMasterFile masterFile)
        {
            return new LandMiscellaneousMasterFileDto
            {
                Id = masterFile.Id,
                MasterFileNo = masterFile.MasterFileNo,
                MasterFileRefNo = masterFile.MasterFileRefNo,
                PlanType = masterFile.PlanType,
                PlanNo = masterFile.PlanNo,
                RequestingAuthorityReferenceNo = masterFile.RequestingAuthorityReferenceNo,
                Status = masterFile.Status,
                Lots = masterFile.Lots
            };
        }
    }
}
