using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetNumberChangesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssetNumberChangesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AssetNumberChanges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetNumberChange>>> GetChanges()
        {
            return await _context.AssetNumberChanges.ToListAsync();
        }

        // GET: api/AssetNumberChanges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssetNumberChange>> GetChange(int id)
        {
            var change = await _context.AssetNumberChanges.FindAsync(id);
            if (change == null)
                return NotFound();
            return change;
        }        // POST: api/AssetNumberChanges
        [HttpPost]
        public async Task<ActionResult<AssetNumberChange>> CreateChange(AssetNumberChange change)
        {
            change.ChangedDate = DateTime.UtcNow;
            change.DateOfChange = DateTime.UtcNow;
            _context.AssetNumberChanges.Add(change);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetChange), new { id = change.Id }, change);
        }        // PUT: api/AssetNumberChanges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChange(int id, AssetNumberChange change)
        {
            if (id != change.Id)
                return BadRequest();

            // Ensure UTC timestamps
            if (change.ChangedDate.HasValue && change.ChangedDate.Value.Kind != DateTimeKind.Utc)
                change.ChangedDate = DateTime.SpecifyKind(change.ChangedDate.Value, DateTimeKind.Utc);
            
            if (change.DateOfChange.Kind != DateTimeKind.Utc)
                change.DateOfChange = DateTime.SpecifyKind(change.DateOfChange, DateTimeKind.Utc);

            _context.Entry(change).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AssetNumberChanges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChange(int id)
        {
            var change = await _context.AssetNumberChanges.FindAsync(id);
            if (change == null)
                return NotFound();

            _context.AssetNumberChanges.Remove(change);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
