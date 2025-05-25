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
        public ActionResult<LAMasterfileResponse> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost("search")]
        [HttpPost("filter")]
        public ActionResult<LAMasterfileResponse> Search([FromBody] LAQueryRequest request)
        {
            var query = request.Query.ToLower();
            var data = _context.LandAquisitionMasterFiles
                .Where(f =>
                    f.MasterFileNo.ToString().Contains(query) ||
                    f.MasterFilesRefNo.ToLower().Contains(query) ||
                    f.PlanNo.ToLower().Contains(query) ||
                    f.PlanType.ToLower().Contains(query) ||
                    f.RequestingAuthorityReferenceNo.ToLower().Contains(query) ||
                    f.Status.ToLower().Contains(query))
                .ToList();

            return Ok(new LAMasterfileResponse { MasterFiles = data });
        }
    }
}
