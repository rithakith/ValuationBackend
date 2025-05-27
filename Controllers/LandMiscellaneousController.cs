using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Models;
using ValuationBackend.Services; // Added for the service layer
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq; // Added for Any()
using System;

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
        public async Task<ActionResult<IEnumerable<LandMiscellaneousMasterFile>>> GetAll(
            [FromQuery] string sortBy = "")
        {
            var landMiscellaneousList = await _landMiscellaneousService.GetAllAsync(sortBy);
            return Ok(landMiscellaneousList);
        }

        [HttpGet("paginated")]
        public async Task<ActionResult> GetPaginated(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "")
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            var (records, totalCount) = await _landMiscellaneousService.GetPaginatedAsync(pageNumber, pageSize, sortBy);

            return Ok(new
            {
                Records = records,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                SortBy = sortBy
            });
        }

        [HttpGet("search")]
        public async Task<ActionResult> Search(
            [FromQuery] string searchTerm = "",
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "")
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            var (records, totalCount) = await _landMiscellaneousService.SearchAsync(searchTerm, pageNumber, pageSize, sortBy);

            // Always return the same format, even when no records are found
            return Ok(new
            {
                Records = records ?? new List<LandMiscellaneousMasterFile>(),
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                SearchTerm = searchTerm,
                SortBy = sortBy
            });
        }
    }
}