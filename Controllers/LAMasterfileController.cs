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
            return Ok(_service.Search(request.Query));
        }
    }
}
