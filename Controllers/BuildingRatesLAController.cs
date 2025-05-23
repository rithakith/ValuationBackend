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
    public class BuildingRatesLAController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BuildingRatesLAController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BuildingRatesLA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingRatesLAResponseDto>>> GetBuildingRatesLA()
        {
            var buildingRates = await _context.BuildingRatesLA.ToListAsync();
            return buildingRates.Select(MapToResponseDto).ToList();
        }

        // GET: api/BuildingRatesLA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingRatesLAResponseDto>> GetBuildingRateLA(int id)
        {
            var buildingRate = await _context.BuildingRatesLA.FindAsync(id);

            if (buildingRate == null)
            {
                return NotFound();
            }

            return MapToResponseDto(buildingRate);
        }

        // POST: api/BuildingRatesLA
        [HttpPost]
        public async Task<ActionResult<BuildingRatesLAResponseDto>> CreateBuildingRateLA(BuildingRatesLACreateDto dto)
        {
            // Create a new Report for this building rate
            var report = new Report
            {
                ReportType = "LA_building_rate",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Acquisition Building Rate for {dto.MasterFileId}"
            };

            // Add the report first
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            // Create the building rate entity from the DTO
            var buildingRate = new BuildingRatesLA
            {
                ReportId = report.ReportId,
                MasterFileId = dto.MasterFileId,
                AssessmentNumber = dto.AssessmentNumber,
                Owner = dto.Owner,
                ConstructedBy = dto.ConstructedBy,
                YearOfConstruction = dto.YearOfConstruction,
                DescriptionOfProperty = dto.DescriptionOfProperty,
                FloorAreaSQFT = dto.FloorAreaSQFT,
                RatePerSQFT = dto.RatePerSQFT,
                Cost = dto.Cost,
                Remarks = dto.Remarks,
                LocationLatitude = dto.LocationLatitude,
                LocationLongitude = dto.LocationLongitude,
                CreatedAt = DateTime.UtcNow
            };
            
            _context.BuildingRatesLA.Add(buildingRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBuildingRateLA), 
                new { id = buildingRate.Id }, 
                MapToResponseDto(buildingRate));
        }

        // PUT: api/BuildingRatesLA/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBuildingRateLA(int id, BuildingRatesLAUpdateDto dto)
        {
            // Verify building rate exists
            var existingBuildingRate = await _context.BuildingRatesLA.FindAsync(id);

            if (existingBuildingRate == null)
            {
                return NotFound();
            }

            // Update existing building rate with data from DTO
            existingBuildingRate.MasterFileId = dto.MasterFileId;
            existingBuildingRate.AssessmentNumber = dto.AssessmentNumber;
            existingBuildingRate.Owner = dto.Owner;
            existingBuildingRate.ConstructedBy = dto.ConstructedBy;
            existingBuildingRate.YearOfConstruction = dto.YearOfConstruction;
            existingBuildingRate.DescriptionOfProperty = dto.DescriptionOfProperty;
            existingBuildingRate.FloorAreaSQFT = dto.FloorAreaSQFT;
            existingBuildingRate.RatePerSQFT = dto.RatePerSQFT;
            existingBuildingRate.Cost = dto.Cost;
            existingBuildingRate.Remarks = dto.Remarks;
            existingBuildingRate.LocationLatitude = dto.LocationLatitude;
            existingBuildingRate.LocationLongitude = dto.LocationLongitude;
            existingBuildingRate.UpdatedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingRatesLAExists(id))
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

        // DELETE: api/BuildingRatesLA/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuildingRateLA(int id)
        {
            var buildingRate = await _context.BuildingRatesLA.FindAsync(id);

            if (buildingRate == null)
            {
                return NotFound();
            }

            // Also delete the associated report
            var report = await _context.Reports.FindAsync(buildingRate.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.BuildingRatesLA.Remove(buildingRate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/BuildingRatesLA/ByReport/{reportId}
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<BuildingRatesLAResponseDto>> GetBuildingRateLAByReportId(int reportId)
        {
            var buildingRate = await _context.BuildingRatesLA
                .FirstOrDefaultAsync(br => br.ReportId == reportId);

            if (buildingRate == null)
            {
                return NotFound();
            }

            return MapToResponseDto(buildingRate);
        }

        private bool BuildingRatesLAExists(int id)
        {
            return _context.BuildingRatesLA.Any(e => e.Id == id);
        }

        private BuildingRatesLAResponseDto MapToResponseDto(BuildingRatesLA buildingRate)
        {
            return new BuildingRatesLAResponseDto
            {
                Id = buildingRate.Id,
                ReportId = buildingRate.ReportId,
                MasterFileId = buildingRate.MasterFileId,
                AssessmentNumber = buildingRate.AssessmentNumber,
                Owner = buildingRate.Owner,
                ConstructedBy = buildingRate.ConstructedBy,
                YearOfConstruction = buildingRate.YearOfConstruction,
                DescriptionOfProperty = buildingRate.DescriptionOfProperty,
                FloorAreaSQFT = buildingRate.FloorAreaSQFT,
                RatePerSQFT = buildingRate.RatePerSQFT,
                Cost = buildingRate.Cost,
                Remarks = buildingRate.Remarks,
                LocationLatitude = buildingRate.LocationLatitude,
                LocationLongitude = buildingRate.LocationLongitude,
                CreatedAt = buildingRate.CreatedAt,
                UpdatedAt = buildingRate.UpdatedAt
            };
        }
    }
}