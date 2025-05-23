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
    public class PastValuationsLAController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PastValuationsLAController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PastValuationsLA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PastValuationsLAResponseDto>>> GetPastValuationsLA()
        {
            var pastValuations = await _context.PastValuationsLA.ToListAsync();
            return pastValuations.Select(MapToResponseDto).ToList();
        }

        // GET: api/PastValuationsLA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PastValuationsLAResponseDto>> GetPastValuationLA(int id)
        {
            var pastValuation = await _context.PastValuationsLA.FindAsync(id);

            if (pastValuation == null)
            {
                return NotFound();
            }

            return MapToResponseDto(pastValuation);
        }

        // POST: api/PastValuationsLA
        [HttpPost]
        public async Task<ActionResult<PastValuationsLAResponseDto>> CreatePastValuationLA(PastValuationsLACreateDto dto)
        {
            // Create a new Report for this past valuation
            var report = new Report
            {
                ReportType = "LA_past_valuation",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Acquisition Past Valuation for {dto.MasterFileRefNo}"
            };

            // Add the report first
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            // Create the past valuation entity from the DTO
            var pastValuation = new PastValuationsLA
            {
                ReportId = report.ReportId,
                MasterFileId = dto.MasterFileId,
                MasterFileRefNo = dto.MasterFileRefNo,
                FileNoGNDivision = dto.FileNoGNDivision,
                Situation = dto.Situation,
                DateOfValuation = dto.DateOfValuation,
                PurposeOfValuation = dto.PurposeOfValuation,
                PlanOfParticulars = dto.PlanOfParticulars,
                Extent = dto.Extent,
                Rate = dto.Rate,
                RateType = dto.RateType,
                Remarks = dto.Remarks,
                LocationLongitude = dto.LocationLongitude,
                LocationLatitude = dto.LocationLatitude,
                CreatedAt = DateTime.UtcNow
            };
            
            _context.PastValuationsLA.Add(pastValuation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPastValuationLA), 
                new { id = pastValuation.Id }, 
                MapToResponseDto(pastValuation));
        }

        // PUT: api/PastValuationsLA/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePastValuationLA(int id, PastValuationsLAUpdateDto dto)
        {
            // Verify past valuation exists
            var existingPastValuation = await _context.PastValuationsLA.FindAsync(id);

            if (existingPastValuation == null)
            {
                return NotFound();
            }

            // Update existing past valuation with data from DTO
            existingPastValuation.MasterFileId = dto.MasterFileId;
            existingPastValuation.MasterFileRefNo = dto.MasterFileRefNo;
            existingPastValuation.FileNoGNDivision = dto.FileNoGNDivision;
            existingPastValuation.Situation = dto.Situation;
            existingPastValuation.DateOfValuation = dto.DateOfValuation;
            existingPastValuation.PurposeOfValuation = dto.PurposeOfValuation;
            existingPastValuation.PlanOfParticulars = dto.PlanOfParticulars;
            existingPastValuation.Extent = dto.Extent;
            existingPastValuation.Rate = dto.Rate;
            existingPastValuation.RateType = dto.RateType;
            existingPastValuation.Remarks = dto.Remarks;
            existingPastValuation.LocationLongitude = dto.LocationLongitude;
            existingPastValuation.LocationLatitude = dto.LocationLatitude;
            existingPastValuation.UpdatedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastValuationsLAExists(id))
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

        // DELETE: api/PastValuationsLA/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePastValuationLA(int id)
        {
            var pastValuation = await _context.PastValuationsLA.FindAsync(id);

            if (pastValuation == null)
            {
                return NotFound();
            }

            // Also delete the associated report
            var report = await _context.Reports.FindAsync(pastValuation.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.PastValuationsLA.Remove(pastValuation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/PastValuationsLA/ByReport/{reportId}
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<PastValuationsLAResponseDto>> GetPastValuationLAByReportId(int reportId)
        {
            var pastValuation = await _context.PastValuationsLA
                .FirstOrDefaultAsync(pv => pv.ReportId == reportId);

            if (pastValuation == null)
            {
                return NotFound();
            }

            return MapToResponseDto(pastValuation);
        }

        private bool PastValuationsLAExists(int id)
        {
            return _context.PastValuationsLA.Any(e => e.Id == id);
        }

        private PastValuationsLAResponseDto MapToResponseDto(PastValuationsLA pastValuation)
        {
            return new PastValuationsLAResponseDto
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