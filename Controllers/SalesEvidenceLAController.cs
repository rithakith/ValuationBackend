using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;
using System;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesEvidenceLAController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalesEvidenceLAController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitSalesEvidenceLA([FromBody] SalesEvidenceLA evidence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            evidence.CreatedAt = DateTime.UtcNow;
            _context.SalesEvidencesLA.Add(evidence);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Sales evidence saved successfully", evidenceId = evidence.Id });
        }

        [HttpPut("edit/{id}")]
        [HttpPatch("edit/{id}")]
        public async Task<IActionResult> EditSalesEvidenceLA(int id, [FromBody] SalesEvidenceLA evidence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the existing evidence
            var existingEvidence = await _context.SalesEvidencesLA.FindAsync(id);
            if (existingEvidence == null)
            {
                return NotFound($"Sales evidence with ID {id} not found");
            }

            // Set the correct ID in the evidence object
            evidence.Id = id;
            evidence.CreatedAt = existingEvidence.CreatedAt;
            evidence.UpdatedAt = DateTime.UtcNow;
            
            // Update the existing evidence with new values
            _context.Entry(existingEvidence).CurrentValues.SetValues(evidence);
            
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Sales evidence updated successfully", evidenceId = id });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesEvidenceLAExists(id))
                {
                    return NotFound($"Sales evidence with ID {id} not found");
                }
                else
                {
                    throw;
                }
            }
        }

        private bool SalesEvidenceLAExists(int id)
        {
            return _context.SalesEvidencesLA.Any(e => e.Id == id);
        }
    }
}