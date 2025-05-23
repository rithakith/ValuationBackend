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
    public class RentalEvidenceLAController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RentalEvidenceLAController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RentalEvidenceLA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalEvidenceLAResponseDto>>> GetRentalEvidencesLA()
        {
            var evidences = await _context.RentalEvidencesLA.ToListAsync();
            return evidences.Select(MapToResponseDto).ToList();
        }

        // GET: api/RentalEvidenceLA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalEvidenceLAResponseDto>> GetRentalEvidenceLA(int id)
        {
            var rentalEvidence = await _context.RentalEvidencesLA.FindAsync(id);

            if (rentalEvidence == null)
            {
                return NotFound();
            }

            return MapToResponseDto(rentalEvidence);
        }

        // POST: api/RentalEvidenceLA
        [HttpPost]
        public async Task<ActionResult<RentalEvidenceLAResponseDto>> CreateRentalEvidenceLA(RentalEvidenceLACreateDto dto)
        {
            // Create a new Report for this rental evidence
            var report = new Report
            {
                ReportType = "LA_rental_evidence",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Acquisition Rental Evidence for {dto.MasterFileRefNo}"
            };

            // Add the report first
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            // Create the rental evidence entity from the DTO
            var rentalEvidence = new RentalEvidenceLA
            {
                ReportId = report.ReportId,
                MasterFileId = dto.MasterFileId,
                MasterFileRefNo = dto.MasterFileRefNo,
                AssessmentNo = dto.AssessmentNo,
                Owner = dto.Owner,
                Occupier = dto.Occupier,
                Description = dto.Description,
                FloorRateSQFT = dto.FloorRateSQFT,
                RatePerSqft = dto.RatePerSqft,
                RatePerMonth = dto.RatePerMonth,
                LocationLongitude = dto.LocationLongitude,
                LocationLatitude = dto.LocationLatitude,
                HeadOfTerms = dto.HeadOfTerms,
                Situation = dto.Situation,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow
            };
            
            _context.RentalEvidencesLA.Add(rentalEvidence);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRentalEvidenceLA), 
                new { id = rentalEvidence.Id }, 
                MapToResponseDto(rentalEvidence));
        }

        // PUT: api/RentalEvidenceLA/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRentalEvidenceLA(int id, RentalEvidenceLAUpdateDto dto)
        {
            // Verify evidence exists
            var existingEvidence = await _context.RentalEvidencesLA.FindAsync(id);

            if (existingEvidence == null)
            {
                return NotFound();
            }

            // Update existing evidence with data from DTO
            existingEvidence.MasterFileId = dto.MasterFileId;
            existingEvidence.MasterFileRefNo = dto.MasterFileRefNo;
            existingEvidence.AssessmentNo = dto.AssessmentNo;
            existingEvidence.Owner = dto.Owner;
            existingEvidence.Occupier = dto.Occupier;
            existingEvidence.Description = dto.Description;
            existingEvidence.FloorRateSQFT = dto.FloorRateSQFT;
            existingEvidence.RatePerSqft = dto.RatePerSqft;
            existingEvidence.RatePerMonth = dto.RatePerMonth;
            existingEvidence.LocationLongitude = dto.LocationLongitude;
            existingEvidence.LocationLatitude = dto.LocationLatitude;
            existingEvidence.HeadOfTerms = dto.HeadOfTerms;
            existingEvidence.Situation = dto.Situation;
            existingEvidence.Remarks = dto.Remarks;
            existingEvidence.UpdatedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalEvidenceLAExists(id))
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

        // DELETE: api/RentalEvidenceLA/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentalEvidenceLA(int id)
        {
            var rentalEvidence = await _context.RentalEvidencesLA.FindAsync(id);

            if (rentalEvidence == null)
            {
                return NotFound();
            }

            // Also delete the associated report
            var report = await _context.Reports.FindAsync(rentalEvidence.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.RentalEvidencesLA.Remove(rentalEvidence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/RentalEvidenceLA/ByReport/{reportId}
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<RentalEvidenceLAResponseDto>> GetRentalEvidenceLAByReportId(int reportId)
        {
            var rentalEvidence = await _context.RentalEvidencesLA
                .FirstOrDefaultAsync(re => re.ReportId == reportId);

            if (rentalEvidence == null)
            {
                return NotFound();
            }

            return MapToResponseDto(rentalEvidence);
        }

        private bool RentalEvidenceLAExists(int id)
        {
            return _context.RentalEvidencesLA.Any(e => e.Id == id);
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