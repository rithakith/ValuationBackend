using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Models;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _service;

        public RequestsController(IRequestService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Request>> GetAll()
        {
            try
            {
                var requests = _service.GetAllRequests();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("by-request-type/{requestTypeId}")]
        public ActionResult<List<Request>> GetByRequestTypeId(int requestTypeId)
        {
            try
            {
                var requests = _service.GetRequestsByRequestTypeId(requestTypeId);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }        [HttpGet("by-status/{status}/request-type/{requestTypeId}")]
        public ActionResult<List<Request>> GetByStatus(bool status, int requestTypeId)
        {
            try
            {
                var requests = _service.GetRequestsByStatus(status, requestTypeId);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }        [HttpGet("by-year/{year}/request-type/{requestTypeId}")]
        public ActionResult<List<Request>> GetByYearOfRevision(int year, int requestTypeId)
        {
            try
            {
                var requests = _service.GetRequestsByYearOfRevision(year, requestTypeId);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }        [HttpGet("by-rating-reference/{ratingReferenceNo}/request-type/{requestTypeId}")]
        public ActionResult<List<Request>> GetByRatingReferenceNo(string ratingReferenceNo, int requestTypeId)
        {
            try
            {
                var requests = _service.GetRequestsByRatingReferenceNo(ratingReferenceNo, requestTypeId);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}