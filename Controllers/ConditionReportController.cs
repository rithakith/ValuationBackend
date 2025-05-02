using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

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

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitConditionReport([FromBody] ConditionReport report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ConditionReports.Add(report);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Condition report saved successfully", reportId = report.Id });
        }

        [HttpPut("edit/{id}")]
        [HttpPatch("edit/{id}")]
        public async Task<IActionResult> EditConditionReport(int id, [FromBody] ConditionReport report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the existing report
            var existingReport = await _context.ConditionReports.FindAsync(id);
            if (existingReport == null)
            {
                return NotFound($"Condition report with ID {id} not found");
            }

            // Set the correct ID in the report object
            report.Id = id;
            
            // Update the existing report with new values
            _context.Entry(existingReport).CurrentValues.SetValues(report);
            
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Condition report updated successfully", reportId = id });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConditionReportExists(id))
                {
                    return NotFound($"Condition report with ID {id} not found");
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ConditionReportExists(int id)
        {
            return _context.ConditionReports.Any(e => e.Id == id);
        }
    }
}