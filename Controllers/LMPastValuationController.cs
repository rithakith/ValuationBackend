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
    public class LMPastValuationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LMPastValuationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LMPastValuation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMPastValuationResponseDto>>> GetLMPastValuations()
        {
            var valuations = await _context.LMPastValuations.ToListAsync();
            return valuations.Select(MapToResponseDto).ToList();
        }

        // GET: api/LMPastValuation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LMPastValuationResponseDto>> GetLMPastValuation(int id)
        {
            var lmPastValuation = await _context.LMPastValuations.FindAsync(id);

            if (lmPastValuation == null)
            {
                return NotFound();
            }

            return MapToResponseDto(lmPastValuation);
        }

        // POST: api/LMPastValuation
        [HttpPost]
        public async Task<ActionResult<LMPastValuationResponseDto>> CreateLMPastValuation(LMPastValuationCreateDto dto)
        {
            var report = new Report
            {
                ReportType = "LM_PastValuation",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Miscellaneous Past Valuation for {dto.MasterFileRefNo}"
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

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

            _context.LMPastValuations.Add(lmPastValuation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLMPastValuation), new { id = lmPastValuation.Id }, MapToResponseDto(lmPastValuation));
        }

        // PUT: api/LMPastValuation/5
        [HttpPut("{reportId}")]
        public async Task<IActionResult> UpdateLMPastValuation(int reportId, LMPastValuationUpdateDto dto)
        {
            if (reportId != dto.ReportId)
            {
                return BadRequest("Report ID in URL must match Report ID in body.");
            }

            var lmPastValuation = await _context.LMPastValuations.FirstOrDefaultAsync(e => e.ReportId == reportId);

            if (lmPastValuation == null)
            {
                return NotFound();
            }

            lmPastValuation.MasterFileRefNo = dto.MasterFileRefNo;
            lmPastValuation.FileNo_GnDivision = dto.FileNo_GnDivision;
            lmPastValuation.Situation = dto.Situation;
            lmPastValuation.DateOfValuation = dto.DateOfValuation;
            lmPastValuation.PurposeOfValuation = dto.PurposeOfValuation;
            lmPastValuation.PlanOfParticulars = dto.PlanOfParticulars;
            lmPastValuation.Extent = dto.Extent;
            lmPastValuation.Rate = dto.Rate;
            lmPastValuation.RateType = dto.RateType;
            lmPastValuation.Remarks = dto.Remarks;
            lmPastValuation.LocationLongitude = dto.LocationLongitude;
            lmPastValuation.LocationLatitude = dto.LocationLatitude;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LMPastValuationExists(reportId))
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

        // DELETE: api/LMPastValuation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLMPastValuation(int id)
        {
            var lmPastValuation = await _context.LMPastValuations.FindAsync(id);
            if (lmPastValuation == null)
            {
                return NotFound();
            }

            var report = await _context.Reports.FindAsync(lmPastValuation.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.LMPastValuations.Remove(lmPastValuation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/LMPastValuation/ByReport/5
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<LMPastValuationResponseDto>> GetLMPastValuationByReportId(int reportId)
        {
            var lmPastValuation = await _context.LMPastValuations
                .FirstOrDefaultAsync(ir => ir.ReportId == reportId);

            if (lmPastValuation == null)
            {
                return NotFound();
            }

            return MapToResponseDto(lmPastValuation);
        }

        private bool LMPastValuationExists(int reportId)
        {
            return _context.LMPastValuations.Any(e => e.ReportId == reportId);
        }

        private LMPastValuationResponseDto MapToResponseDto(LMPastValuation valuation)
        {
            return new LMPastValuationResponseDto
            {
                Id = valuation.Id,
                ReportId = valuation.ReportId,
                MasterFileRefNo = valuation.MasterFileRefNo,
                FileNo_GnDivision = valuation.FileNo_GnDivision,
                Situation = valuation.Situation,
                DateOfValuation = valuation.DateOfValuation,
                PurposeOfValuation = valuation.PurposeOfValuation,
                PlanOfParticulars = valuation.PlanOfParticulars,
                Extent = valuation.Extent,
                Rate = valuation.Rate,
                RateType = valuation.RateType,
                Remarks = valuation.Remarks,
                LocationLongitude = valuation.LocationLongitude,
                LocationLatitude = valuation.LocationLatitude
            };
        }
    }
}
