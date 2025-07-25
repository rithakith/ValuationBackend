using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ValuationBackend.DTOs.iteration2;
using ValuationBackend.Services.iteration2;

namespace ValuationBackend.Controllers.iteration2
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class I2RentalEvidenceController : ControllerBase
    {
        private readonly II2RentalEvidenceService _service;
        private readonly ILogger<I2RentalEvidenceController> _logger;

        public I2RentalEvidenceController(II2RentalEvidenceService service, ILogger<I2RentalEvidenceController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<I2RentalEvidenceDto>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "I2RentalEvidence not found with ID: {Id}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving I2RentalEvidence with ID: {Id}", id);
                return StatusCode(500, new { message = "An error occurred while retrieving the rental evidence." });
            }
        }

        [HttpGet("asset/{assetId}")]
        public async Task<ActionResult<IEnumerable<I2RentalEvidenceDto>>> GetByAssetId(int assetId)
        {
            try
            {
                var result = await _service.GetByAssetIdAsync(assetId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving I2RentalEvidence for asset ID: {AssetId}", assetId);
                return StatusCode(500, new { message = "An error occurred while retrieving rental evidences." });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<I2RentalEvidenceDto>>> GetAll()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all I2RentalEvidence");
                return StatusCode(500, new { message = "An error occurred while retrieving rental evidences." });
            }
        }

        [HttpPost]
        public async Task<ActionResult<I2RentalEvidenceDto>> Create([FromBody] CreateI2RentalEvidenceDto dto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "system";
                var result = await _service.CreateAsync(dto, userId);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating I2RentalEvidence");
                return StatusCode(500, new { message = "An error occurred while creating the rental evidence." });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<I2RentalEvidenceDto>> Update(int id, [FromBody] UpdateI2RentalEvidenceDto dto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "system";
                var result = await _service.UpdateAsync(id, dto, userId);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "I2RentalEvidence not found for update with ID: {Id}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating I2RentalEvidence with ID: {Id}", id);
                return StatusCode(500, new { message = "An error occurred while updating the rental evidence." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                if (!result)
                    return NotFound(new { message = $"I2RentalEvidence with ID {id} not found." });

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting I2RentalEvidence with ID: {Id}", id);
                return StatusCode(500, new { message = "An error occurred while deleting the rental evidence." });
            }
        }
    }
}