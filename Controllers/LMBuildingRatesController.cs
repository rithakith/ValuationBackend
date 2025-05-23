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
    public class LMBuildingRatesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LMBuildingRatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LMBuildingRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMBuildingRatesResponseDto>>> GetLMBuildingRates()
        {
            var rates = await _context.LMBuildingRates.ToListAsync();
            return rates.Select(MapToResponseDto).ToList();
        }

        // GET: api/LMBuildingRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LMBuildingRatesResponseDto>> GetLMBuildingRate(int id)
        {
            var lmBuildingRate = await _context.LMBuildingRates.FindAsync(id);

            if (lmBuildingRate == null)
            {
                return NotFound();
            }

            return MapToResponseDto(lmBuildingRate);
        }

        // POST: api/LMBuildingRates
        [HttpPost]
        public async Task<ActionResult<LMBuildingRatesResponseDto>> CreateLMBuildingRate(LMBuildingRatesCreateDto dto)
        {
            var report = new Report
            {
                ReportType = "LM_BuildingRates",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Miscellaneous Building Rates for {dto.MasterFileRefNo}"
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            var lmBuildingRate = new LMBuildingRates
            {
                ReportId = report.ReportId,
                MasterFileRefNo = dto.MasterFileRefNo,
                AssessmentNumber = dto.AssessmentNumber,
                Owner = dto.Owner,
                ConstructedBy = dto.ConstructedBy,
                YearOfConstruction = dto.YearOfConstruction,
                DescriptionOfProperty = dto.DescriptionOfProperty,
                FloorArea = dto.FloorArea,
                RatePerSQFT = dto.RatePerSQFT,
                Cost = dto.Cost,
                Remarks = dto.Remarks,
                LocationLatitude = dto.LocationLatitude,
                LocationLongitude = dto.LocationLongitude
            };

            _context.LMBuildingRates.Add(lmBuildingRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLMBuildingRate), new { id = lmBuildingRate.Id }, MapToResponseDto(lmBuildingRate));
        }

        // PUT: api/LMBuildingRates/5
        [HttpPut("{reportId}")]
        public async Task<IActionResult> UpdateLMBuildingRate(int reportId, LMBuildingRatesUpdateDto dto)
        {
            if (reportId != dto.ReportId)
            {
                return BadRequest("Report ID in URL must match Report ID in body.");
            }

            var lmBuildingRate = await _context.LMBuildingRates.FirstOrDefaultAsync(e => e.ReportId == reportId);

            if (lmBuildingRate == null)
            {
                return NotFound();
            }

            lmBuildingRate.MasterFileRefNo = dto.MasterFileRefNo;
            lmBuildingRate.AssessmentNumber = dto.AssessmentNumber;
            lmBuildingRate.Owner = dto.Owner;
            lmBuildingRate.ConstructedBy = dto.ConstructedBy;
            lmBuildingRate.YearOfConstruction = dto.YearOfConstruction;
            lmBuildingRate.DescriptionOfProperty = dto.DescriptionOfProperty;
            lmBuildingRate.FloorArea = dto.FloorArea;
            lmBuildingRate.RatePerSQFT = dto.RatePerSQFT;
            lmBuildingRate.Cost = dto.Cost;
            lmBuildingRate.Remarks = dto.Remarks;
            lmBuildingRate.LocationLatitude = dto.LocationLatitude;
            lmBuildingRate.LocationLongitude = dto.LocationLongitude;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LMBuildingRateExists(reportId))
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

        // DELETE: api/LMBuildingRates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLMBuildingRate(int id)
        {
            var lmBuildingRate = await _context.LMBuildingRates.FindAsync(id);
            if (lmBuildingRate == null)
            {
                return NotFound();
            }

            var report = await _context.Reports.FindAsync(lmBuildingRate.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.LMBuildingRates.Remove(lmBuildingRate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/LMBuildingRates/ByReport/5
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<LMBuildingRatesResponseDto>> GetLMBuildingRateByReportId(int reportId)
        {
            var lmBuildingRate = await _context.LMBuildingRates
                .FirstOrDefaultAsync(ir => ir.ReportId == reportId);

            if (lmBuildingRate == null)
            {
                return NotFound();
            }

            return MapToResponseDto(lmBuildingRate);
        }

        private bool LMBuildingRateExists(int reportId)
        {
            return _context.LMBuildingRates.Any(e => e.ReportId == reportId);
        }

        private LMBuildingRatesResponseDto MapToResponseDto(LMBuildingRates rate)
        {
            return new LMBuildingRatesResponseDto
            {
                Id = rate.Id,
                ReportId = rate.ReportId,
                MasterFileRefNo = rate.MasterFileRefNo,
                AssessmentNumber = rate.AssessmentNumber,
                Owner = rate.Owner,
                ConstructedBy = rate.ConstructedBy,
                YearOfConstruction = rate.YearOfConstruction,
                DescriptionOfProperty = rate.DescriptionOfProperty,
                FloorArea = rate.FloorArea,
                RatePerSQFT = rate.RatePerSQFT,
                Cost = rate.Cost,
                Remarks = rate.Remarks,
                LocationLatitude = rate.LocationLatitude,
                LocationLongitude = rate.LocationLongitude
            };
        }
    }
}
