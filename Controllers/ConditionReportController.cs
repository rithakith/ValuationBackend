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
    public class ConditionReportController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConditionReportController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ConditionReport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConditionReportResponseDto>>> GetConditionReports()
        {
            var reports = await _context.ConditionReports.ToListAsync();
            return reports.Select(MapToResponseDto).ToList();
        }

        // GET: api/ConditionReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConditionReportResponseDto>> GetConditionReport(int id)
        {
            var conditionReport = await _context.ConditionReports.FindAsync(id);

            if (conditionReport == null)
            {
                return NotFound();
            }

            return MapToResponseDto(conditionReport);
        }

        // POST: api/ConditionReport
        [HttpPost]
        public async Task<ActionResult<ConditionReportResponseDto>> CreateConditionReport(ConditionReportCreateDto dto)
        {
            // Create a new Report for this condition report
            var report = new Report
            {
                ReportType = "LA_condition",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Acquisition Condition Report for {dto.MasterFileRefNo}"
            };

            // Add the report first
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            // Create the condition report entity from the DTO
            var conditionReport = new ConditionReport
            {
                ReportId = report.ReportId,
                MasterFileId = dto.MasterFileId,
                MasterFileRefNo = dto.MasterFileRefNo,
                NameOfTheVillage = dto.NameOfTheVillage,
                NameOfTheLand = dto.NameOfTheLand,
                AtPlanNumber = dto.AtPlanNumber,
                AtLotNumber = dto.AtLotNumber,
                PpCadNumber = dto.PpCadNumber,
                PpCadLotNumber = dto.PpCadLotNumber,
                AcquiredExtent = dto.AcquiredExtent,
                AssessmentNumber = dto.AssessmentNumber,
                RoadName = dto.RoadName,
                AccessCategory = dto.AccessCategory,
                AccessCategoryDescription = dto.AccessCategoryDescription,
                DescriptionOfLand = dto.DescriptionOfLand,
                LandUseDescription = dto.LandUseDescription,
                LandUseType = dto.LandUseType,
                Frontage = dto.Frontage,
                DepthOfLand = dto.DepthOfLand,
                LevelWithAccess = dto.LevelWithAccess,
                PlantationDetails = dto.PlantationDetails,
                DetailsOfBusiness = dto.DetailsOfBusiness,
                AcquisitionName = dto.AcquisitionName,
                DatePrepared = dto.DatePrepared,
                DateOfSection3BA = dto.DateOfSection3BA,
                BoundaryNorth = dto.BoundaryNorth,
                BoundaryEast = dto.BoundaryEast,
                BoundaryWest = dto.BoundaryWest,
                BoundarySouth = dto.BoundarySouth,
                BoundaryBottom = dto.BoundaryBottom,
                BuildingDescription = dto.BuildingDescription,
                BuildingInfo = dto.BuildingInfo,
                OtherConstructionsDescription = dto.OtherConstructionsDescription,
                OtherConstructionsInfo = dto.OtherConstructionsInfo,
                AcquiringOfficerSignature = dto.AcquiringOfficerSignature,
                GramasewakaSignature = dto.GramasewakaSignature,
                ChiefValuerRepresentativeSignature = dto.ChiefValuerRepresentativeSignature,
                CreatedAt = DateTime.UtcNow
            };
            
            _context.ConditionReports.Add(conditionReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConditionReport), 
                new { id = conditionReport.Id }, 
                MapToResponseDto(conditionReport));
        }

        // PUT: api/ConditionReport/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConditionReport(int id, ConditionReportUpdateDto dto)
        {
            // Verify report exists
            var existingReport = await _context.ConditionReports.FindAsync(id);

            if (existingReport == null)
            {
                return NotFound();
            }

            // Update existing report with data from DTO
            existingReport.MasterFileId = dto.MasterFileId;
            existingReport.MasterFileRefNo = dto.MasterFileRefNo;
            existingReport.NameOfTheVillage = dto.NameOfTheVillage;
            existingReport.NameOfTheLand = dto.NameOfTheLand;
            existingReport.AtPlanNumber = dto.AtPlanNumber;
            existingReport.AtLotNumber = dto.AtLotNumber;
            existingReport.PpCadNumber = dto.PpCadNumber;
            existingReport.PpCadLotNumber = dto.PpCadLotNumber;
            existingReport.AcquiredExtent = dto.AcquiredExtent;
            existingReport.AssessmentNumber = dto.AssessmentNumber;
            existingReport.RoadName = dto.RoadName;
            existingReport.AccessCategory = dto.AccessCategory;
            existingReport.AccessCategoryDescription = dto.AccessCategoryDescription;
            existingReport.DescriptionOfLand = dto.DescriptionOfLand;
            existingReport.LandUseDescription = dto.LandUseDescription;
            existingReport.LandUseType = dto.LandUseType;
            existingReport.Frontage = dto.Frontage;
            existingReport.DepthOfLand = dto.DepthOfLand;
            existingReport.LevelWithAccess = dto.LevelWithAccess;
            existingReport.PlantationDetails = dto.PlantationDetails;
            existingReport.DetailsOfBusiness = dto.DetailsOfBusiness;
            existingReport.AcquisitionName = dto.AcquisitionName;
            existingReport.DatePrepared = dto.DatePrepared;
            existingReport.DateOfSection3BA = dto.DateOfSection3BA;
            existingReport.BoundaryNorth = dto.BoundaryNorth;
            existingReport.BoundaryEast = dto.BoundaryEast;
            existingReport.BoundaryWest = dto.BoundaryWest;
            existingReport.BoundarySouth = dto.BoundarySouth;
            existingReport.BoundaryBottom = dto.BoundaryBottom;
            existingReport.BuildingDescription = dto.BuildingDescription;
            existingReport.BuildingInfo = dto.BuildingInfo;
            existingReport.OtherConstructionsDescription = dto.OtherConstructionsDescription;
            existingReport.OtherConstructionsInfo = dto.OtherConstructionsInfo;
            existingReport.AcquiringOfficerSignature = dto.AcquiringOfficerSignature;
            existingReport.GramasewakaSignature = dto.GramasewakaSignature;
            existingReport.ChiefValuerRepresentativeSignature = dto.ChiefValuerRepresentativeSignature;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConditionReportExists(id))
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

        // DELETE: api/ConditionReport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConditionReport(int id)
        {
            var conditionReport = await _context.ConditionReports.FindAsync(id);

            if (conditionReport == null)
            {
                return NotFound();
            }

            // Also delete the associated report
            var report = await _context.Reports.FindAsync(conditionReport.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            _context.ConditionReports.Remove(conditionReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/ConditionReport/ByReport/{reportId}
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<ConditionReportResponseDto>> GetConditionReportByReportId(int reportId)
        {
            var conditionReport = await _context.ConditionReports
                .FirstOrDefaultAsync(cr => cr.ReportId == reportId);

            if (conditionReport == null)
            {
                return NotFound();
            }

            return MapToResponseDto(conditionReport);
        }

        private bool ConditionReportExists(int id)
        {
            return _context.ConditionReports.Any(e => e.Id == id);
        }

        private ConditionReportResponseDto MapToResponseDto(ConditionReport report)
        {
            return new ConditionReportResponseDto
            {
                Id = report.Id,
                ReportId = report.ReportId,
                MasterFileId = report.MasterFileId,
                MasterFileRefNo = report.MasterFileRefNo,
                NameOfTheVillage = report.NameOfTheVillage,
                NameOfTheLand = report.NameOfTheLand,
                AtPlanNumber = report.AtPlanNumber,
                AtLotNumber = report.AtLotNumber,
                PpCadNumber = report.PpCadNumber,
                PpCadLotNumber = report.PpCadLotNumber,
                AcquiredExtent = report.AcquiredExtent,
                AssessmentNumber = report.AssessmentNumber,
                RoadName = report.RoadName,
                AccessCategory = report.AccessCategory,
                AccessCategoryDescription = report.AccessCategoryDescription,
                DescriptionOfLand = report.DescriptionOfLand,
                LandUseDescription = report.LandUseDescription,
                LandUseType = report.LandUseType,
                Frontage = report.Frontage,
                DepthOfLand = report.DepthOfLand,
                LevelWithAccess = report.LevelWithAccess,
                PlantationDetails = report.PlantationDetails,
                DetailsOfBusiness = report.DetailsOfBusiness,
                AcquisitionName = report.AcquisitionName,
                DatePrepared = report.DatePrepared,
                DateOfSection3BA = report.DateOfSection3BA,
                BoundaryNorth = report.BoundaryNorth,
                BoundaryEast = report.BoundaryEast,
                BoundaryWest = report.BoundaryWest,
                BoundarySouth = report.BoundarySouth,
                BoundaryBottom = report.BoundaryBottom,
                BuildingDescription = report.BuildingDescription,
                BuildingInfo = report.BuildingInfo,
                OtherConstructionsDescription = report.OtherConstructionsDescription,
                OtherConstructionsInfo = report.OtherConstructionsInfo,
                AcquiringOfficerSignature = report.AcquiringOfficerSignature,
                GramasewakaSignature = report.GramasewakaSignature,
                ChiefValuerRepresentativeSignature = report.ChiefValuerRepresentativeSignature,
                CreatedAt = report.CreatedAt
            };
        }
    }
}