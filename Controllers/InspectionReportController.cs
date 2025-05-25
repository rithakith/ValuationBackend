using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionReportController : ControllerBase
    {
        private readonly IInspectionReportService _inspectionReportService;

        public InspectionReportController(IInspectionReportService inspectionReportService)
        {
            _inspectionReportService = inspectionReportService;
        }

        // GET: api/InspectionReport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectionReportResponseDto>>> GetInspectionReports()
        {
            var reports = await _inspectionReportService.GetAllAsync();
            return Ok(reports);
        }

        // GET: api/InspectionReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionReportResponseDto>> GetInspectionReport(int id)
        {
            var inspectionReport = await _inspectionReportService.GetByIdAsync(id);

            if (inspectionReport == null)
            {
                return NotFound();
            }

            return Ok(inspectionReport);
        }

        // POST: api/InspectionReport
        [HttpPost]
        public async Task<ActionResult<InspectionReportResponseDto>> CreateInspectionReport(InspectionReportCreateDto dto)
        {
            var createdReport = await _inspectionReportService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetInspectionReport), new { id = createdReport.InspectionReportId }, createdReport);
        }

        // PUT: api/InspectionReport/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInspectionReport(int id, InspectionReportUpdateDto dto)
        {
            var success = await _inspectionReportService.UpdateAsync(id, dto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/InspectionReport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspectionReport(int id)
        {
            var success = await _inspectionReportService.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        // GET: api/InspectionReport/ByReport/5
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<InspectionReportResponseDto>> GetInspectionReportByReportId(int reportId)
        {
            var inspectionReport = await _inspectionReportService.GetByReportIdAsync(reportId);

            if (inspectionReport == null)
            {
                return NotFound();
            }

            return Ok(inspectionReport);
        }
    }
}
