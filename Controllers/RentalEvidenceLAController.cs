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
    public class RentalEvidenceLAController : ControllerBase
    {
        private readonly IRentalEvidenceLAService _rentalEvidenceService;

        public RentalEvidenceLAController(IRentalEvidenceLAService rentalEvidenceService)
        {
            _rentalEvidenceService = rentalEvidenceService;
        }

        // GET: api/RentalEvidenceLA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalEvidenceLAResponseDto>>> GetRentalEvidencesLA()
        {
            var rentalEvidences = await _rentalEvidenceService.GetAllRentalEvidencesAsync();
            return Ok(rentalEvidences);
        }

        // GET: api/RentalEvidenceLA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalEvidenceLAResponseDto>> GetRentalEvidenceLA(int id)
        {
            var rentalEvidence = await _rentalEvidenceService.GetRentalEvidenceByIdAsync(id);

            if (rentalEvidence == null)
            {
                return NotFound();
            }

            return Ok(rentalEvidence);
        }

        // POST: api/RentalEvidenceLA
        [HttpPost]
        public async Task<ActionResult<RentalEvidenceLACreationResponseDto>> CreateRentalEvidenceLA(RentalEvidenceLACreateDto dto)
        {
            var createdRentalEvidence = await _rentalEvidenceService.CreateRentalEvidenceAsync(dto);
            
            // Return the custom response format with msg and reportId
            var response = new RentalEvidenceLACreationResponseDto
            {
                Msg = "success",
                ReportId = createdRentalEvidence.ReportId // Using the common report table ID
            };
            
            return Ok(response);
        }

        // PUT: api/RentalEvidenceLA/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRentalEvidenceLA(int id, RentalEvidenceLAUpdateDto dto)
        {
            var updatedRentalEvidence = await _rentalEvidenceService.UpdateRentalEvidenceAsync(id, dto);

            if (updatedRentalEvidence == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/RentalEvidenceLA/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentalEvidenceLA(int id)
        {
            var result = await _rentalEvidenceService.DeleteRentalEvidenceAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/RentalEvidenceLA/ByReport/{reportId}
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<RentalEvidenceLAResponseDto>> GetRentalEvidenceLAByReportId(int reportId)
        {
            var rentalEvidence = await _rentalEvidenceService.GetRentalEvidenceByReportIdAsync(reportId);

            if (rentalEvidence == null)
            {
                return NotFound();
            }

            return Ok(rentalEvidence);
        }
    }
}
