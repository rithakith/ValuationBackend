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
    public class PastValuationsLAController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PastValuationsLAController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitPastValuationsLA([FromBody] PastValuationsLA pastValuation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pastValuation.CreatedAt = DateTime.UtcNow;
            _context.PastValuationsLA.Add(pastValuation);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Past valuation saved successfully", pastValuationId = pastValuation.Id });
        }

        [HttpPut("edit/{id}")]
        [HttpPatch("edit/{id}")]
        public async Task<IActionResult> EditPastValuationsLA(int id, [FromBody] PastValuationsLA pastValuation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the existing past valuation
            var existingPastValuation = await _context.PastValuationsLA.FindAsync(id);
            if (existingPastValuation == null)
            {
                return NotFound($"Past valuation with ID {id} not found");
            }

            // Set the correct ID in the past valuation object
            pastValuation.Id = id;
            pastValuation.CreatedAt = existingPastValuation.CreatedAt;
            pastValuation.UpdatedAt = DateTime.UtcNow;
            
            // Update the existing past valuation with new values
            _context.Entry(existingPastValuation).CurrentValues.SetValues(pastValuation);
            
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Past valuation updated successfully", pastValuationId = id });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastValuationsLAExists(id))
                {
                    return NotFound($"Past valuation with ID {id} not found");
                }
                else
                {
                    throw;
                }
            }
        }

        private bool PastValuationsLAExists(int id)
        {
            return _context.PastValuationsLA.Any(e => e.Id == id);
        }
    }
}