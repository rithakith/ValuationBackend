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
    public class BuildingRatesLAController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BuildingRatesLAController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitBuildingRatesLA([FromBody] BuildingRatesLA buildingRates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            buildingRates.CreatedAt = DateTime.UtcNow;
            _context.BuildingRatesLA.Add(buildingRates);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Building rates saved successfully", buildingRatesId = buildingRates.Id });
        }

        [HttpPut("edit/{id}")]
        [HttpPatch("edit/{id}")]
        public async Task<IActionResult> EditBuildingRatesLA(int id, [FromBody] BuildingRatesLA buildingRates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the existing building rates
            var existingBuildingRates = await _context.BuildingRatesLA.FindAsync(id);
            if (existingBuildingRates == null)
            {
                return NotFound($"Building rates with ID {id} not found");
            }

            // Set the correct ID in the building rates object
            buildingRates.Id = id;
            buildingRates.CreatedAt = existingBuildingRates.CreatedAt;
            buildingRates.UpdatedAt = DateTime.UtcNow;
            
            // Update the existing building rates with new values
            _context.Entry(existingBuildingRates).CurrentValues.SetValues(buildingRates);
            
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Building rates updated successfully", buildingRatesId = id });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingRatesLAExists(id))
                {
                    return NotFound($"Building rates with ID {id} not found");
                }
                else
                {
                    throw;
                }
            }
        }

        private bool BuildingRatesLAExists(int id)
        {
            return _context.BuildingRatesLA.Any(e => e.Id == id);
        }
    }
}