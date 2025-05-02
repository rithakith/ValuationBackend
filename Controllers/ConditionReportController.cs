using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        
    }
}