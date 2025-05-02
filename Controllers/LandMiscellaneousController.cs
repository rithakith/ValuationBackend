using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValuationBackend.Data;
using ValuationBackend.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LandMiscellaneousController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LandMiscellaneousController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<LandMiscellaneousMasterFile>>> GetAll()
        {
            var landMiscellaneousList = await _context.LandMiscellaneousMasterFiles.ToListAsync();
            return Ok(landMiscellaneousList);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<LandMiscellaneousMasterFile>> GetById(int id)
        {
            var landMiscellaneous = await _context.LandMiscellaneousMasterFiles.FindAsync(id);
            
            if (landMiscellaneous == null)
            {
                return NotFound();
            }
            
            return landMiscellaneous;
        }

        [HttpGet("search/masterfileno/{masterFileNo}")]
        public async Task<ActionResult<IEnumerable<LandMiscellaneousMasterFile>>> SearchByMasterFileNo(int masterFileNo)
        {
            var results = await _context.LandMiscellaneousMasterFiles
                .Where(l => l.MasterFileNo == masterFileNo)
                .ToListAsync();
            
            if (results == null || !results.Any())
            {
                return NotFound($"No land miscellaneous files found with Master File No: {masterFileNo}");
            }
            
            return Ok(results);
        }
    }
}