using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ValuationBackend.Data;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesEvidenceLAController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalesEvidenceLAController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SalesEvidenceLA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesEvidenceLAResponseDto>>> GetSalesEvidencesLA()
        {
            var evidences = await _context.SalesEvidencesLA.ToListAsync();
            return evidences.Select(MapToResponseDto).ToList();
        }

        // GET: api/SalesEvidenceLA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesEvidenceLAResponseDto>> GetSalesEvidenceLA(int id)
        {
            var salesEvidence = await _context.SalesEvidencesLA.FindAsync(id);

            if (salesEvidence == null)
            {
                return NotFound();
            }

            return MapToResponseDto(salesEvidence);
        }

        // POST: api/SalesEvidenceLA
        [HttpPost]
        public async Task<ActionResult<SalesEvidenceLAResponseDto>> CreateSalesEvidenceLA(SalesEvidenceLACreateDto dto)
        {
            // Create a new Report for this sales evidence
            var report = new Report
            {
                ReportType = "LA_sales_evidence",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Acquisition Sales Evidence for {dto.MasterFileRefNo}"
            };

            // Add the report first
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            // Create the sales evidence entity from the DTO
            var salesEvidence = new SalesEvidenceLA
            {
                ReportId = report.ReportId,
                MasterFileId = dto.MasterFileId,
                MasterFileRefNo = dto.MasterFileRefNo,
                AssetNumber = dto.AssetNumber,
                Road = dto.Road,
                Village = dto.Village,
                Owner = dto.Owner,
                Occupier = dto.Occupier,
                Vendor = dto.Vendor,
                DeedNumber = dto.DeedNumber,
                Description = dto.Description,
                FloorRate = dto.FloorRate,
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
                CreatedAt = DateTime.UtcNow
            };
            
            _context.SalesEvidencesLA.Add(salesEvidence);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSalesEvidenceLA), 
                new { id = salesEvidence.Id }, 
                MapToResponseDto(salesEvidence));
        }

        // PUT: api/SalesEvidenceLA/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalesEvidenceLA(int id, SalesEvidenceLAUpdateDto dto)
        {
            // Verify evidence exists
            var existingEvidence = await _context.SalesEvidencesLA.FindAsync(id);

            if (existingEvidence == null)
            {
                return NotFound();
            }

            // Update existing evidence with data from DTO
            existingEvidence.MasterFileId = dto.MasterFileId;
            existingEvidence.MasterFileRefNo = dto.MasterFileRefNo;
            existingEvidence.AssetNumber = dto.AssetNumber;
            existingEvidence.Road = dto.Road;
            existingEvidence.Village = dto.Village;
            existingEvidence.Owner = dto.Owner;
            existingEvidence.Occupier = dto.Occupier;
            existingEvidence.Vendor = dto.Vendor;
            existingEvidence.DeedNumber = dto.DeedNumber;
            existingEvidence.Description = dto.Description;
            existingEvidence.FloorRate = dto.FloorRate;
            existingEvidence.DeedAttestedNumber = dto.DeedAttestedNumber;
            existingEvidence.NotaryName = dto.NotaryName;
            existingEvidence.LotNumber = dto.LotNumber;
            existingEvidence.PlanNumber = dto.PlanNumber;
            existingEvidence.PlanDate = dto.PlanDate;
            existingEvidence.Extent = dto.Extent;
            existingEvidence.Consideration = dto.Consideration;
            existingEvidence.Remarks = dto.Remarks;
            existingEvidence.Rate = dto.Rate;
            existingEvidence.RateType = dto.RateType;
            existingEvidence.LocationLongitude = dto.LocationLongitude;
            existingEvidence.LocationLatitude = dto.LocationLatitude;
            existingEvidence.LandRegistryReferences = dto.LandRegistryReferences;
            existingEvidence.Situation = dto.Situation;
            existingEvidence.DescriptionOfProperty = dto.DescriptionOfProperty;
            existingEvidence.UpdatedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesEvidenceLAExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/SalesEvidenceLA/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesEvidenceLA(int id)
        {
            var salesEvidence = await _context.SalesEvidencesLA.FindAsync(id);

            if (salesEvidence == null)
            {
                return NotFound();
            }

            // Also delete the associated report
            var report = await _context.Reports.FindAsync(salesEvidence.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.SalesEvidencesLA.Remove(salesEvidence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/SalesEvidenceLA/ByReport/{reportId}
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<SalesEvidenceLAResponseDto>> GetSalesEvidenceLAByReportId(int reportId)
        {
            var salesEvidence = await _context.SalesEvidencesLA
                .FirstOrDefaultAsync(se => se.ReportId == reportId);

            if (salesEvidence == null)
            {
                return NotFound();
            }

            return MapToResponseDto(salesEvidence);
        }

        private bool SalesEvidenceLAExists(int id)
        {
            return _context.SalesEvidencesLA.Any(e => e.Id == id);
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