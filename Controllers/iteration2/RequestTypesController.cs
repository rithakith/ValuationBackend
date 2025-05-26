using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Models;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestTypesController : ControllerBase
    {
        private readonly IRequestTypeService _service;

        public RequestTypesController(IRequestTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<RequestType>> GetAll()
        {
            var requestTypes = _service.GetAllRequestTypes();
            return Ok(requestTypes);
        }
    }
}
