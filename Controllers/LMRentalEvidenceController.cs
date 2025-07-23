using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LMRentalEvidenceController : ControllerBase
    {
        private readonly ILMRentalEvidenceService _lmRentalEvidenceService;

        public LMRentalEvidenceController(ILMRentalEvidenceService lmRentalEvidenceService)
        {
            _lmRentalEvidenceService = lmRentalEvidenceService;
        }

        // GET: api/LMRentalEvidence
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMRentalEvidenceResponseDto>>> GetLMRentalEvidences()
        {
            var evidences = await _lmRentalEvidenceService.GetAllAsync();
            return Ok(evidences);
        }

        // GET: api/LMRentalEvidence/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LMRentalEvidenceResponseDto>> GetLMRentalEvidence(int id)
        {
            var lmRentalEvidence = await _lmRentalEvidenceService.GetByIdAsync(id);

            if (lmRentalEvidence == null)
            {
                return NotFound();
            }

            return lmRentalEvidence;
        }

        // POST: api/LMRentalEvidence
        [HttpPost]
        public async Task<ActionResult<LMRentalEvidenceResponseDto>> CreateLMRentalEvidence(LMRentalEvidenceCreateDto dto)
        {
            var createdLMRentalEvidence = await _lmRentalEvidenceService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetLMRentalEvidence), new { id = createdLMRentalEvidence.Id }, createdLMRentalEvidence);
        }

        // PUT: api/LMRentalEvidence/5
        [HttpPut("{reportId}")]
        public async Task<IActionResult> UpdateLMRentalEvidence(int reportId, LMRentalEvidenceUpdateDto dto)
        {
            if (reportId != dto.ReportId)
            {
                return BadRequest("Report ID in URL must match Report ID in body.");
            }

            var success = await _lmRentalEvidenceService.UpdateAsync(reportId, dto);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/LMRentalEvidence/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLMRentalEvidence(int id)
        {
            var success = await _lmRentalEvidenceService.DeleteAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/LMRentalEvidence/ByReport/5
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<LMRentalEvidenceResponseDto>> GetLMRentalEvidenceByReportId(int reportId)
        {
            var lmRentalEvidence = await _lmRentalEvidenceService.GetByReportIdAsync(reportId);

            if (lmRentalEvidence == null)
            {
                return NotFound();
            }

            return lmRentalEvidence;
        }

        // NEW: GET: api/LMRentalEvidence/ByMasterFile/123
        [HttpGet("ByMasterFile/{masterFileId}")]
        public async Task<ActionResult<IEnumerable<LMRentalEvidenceResponseDto>>> GetByMasterFileId(int masterFileId)
        {
            var evidences = await _lmRentalEvidenceService.GetByMasterFileIdAsync(masterFileId);
            return Ok(evidences);
        }

        // NEW: GET: api/LMRentalEvidence/ByMasterFileRefNo/MF-2024-001
        [HttpGet("ByMasterFileRefNo/{masterFileRefNo}")]
        public async Task<ActionResult<IEnumerable<LMRentalEvidenceResponseDto>>> GetByMasterFileRefNo(string masterFileRefNo)
        {
            var evidences = await _lmRentalEvidenceService.GetByMasterFileRefNoAsync(masterFileRefNo);
            return Ok(evidences);
        }

        // NEW: GET: api/LMRentalEvidence/WithMasterFileData
        [HttpGet("WithMasterFileData")]
        public async Task<ActionResult<IEnumerable<LMRentalEvidenceResponseDto>>> GetAllWithMasterFileData()
        {
            var evidences = await _lmRentalEvidenceService.GetAllWithMasterFileDataAsync();
            return Ok(evidences);
        }
    }
}
