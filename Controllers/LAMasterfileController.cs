using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LAMasterfileController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LAMasterfileController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<LAMasterfileResponse> GetAll()
        {
            var data = _context.LandAquisitionMasterFiles.ToList();
            return Ok(new LAMasterfileResponse { MasterFiles = data });
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
