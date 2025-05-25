using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }        // GET: api/Report
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetReports()
        {
            var reports = await _reportService.GetAllAsync();
            return Ok(reports);
        }

        // GET: api/Report/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetReport(int id)
        {
            var report = await _reportService.GetByIdAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }        // POST: api/Report
        [HttpPost]
        public async Task<ActionResult<Report>> PostReport(Report report)
        {
            var createdReport = await _reportService.CreateAsync(report);
            return CreatedAtAction(nameof(GetReport), new { id = createdReport.ReportId }, createdReport);
        }        // PUT: api/Report/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReport(int id, Report report)
        {
            if (id != report.ReportId)
            {
                return BadRequest();
            }

            var existingReport = await _reportService.GetByIdAsync(id);
            if (existingReport == null)
            {
                return NotFound();
            }

            await _reportService.UpdateAsync(report);
            return NoContent();
        }        // DELETE: api/Report/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var success = await _reportService.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        private async Task<bool> ReportExists(int id)
        {
            return await _reportService.ExistsAsync(id);
        }
    }
}
