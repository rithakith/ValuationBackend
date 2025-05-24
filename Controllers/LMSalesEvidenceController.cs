using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;

namespace ValuationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LMSalesEvidenceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LMSalesEvidenceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LMSalesEvidence
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMSalesEvidenceResponseDto>>> GetLMSalesEvidences()
        {
            var evidences = await _context.LMSalesEvidences.ToListAsync();
            return evidences.Select(MapToResponseDto).ToList();
        }

        // GET: api/LMSalesEvidence/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LMSalesEvidenceResponseDto>> GetLMSalesEvidence(int id)
        {
            var lmSalesEvidence = await _context.LMSalesEvidences.FindAsync(id);

            if (lmSalesEvidence == null)
            {
                return NotFound();
            }

            return MapToResponseDto(lmSalesEvidence);
        }

        // POST: api/LMSalesEvidence
        [HttpPost]
        public async Task<ActionResult<LMSalesEvidenceResponseDto>> CreateLMSalesEvidence(LMSalesEvidenceCreateDto dto)
        {
            var report = new Report
            {
                ReportType = "LM_SalesEvidence",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Miscellaneous Sales Evidence for {dto.MasterFileRefNo}"
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

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
                DescriptionOfProperty = dto.DescriptionOfProperty
            };

            _context.LMSalesEvidences.Add(lmSalesEvidence);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLMSalesEvidence), new { id = lmSalesEvidence.Id }, MapToResponseDto(lmSalesEvidence));
        }

        // PUT: api/LMSalesEvidence/5
        [HttpPut("{reportId}")]
        public async Task<IActionResult> UpdateLMSalesEvidence(int reportId, LMSalesEvidenceUpdateDto dto)
        {
            if (reportId != dto.ReportId)
            {
                return BadRequest("Report ID in URL must match Report ID in body.");
            }

            var lmSalesEvidence = await _context.LMSalesEvidences.FirstOrDefaultAsync(e => e.ReportId == reportId);

            if (lmSalesEvidence == null)
            {
                return NotFound();
            }

            lmSalesEvidence.MasterFileRefNo = dto.MasterFileRefNo;
            lmSalesEvidence.AssetNumber = dto.AssetNumber;
            lmSalesEvidence.Road = dto.Road;
            lmSalesEvidence.Village = dto.Village;
            lmSalesEvidence.Vendor = dto.Vendor;
            lmSalesEvidence.DeedNumber = dto.DeedNumber;
            lmSalesEvidence.DeedAttestedNumber = dto.DeedAttestedNumber;
            lmSalesEvidence.NotaryName = dto.NotaryName;
            lmSalesEvidence.LotNumber = dto.LotNumber;
            lmSalesEvidence.PlanNumber = dto.PlanNumber;
            lmSalesEvidence.PlanDate = dto.PlanDate;
            lmSalesEvidence.Extent = dto.Extent;
            lmSalesEvidence.Consideration = dto.Consideration;
            lmSalesEvidence.Remarks = dto.Remarks;
            lmSalesEvidence.Rate = dto.Rate;
            lmSalesEvidence.RateType = dto.RateType;
            lmSalesEvidence.LocationLongitude = dto.LocationLongitude;
            lmSalesEvidence.LocationLatitude = dto.LocationLatitude;
            lmSalesEvidence.LandRegistryReferences = dto.LandRegistryReferences;
            lmSalesEvidence.Situation = dto.Situation;
            lmSalesEvidence.DescriptionOfProperty = dto.DescriptionOfProperty;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LMSalesEvidenceExists(reportId))
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

        // DELETE: api/LMSalesEvidence/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLMSalesEvidence(int id)
        {
            var lmSalesEvidence = await _context.LMSalesEvidences.FindAsync(id);
            if (lmSalesEvidence == null)
            {
                return NotFound();
            }

            var report = await _context.Reports.FindAsync(lmSalesEvidence.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.LMSalesEvidences.Remove(lmSalesEvidence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/LMSalesEvidence/ByReport/5
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<LMSalesEvidenceResponseDto>> GetLMSalesEvidenceByReportId(int reportId)
        {
            var lmSalesEvidence = await _context.LMSalesEvidences
                .FirstOrDefaultAsync(ir => ir.ReportId == reportId);

            if (lmSalesEvidence == null)
            {
                return NotFound();
            }

            return MapToResponseDto(lmSalesEvidence);
        }

        private bool LMSalesEvidenceExists(int reportId)
        {
            return _context.LMSalesEvidences.Any(e => e.ReportId == reportId);
        }

        private LMSalesEvidenceResponseDto MapToResponseDto(LMSalesEvidence evidence)
        {
            return new LMSalesEvidenceResponseDto
            {
                Id = evidence.Id,
                ReportId = evidence.ReportId,
                MasterFileRefNo = evidence.MasterFileRefNo,
                AssetNumber = evidence.AssetNumber,
                Road = evidence.Road,
                Village = evidence.Village,
                Vendor = evidence.Vendor,
                DeedNumber = evidence.DeedNumber,
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
                DescriptionOfProperty = evidence.DescriptionOfProperty
            };
        }
    }
}
