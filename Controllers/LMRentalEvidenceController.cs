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
    public class LMRentalEvidenceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LMRentalEvidenceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LMRentalEvidence
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMRentalEvidenceResponseDto>>> GetLMRentalEvidences()
        {
            var evidences = await _context.LMRentalEvidences.ToListAsync();
            return evidences.Select(MapToResponseDto).ToList();
        }

        // GET: api/LMRentalEvidence/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LMRentalEvidenceResponseDto>> GetLMRentalEvidence(int id)
        {
            var lmRentalEvidence = await _context.LMRentalEvidences.FindAsync(id);

            if (lmRentalEvidence == null)
            {
                return NotFound();
            }

            return MapToResponseDto(lmRentalEvidence);
        }

        // POST: api/LMRentalEvidence
        [HttpPost]
        public async Task<ActionResult<LMRentalEvidenceResponseDto>> CreateLMRentalEvidence(LMRentalEvidenceCreateDto dto)
        {
            var report = new Report
            {
                ReportType = "LM_RentalEvidence",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Miscellaneous Rental Evidence for {dto.MasterFileRefNo}"
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

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

            _context.LMRentalEvidences.Add(lmRentalEvidence);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLMRentalEvidence), new { id = lmRentalEvidence.Id }, MapToResponseDto(lmRentalEvidence));
        }

        // PUT: api/LMRentalEvidence/5
        [HttpPut("{reportId}")]
        public async Task<IActionResult> UpdateLMRentalEvidence(int reportId, LMRentalEvidenceUpdateDto dto)
        {
            if (reportId != dto.ReportId)
            {
                return BadRequest("Report ID in URL must match Report ID in body.");
            }

            var lmRentalEvidence = await _context.LMRentalEvidences.FirstOrDefaultAsync(e => e.ReportId == reportId);

            if (lmRentalEvidence == null)
            {
                return NotFound();
            }

            lmRentalEvidence.MasterFileRefNo = dto.MasterFileRefNo;
            lmRentalEvidence.AssessmentNo = dto.AssessmentNo;
            lmRentalEvidence.Owner = dto.Owner;
            lmRentalEvidence.Occupier = dto.Occupier;
            lmRentalEvidence.Description = dto.Description;
            lmRentalEvidence.FloorRate = dto.FloorRate;
            lmRentalEvidence.RatePer = dto.RatePer;
            lmRentalEvidence.RatePerMonth = dto.RatePerMonth;
            lmRentalEvidence.LocationLongitude = dto.LocationLongitude;
            lmRentalEvidence.LocationLatitude = dto.LocationLatitude;
            lmRentalEvidence.HeadOfTerms = dto.HeadOfTerms;
            lmRentalEvidence.Situation = dto.Situation;
            lmRentalEvidence.Remarks = dto.Remarks;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LMRentalEvidenceExists(reportId))
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

        // DELETE: api/LMRentalEvidence/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLMRentalEvidence(int id)
        {
            var lmRentalEvidence = await _context.LMRentalEvidences.FindAsync(id);
            if (lmRentalEvidence == null)
            {
                return NotFound();
            }

            var report = await _context.Reports.FindAsync(lmRentalEvidence.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.LMRentalEvidences.Remove(lmRentalEvidence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/LMRentalEvidence/ByReport/5
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<LMRentalEvidenceResponseDto>> GetLMRentalEvidenceByReportId(int reportId)
        {
            var lmRentalEvidence = await _context.LMRentalEvidences
                .FirstOrDefaultAsync(ir => ir.ReportId == reportId);

            if (lmRentalEvidence == null)
            {
                return NotFound();
            }

            return MapToResponseDto(lmRentalEvidence);
        }


        private bool LMRentalEvidenceExists(int reportId)
        {
            return _context.LMRentalEvidences.Any(e => e.ReportId == reportId);
        }

        private LMRentalEvidenceResponseDto MapToResponseDto(LMRentalEvidence evidence)
        {
            return new LMRentalEvidenceResponseDto
            {
                Id = evidence.Id,
                ReportId = evidence.ReportId,
                MasterFileRefNo = evidence.MasterFileRefNo,
                AssessmentNo = evidence.AssessmentNo,
                Owner = evidence.Owner,
                Occupier = evidence.Occupier,
                Description = evidence.Description,
                FloorRate = evidence.FloorRate,
                RatePer = evidence.RatePer,
                RatePerMonth = evidence.RatePerMonth,
                LocationLongitude = evidence.LocationLongitude,
                LocationLatitude = evidence.LocationLatitude,
                HeadOfTerms = evidence.HeadOfTerms,
                Situation = evidence.Situation,
                Remarks = evidence.Remarks
            };
        }
    }
}
