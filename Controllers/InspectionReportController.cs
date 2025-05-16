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
    public class InspectionReportController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InspectionReportController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/InspectionReport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectionReportResponseDto>>> GetInspectionReports()
        {
            var reports = await _context.InspectionReports
                .Include(ir => ir.Buildings)
                .ToListAsync();

            return reports.Select(MapToResponseDto).ToList();
        }

        // GET: api/InspectionReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionReportResponseDto>> GetInspectionReport(int id)
        {
            var inspectionReport = await _context.InspectionReports
                .Include(ir => ir.Buildings)
                .FirstOrDefaultAsync(ir => ir.InspectionReportId == id);

            if (inspectionReport == null)
            {
                return NotFound();
            }

            return MapToResponseDto(inspectionReport);
        }

        // POST: api/InspectionReport
        [HttpPost]
        public async Task<ActionResult<InspectionReportResponseDto>> CreateInspectionReport(InspectionReportCreateDto dto)
        {
            // Create a new Report for this inspection
            var report = new Report
            {
                ReportType = "LM_inspection",
                Timestamp = DateTime.UtcNow,
                Description = $"Land Miscellaneous Inspection Report for {dto.MasterFileRefNo}"
            };

            // Add the report first
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            // Create the inspection report entity from the DTO
            var inspectionReport = new InspectionReport
            {
                ReportId = report.ReportId,
                MasterFileId = dto.MasterFileId,
                MasterFileRefNo = dto.MasterFileRefNo,
                InspectionDate = dto.InspectionDate,
                DsDivision = dto.DsDivision,
                District = dto.District,
                Province = dto.Province,
                GnDivision = dto.GnDivision,
                Village = dto.Village,
                OtherInformation = dto.OtherInformation,
                OtherConstructionDetails = dto.OtherConstructionDetails,
                DetailsOfAssestsInventoryItems = dto.DetailsOfAssestsInventoryItems,
                DetailsOfBusiness = dto.DetailsOfBusiness,
                Remark = dto.Remark
            };

            // Add buildings from the DTO
            foreach (var buildingDto in dto.Buildings)
            {
                var building = MapDtoToBuilding(buildingDto);
                inspectionReport.Buildings.Add(building);
            }
            
            // Add the inspection report to the context
            _context.InspectionReports.Add(inspectionReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInspectionReport), 
                new { id = inspectionReport.InspectionReportId }, 
                MapToResponseDto(inspectionReport));
        }

        // PUT: api/InspectionReport/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInspectionReport(int id, InspectionReportUpdateDto dto)
        {
            // Verify report exists
            var existingReport = await _context.InspectionReports
                .Include(ir => ir.Buildings)
                .FirstOrDefaultAsync(ir => ir.InspectionReportId == id);

            if (existingReport == null)
            {
                return NotFound();
            }

            // Update existing report with data from DTO
            existingReport.MasterFileId = dto.MasterFileId;
            existingReport.MasterFileRefNo = dto.MasterFileRefNo;
            existingReport.InspectionDate = dto.InspectionDate;
            existingReport.DsDivision = dto.DsDivision;
            existingReport.District = dto.District;
            existingReport.Province = dto.Province;
            existingReport.GnDivision = dto.GnDivision;
            existingReport.Village = dto.Village;
            existingReport.OtherInformation = dto.OtherInformation;
            existingReport.OtherConstructionDetails = dto.OtherConstructionDetails;
            existingReport.DetailsOfAssestsInventoryItems = dto.DetailsOfAssestsInventoryItems;
            existingReport.DetailsOfBusiness = dto.DetailsOfBusiness;
            existingReport.Remark = dto.Remark;

            // Handle the buildings - remove any that are no longer present
            var buildingsToKeep = new List<InspectionBuilding>();
            
            foreach (var buildingDto in dto.Buildings)
            {
                if (buildingDto.Id.HasValue && buildingDto.Id.Value > 0)
                {
                    // Update existing building
                    var existingBuilding = existingReport.Buildings.FirstOrDefault(b => b.Id == buildingDto.Id.Value);
                    if (existingBuilding != null)
                    {
                        // Update properties
                        UpdateBuildingFromDto(existingBuilding, buildingDto);
                        buildingsToKeep.Add(existingBuilding);
                    }
                }
                else
                {
                    // Add new building
                    var newBuilding = MapDtoToBuilding(buildingDto);
                    newBuilding.InspectionReportId = id;
                    _context.InspectionBuildings.Add(newBuilding);
                    buildingsToKeep.Add(newBuilding);
                }
            }

            // Remove buildings that weren't in the DTO
            foreach (var building in existingReport.Buildings.ToList())
            {
                if (!buildingsToKeep.Contains(building))
                {
                    _context.InspectionBuildings.Remove(building);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionReportExists(id))
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

        // DELETE: api/InspectionReport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspectionReport(int id)
        {
            var inspectionReport = await _context.InspectionReports
                .Include(ir => ir.Buildings)
                .FirstOrDefaultAsync(ir => ir.InspectionReportId == id);

            if (inspectionReport == null)
            {
                return NotFound();
            }

            // Delete associated buildings and report
            _context.InspectionBuildings.RemoveRange(inspectionReport.Buildings);
            _context.InspectionReports.Remove(inspectionReport);

            // Also delete the associated report
            var report = await _context.Reports.FindAsync(inspectionReport.ReportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/InspectionReport/ByReport/5
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<InspectionReportResponseDto>> GetInspectionReportByReportId(int reportId)
        {
            var inspectionReport = await _context.InspectionReports
                .Include(ir => ir.Buildings)
                .FirstOrDefaultAsync(ir => ir.ReportId == reportId);

            if (inspectionReport == null)
            {
                return NotFound();
            }

            return MapToResponseDto(inspectionReport);
        }

        private bool InspectionReportExists(int id)
        {
            return _context.InspectionReports.Any(e => e.InspectionReportId == id);
        }

        private InspectionReportResponseDto MapToResponseDto(InspectionReport report)
        {
            return new InspectionReportResponseDto
            {
                InspectionReportId = report.InspectionReportId,
                ReportId = report.ReportId,
                MasterFileId = report.MasterFileId,
                MasterFileRefNo = report.MasterFileRefNo,
                InspectionDate = report.InspectionDate,
                DsDivision = report.DsDivision,
                District = report.District,
                Province = report.Province,
                GnDivision = report.GnDivision,
                Village = report.Village,
                OtherInformation = report.OtherInformation,
                OtherConstructionDetails = report.OtherConstructionDetails,
                DetailsOfAssestsInventoryItems = report.DetailsOfAssestsInventoryItems,
                DetailsOfBusiness = report.DetailsOfBusiness,
                Remark = report.Remark,
                Buildings = report.Buildings.Select(b => new BuildingDto
                {
                    Id = b.Id,
                    BuildingId = b.BuildingId,
                    BuildingName = b.BuildingName,
                    BuildingCategory = b.BuildingCategory,
                    BuildingClass = b.BuildingClass,
                    DetailOfBuilding = b.DetailOfBuilding,
                    NoOfFloorsAboveGround = b.NoOfFloorsAboveGround,
                    NoOfFloorsBelowGround = b.NoOfFloorsBelowGround,
                    AgeYears = b.AgeYears,
                    ExpectedLifePeriodYears = b.ExpectedLifePeriodYears,
                    ParkingSpace = b.ParkingSpace,
                    Design = b.Design,
                    Conveniences = b.Conveniences,
                    Structure = b.Structure,
                    BuildingConditions = b.BuildingConditions,
                    NatureOfConstruction = b.NatureOfConstruction,
                    Condition = b.Condition,
                    RoofMaterial = b.RoofMaterial,
                    RoofFrame = b.RoofFrame,
                    RoofFinisher = b.RoofFinisher,
                    Ceiling = b.Ceiling,
                    FoundationStructure = b.FoundationStructure,
                    WallStructure = b.WallStructure,
                    FloorStructure = b.FloorStructure,
                    Door = b.Door,
                    Window = b.Window,
                    WindowProtection = b.WindowProtection,
                    BathroomToiletDoorsFittings = b.BathroomToiletDoorsFittings,
                    HandRail = b.HandRail,
                    PantryCupboard = b.PantryCupboard,
                    OtherDoors = b.OtherDoors,
                    WallFinisher = b.WallFinisher,
                    FloorFinisher = b.FloorFinisher,
                    BathroomToilet = b.BathroomToilet,
                    Services = b.Services
                }).ToList()
            };
        }

        private InspectionBuilding MapDtoToBuilding(BuildingDto dto)
        {
            return new InspectionBuilding
            {
                BuildingId = dto.BuildingId,
                BuildingName = dto.BuildingName,
                BuildingCategory = dto.BuildingCategory,
                BuildingClass = dto.BuildingClass,
                DetailOfBuilding = dto.DetailOfBuilding,
                NoOfFloorsAboveGround = dto.NoOfFloorsAboveGround,
                NoOfFloorsBelowGround = dto.NoOfFloorsBelowGround,
                AgeYears = dto.AgeYears,
                ExpectedLifePeriodYears = dto.ExpectedLifePeriodYears,
                ParkingSpace = dto.ParkingSpace,
                Design = dto.Design,
                Conveniences = dto.Conveniences,
                Structure = dto.Structure,
                BuildingConditions = dto.BuildingConditions,
                NatureOfConstruction = dto.NatureOfConstruction,
                Condition = dto.Condition,
                RoofMaterial = dto.RoofMaterial,
                RoofFrame = dto.RoofFrame,
                RoofFinisher = dto.RoofFinisher,
                Ceiling = dto.Ceiling,
                FoundationStructure = dto.FoundationStructure,
                WallStructure = dto.WallStructure,
                FloorStructure = dto.FloorStructure,
                Door = dto.Door,
                Window = dto.Window,
                WindowProtection = dto.WindowProtection,
                BathroomToiletDoorsFittings = dto.BathroomToiletDoorsFittings,
                HandRail = dto.HandRail,
                PantryCupboard = dto.PantryCupboard,
                OtherDoors = dto.OtherDoors,
                WallFinisher = dto.WallFinisher,
                FloorFinisher = dto.FloorFinisher,
                BathroomToilet = dto.BathroomToilet,
                Services = dto.Services
            };
        }

        private void UpdateBuildingFromDto(InspectionBuilding building, BuildingDto dto)
        {
            building.BuildingId = dto.BuildingId;
            building.BuildingName = dto.BuildingName;
            building.BuildingCategory = dto.BuildingCategory;
            building.BuildingClass = dto.BuildingClass;
            building.DetailOfBuilding = dto.DetailOfBuilding;
            building.NoOfFloorsAboveGround = dto.NoOfFloorsAboveGround;
            building.NoOfFloorsBelowGround = dto.NoOfFloorsBelowGround;
            building.AgeYears = dto.AgeYears;
            building.ExpectedLifePeriodYears = dto.ExpectedLifePeriodYears;
            building.ParkingSpace = dto.ParkingSpace;
            building.Design = dto.Design;
            building.Conveniences = dto.Conveniences;
            building.Structure = dto.Structure;
            building.BuildingConditions = dto.BuildingConditions;
            building.NatureOfConstruction = dto.NatureOfConstruction;
            building.Condition = dto.Condition;
            building.RoofMaterial = dto.RoofMaterial;
            building.RoofFrame = dto.RoofFrame;
            building.RoofFinisher = dto.RoofFinisher;
            building.Ceiling = dto.Ceiling;
            building.FoundationStructure = dto.FoundationStructure;
            building.WallStructure = dto.WallStructure;
            building.FloorStructure = dto.FloorStructure;
            building.Door = dto.Door;
            building.Window = dto.Window;
            building.WindowProtection = dto.WindowProtection;
            building.BathroomToiletDoorsFittings = dto.BathroomToiletDoorsFittings;
            building.HandRail = dto.HandRail;
            building.PantryCupboard = dto.PantryCupboard;
            building.OtherDoors = dto.OtherDoors;
            building.WallFinisher = dto.WallFinisher;
            building.FloorFinisher = dto.FloorFinisher;
            building.BathroomToilet = dto.BathroomToilet;
            building.Services = dto.Services;
        }
    }
}
