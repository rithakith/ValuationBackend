using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesEvidenceLAController : ControllerBase
    {
        private readonly ISalesEvidenceLAService _salesEvidenceService;

        public SalesEvidenceLAController(ISalesEvidenceLAService salesEvidenceService)
        {
            _salesEvidenceService = salesEvidenceService;
        }

        // GET: api/SalesEvidenceLA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesEvidenceLAResponseDto>>> GetSalesEvidencesLA()
        {
            var salesEvidences = await _salesEvidenceService.GetAllSalesEvidencesAsync();
            return Ok(salesEvidences);
        }

        // GET: api/SalesEvidenceLA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesEvidenceLAResponseDto>> GetSalesEvidenceLA(int id)
        {
            var salesEvidence = await _salesEvidenceService.GetSalesEvidenceByIdAsync(id);

            if (salesEvidence == null)
            {
                return NotFound();
            }

            return Ok(salesEvidence);
        }

        // POST: api/SalesEvidenceLA
        [HttpPost]
        public async Task<ActionResult<SalesEvidenceLAResponseDto>> CreateSalesEvidenceLA(SalesEvidenceLACreateDto dto)
        {
            var createdSalesEvidence = await _salesEvidenceService.CreateSalesEvidenceAsync(dto);
            
            return CreatedAtAction(
                nameof(GetSalesEvidenceLA),
                new { id = createdSalesEvidence.Id },
                createdSalesEvidence);
        }

        // PUT: api/SalesEvidenceLA/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalesEvidenceLA(int id, SalesEvidenceLAUpdateDto dto)
        {
            var updatedSalesEvidence = await _salesEvidenceService.UpdateSalesEvidenceAsync(id, dto);

            if (updatedSalesEvidence == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/SalesEvidenceLA/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesEvidenceLA(int id)
        {
            var result = await _salesEvidenceService.DeleteSalesEvidenceAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/SalesEvidenceLA/ByReport/{reportId}
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<SalesEvidenceLAResponseDto>> GetSalesEvidenceLAByReportId(int reportId)
        {
            var salesEvidence = await _salesEvidenceService.GetSalesEvidenceByReportIdAsync(reportId);

            if (salesEvidence == null)
            {
                return NotFound();
            }

            return Ok(salesEvidence);
        }
    }
}
