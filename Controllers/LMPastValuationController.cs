using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LMPastValuationController : ControllerBase
    {
        private readonly ILMPastValuationService _lmPastValuationService;

        public LMPastValuationController(ILMPastValuationService lmPastValuationService)
        {
            _lmPastValuationService = lmPastValuationService;
        }

        // GET: api/LMPastValuation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMPastValuationResponseDto>>> GetLMPastValuations()
        {
            var valuations = await _lmPastValuationService.GetAllAsync();
            return Ok(valuations);
        }

        // GET: api/LMPastValuation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LMPastValuationResponseDto>> GetLMPastValuation(int id)
        {
            var lmPastValuation = await _lmPastValuationService.GetByIdAsync(id);

            if (lmPastValuation == null)
            {
                return NotFound();
            }

            return lmPastValuation;
        }

        // POST: api/LMPastValuation
        [HttpPost]
        public async Task<ActionResult<LMPastValuationResponseDto>> CreateLMPastValuation(LMPastValuationCreateDto dto)
        {
            var createdLMPastValuation = await _lmPastValuationService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetLMPastValuation), new { id = createdLMPastValuation.Id }, createdLMPastValuation);
        }

        // PUT: api/LMPastValuation/5
        [HttpPut("{reportId}")]
        public async Task<IActionResult> UpdateLMPastValuation(int reportId, LMPastValuationUpdateDto dto)
        {
            if (reportId != dto.ReportId)
            {
                return BadRequest("Report ID in URL must match Report ID in body.");
            }

            var success = await _lmPastValuationService.UpdateAsync(reportId, dto);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/LMPastValuation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLMPastValuation(int id)
        {
            var success = await _lmPastValuationService.DeleteAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/LMPastValuation/ByReport/5
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<LMPastValuationResponseDto>> GetLMPastValuationByReportId(int reportId)
        {
            var lmPastValuation = await _lmPastValuationService.GetByReportIdAsync(reportId);

            if (lmPastValuation == null)
            {
                return NotFound();
            }

            return lmPastValuation;
        }
    }
}
