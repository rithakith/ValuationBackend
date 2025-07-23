using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LMSalesEvidenceController : ControllerBase
    {
        private readonly ILMSalesEvidenceService _lmSalesEvidenceService;

        public LMSalesEvidenceController(ILMSalesEvidenceService lmSalesEvidenceService)
        {
            _lmSalesEvidenceService = lmSalesEvidenceService;
        }

        // GET: api/LMSalesEvidence
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMSalesEvidenceResponseDto>>> GetLMSalesEvidences()
        {
            var evidences = await _lmSalesEvidenceService.GetAllAsync();
            return Ok(evidences);
        }

        // GET: api/LMSalesEvidence/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LMSalesEvidenceResponseDto>> GetLMSalesEvidence(int id)
        {
            var lmSalesEvidence = await _lmSalesEvidenceService.GetByIdAsync(id);

            if (lmSalesEvidence == null)
            {
                return NotFound();
            }

            return lmSalesEvidence;
        }

        // POST: api/LMSalesEvidence
        [HttpPost]
        public async Task<ActionResult<LMSalesEvidenceResponseDto>> CreateLMSalesEvidence(LMSalesEvidenceCreateDto dto)
        {
            var createdLMSalesEvidence = await _lmSalesEvidenceService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetLMSalesEvidence), new { id = createdLMSalesEvidence.Id }, createdLMSalesEvidence);
        }

        // PUT: api/LMSalesEvidence/5
        [HttpPut("{reportId}")]
        public async Task<IActionResult> UpdateLMSalesEvidence(int reportId, LMSalesEvidenceUpdateDto dto)
        {
            if (reportId != dto.ReportId)
            {
                return BadRequest("Report ID in URL must match Report ID in body.");
            }

            var success = await _lmSalesEvidenceService.UpdateAsync(reportId, dto);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/LMSalesEvidence/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLMSalesEvidence(int id)
        {
            var success = await _lmSalesEvidenceService.DeleteAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/LMSalesEvidence/ByReport/5
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<LMSalesEvidenceResponseDto>> GetLMSalesEvidenceByReportId(int reportId)
        {
            var lmSalesEvidence = await _lmSalesEvidenceService.GetByReportIdAsync(reportId);

            if (lmSalesEvidence == null)
            {
                return NotFound();
            }

            return lmSalesEvidence;
        }

        // GET: api/LMSalesEvidence/ByMasterFile/5
        [HttpGet("ByMasterFile/{masterFileId}")]
        public async Task<ActionResult<IEnumerable<LMSalesEvidenceResponseDto>>> GetLMSalesEvidencesByMasterFileId(int masterFileId)
        {
            var salesEvidences = await _lmSalesEvidenceService.GetByMasterFileIdAsync(masterFileId);
            return Ok(salesEvidences);
        }
    }
}
