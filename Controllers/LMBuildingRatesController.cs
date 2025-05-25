using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LMBuildingRatesController : ControllerBase
    {
        private readonly ILMBuildingRatesService _lmBuildingRatesService;

        public LMBuildingRatesController(ILMBuildingRatesService lmBuildingRatesService)
        {
            _lmBuildingRatesService = lmBuildingRatesService;
        }        // GET: api/LMBuildingRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMBuildingRatesResponseDto>>> GetLMBuildingRates()
        {
            var rates = await _lmBuildingRatesService.GetAllAsync();
            return Ok(rates);
        }        // GET: api/LMBuildingRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LMBuildingRatesResponseDto>> GetLMBuildingRate(int id)
        {
            var lmBuildingRate = await _lmBuildingRatesService.GetByIdAsync(id);

            if (lmBuildingRate == null)
            {
                return NotFound();
            }

            return lmBuildingRate;
        }        // POST: api/LMBuildingRates
        [HttpPost]
        public async Task<ActionResult<LMBuildingRatesResponseDto>> CreateLMBuildingRate(LMBuildingRatesCreateDto dto)
        {
            var createdLMBuildingRate = await _lmBuildingRatesService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetLMBuildingRate), new { id = createdLMBuildingRate.Id }, createdLMBuildingRate);
        }        // PUT: api/LMBuildingRates/5
        [HttpPut("{reportId}")]
        public async Task<IActionResult> UpdateLMBuildingRate(int reportId, LMBuildingRatesUpdateDto dto)
        {
            if (reportId != dto.ReportId)
            {
                return BadRequest("Report ID in URL must match Report ID in body.");
            }

            var success = await _lmBuildingRatesService.UpdateAsync(reportId, dto);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }        // DELETE: api/LMBuildingRates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLMBuildingRate(int id)
        {
            var success = await _lmBuildingRatesService.DeleteAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }        // GET: api/LMBuildingRates/ByReport/5
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<LMBuildingRatesResponseDto>> GetLMBuildingRateByReportId(int reportId)
        {
            var lmBuildingRate = await _lmBuildingRatesService.GetByReportIdAsync(reportId);

            if (lmBuildingRate == null)
            {
                return NotFound();
            }

            return lmBuildingRate;
        }
    }
}
