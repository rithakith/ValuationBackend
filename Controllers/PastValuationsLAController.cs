using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PastValuationsLAController : ControllerBase
    {
        private readonly IPastValuationsLAService _pastValuationsService;

        public PastValuationsLAController(IPastValuationsLAService pastValuationsService)
        {
            _pastValuationsService = pastValuationsService;
        }

        // GET: api/PastValuationsLA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PastValuationsLAReadDto>>> GetPastValuationsLA()
        {
            var pastValuations = await _pastValuationsService.GetAllPastValuationsAsync();
            return Ok(pastValuations);
        }

        // GET: api/PastValuationsLA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PastValuationsLAReadDto>> GetPastValuationLA(int id)
        {
            var pastValuation = await _pastValuationsService.GetPastValuationByIdAsync(id);

            if (pastValuation == null)
            {
                return NotFound();
            }

            return Ok(pastValuation);
        }

        // POST: api/PastValuationsLA
        [HttpPost]
        public async Task<ActionResult<PastValuationsLACreationResponseDto>> CreatePastValuationLA(PastValuationsLACreateDto dto)
        {
            var createdPastValuation = await _pastValuationsService.CreatePastValuationAsync(dto);
            
            // Return the custom response format with msg and reportId
            var response = new PastValuationsLACreationResponseDto
            {
                Msg = "success",
                ReportId = createdPastValuation.ReportId // Using the common report table ID
            };
            
            return Ok(response);
        }

        // PUT: api/PastValuationsLA/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePastValuationLA(int id, PastValuationsLAUpdateDto dto)
        {
            var updatedPastValuation = await _pastValuationsService.UpdatePastValuationAsync(id, dto);

            if (updatedPastValuation == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/PastValuationsLA/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePastValuationLA(int id)
        {
            var result = await _pastValuationsService.DeletePastValuationAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/PastValuationsLA/ByReport/{reportId}
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<PastValuationsLAReadDto>> GetPastValuationLAByReportId(int reportId)
        {
            var pastValuation = await _pastValuationsService.GetPastValuationByReportIdAsync(reportId);

            if (pastValuation == null)
            {
                return NotFound();
            }

            return Ok(pastValuation);
        }
    }
}
