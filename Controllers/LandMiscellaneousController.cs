using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Models;
using ValuationBackend.Services; // Added for the service layer
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq; // Added for Any()

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LandMiscellaneousController : ControllerBase
    {
        private readonly ILandMiscellaneousService _landMiscellaneousService;

        public LandMiscellaneousController(ILandMiscellaneousService landMiscellaneousService)
        {
            _landMiscellaneousService = landMiscellaneousService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<LandMiscellaneousMasterFile>>> GetAll()
        {
            var landMiscellaneousList = await _landMiscellaneousService.GetAllAsync();
            return Ok(landMiscellaneousList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LandMiscellaneousMasterFile>> GetById(int id)
        {
            var landMiscellaneous = await _landMiscellaneousService.GetByIdAsync(id);

            if (landMiscellaneous == null)
            {
                return NotFound();
            }

            return Ok(landMiscellaneous);
        }

        [HttpGet("search/masterfileno/{masterFileNo}")]
        public async Task<ActionResult<IEnumerable<LandMiscellaneousMasterFile>>> SearchByMasterFileNo(int masterFileNo)
        {
            var results = await _landMiscellaneousService.SearchByMasterFileNoAsync(masterFileNo);

            if (results == null || !results.Any())
            {
                return NotFound($"No land miscellaneous files found with Master File No: {masterFileNo}");
            }

            return Ok(results);
        }
    }
}