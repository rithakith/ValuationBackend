using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Models;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LAMasterfileController : ControllerBase
    {
        private readonly ILAMasterfileService _service;

        public LAMasterfileController(ILAMasterfileService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<LAMasterfileResponse> GetAll([FromQuery] int pageNumber = 0, [FromQuery] int pageSize = 15, [FromQuery] string sortBy = "", [FromQuery] int? assignedToUserId = null)
        {
            // Adjust pageNumber to be 1-based for internal logic
            var page = pageNumber + 1;
            return Ok(_service.GetPaged(page, pageSize, sortBy, assignedToUserId));
        }

        [HttpGet("paged")]
        public ActionResult<LAMasterfileResponse> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortBy = "", [FromQuery] int? assignedToUserId = null)
        {
            return Ok(_service.GetPaged(page, pageSize, sortBy, assignedToUserId));
        }

        [HttpPost("search")]
        [HttpPost("filter")]
        public ActionResult<LAMasterfileResponse> Search([FromBody] LAQueryRequest request, [FromQuery] string sortBy = "", [FromQuery] int? assignedToUserId = null)
        {
            var query = request.Query.ToLower();
            var response = _service.Search(query, sortBy, assignedToUserId);
            return Ok(response);
        }

        [HttpPost("search/paged")]
        public ActionResult<LAMasterfileResponse> SearchPaged([FromBody] LAQueryRequest request, [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortBy = "", [FromQuery] int? assignedToUserId = null)
        {
            var query = request.Query.ToLower();
            var response = _service.SearchPaged(query, page, pageSize, sortBy, assignedToUserId);
            return Ok(response);
        }
    }
}
