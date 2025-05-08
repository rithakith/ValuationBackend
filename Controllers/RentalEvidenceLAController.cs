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
    public class RentalEvidenceLAController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RentalEvidenceLAController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitRentalEvidenceLA([FromBody] RentalEvidenceLA evidence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            evidence.CreatedAt = DateTime.UtcNow;
            _context.RentalEvidencesLA.Add(evidence);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Rental evidence saved successfully", evidenceId = evidence.Id });
        }

        [HttpPut("edit/{id}")]
        [HttpPatch("edit/{id}")]
        public async Task<IActionResult> EditRentalEvidenceLA(int id, [FromBody] RentalEvidenceLA evidence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the existing evidence
            var existingEvidence = await _context.RentalEvidencesLA.FindAsync(id);
            if (existingEvidence == null)
            {
                return NotFound($"Rental evidence with ID {id} not found");
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
                return Ok(new { message = "Rental evidence updated successfully", evidenceId = id });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalEvidenceLAExists(id))
                {
                    return NotFound($"Rental evidence with ID {id} not found");
                }
                else
                {
                    throw;
                }
            }
        }

        private bool RentalEvidenceLAExists(int id)
        {
            return _context.RentalEvidencesLA.Any(e => e.Id == id);
        }
    }
}