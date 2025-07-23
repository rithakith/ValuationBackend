using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ValuationBackend.Models.iteration2.DTOs;
using ValuationBackend.Services.iteration2;

namespace ValuationBackend.Controllers.iteration2
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesRatingCardController : ControllerBase
    {
        private readonly IOfficesRatingCardService _service;
        private readonly ILogger<OfficesRatingCardController> _logger;

        public OfficesRatingCardController(
            IOfficesRatingCardService service,
            ILogger<OfficesRatingCardController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Get all offices rating cards
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficesRatingCardDto>>> GetAll()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all offices rating cards");
                return StatusCode(500, "An error occurred while retrieving offices rating cards.");
            }
        }

        /// <summary>
        /// Get offices rating card by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<OfficesRatingCardDto>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"OfficesRatingCard with ID {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving offices rating card with ID {Id}", id);
                return StatusCode(500, "An error occurred while retrieving the offices rating card.");
            }
        }

        /// <summary>
        /// Get offices rating card by Asset ID
        /// </summary>
        [HttpGet("asset/{assetId}")]
        public async Task<ActionResult<OfficesRatingCardDto>> GetByAssetId(int assetId)
        {
            try
            {
                var result = await _service.GetByAssetIdAsync(assetId);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"OfficesRatingCard for Asset ID {assetId} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving offices rating card for Asset ID {AssetId}", assetId);
                return StatusCode(500, "An error occurred while retrieving the offices rating card.");
            }
        }

        /// <summary>
        /// Create a new offices rating card
        /// </summary>
        [HttpPost("asset/{assetId}")]
        public async Task<ActionResult<OfficesRatingCardDto>> Create(int assetId, [FromBody] CreateOfficesRatingCardDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("Invalid offices rating card data.");
                }

                // Ensure the assetId from route matches the one in the body
                dto.AssetId = assetId;

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating offices rating card for Asset ID {AssetId}", assetId);
                return StatusCode(500, "An error occurred while creating the offices rating card.");
            }
        }

        /// <summary>
        /// Update an existing offices rating card
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<OfficesRatingCardDto>> Update(int id, [FromBody] UpdateOfficesRatingCardDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("Invalid offices rating card data.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _service.UpdateAsync(id, dto);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"OfficesRatingCard with ID {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating offices rating card with ID {Id}", id);
                return StatusCode(500, "An error occurred while updating the offices rating card.");
            }
        }

        /// <summary>
        /// Delete an offices rating card
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                if (!result)
                {
                    return NotFound($"OfficesRatingCard with ID {id} not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting offices rating card with ID {Id}", id);
                return StatusCode(500, "An error occurred while deleting the offices rating card.");
            }
        }

        /// <summary>
        /// Get autofill data for offices rating card
        /// </summary>
        [HttpGet("autofill/{assetId}")]
        public async Task<ActionResult<OfficesRatingCardAutofillDto>> GetAutofillData(int assetId)
        {
            try
            {
                var result = await _service.GetAutofillDataAsync(assetId);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Asset with ID {assetId} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving autofill data for Asset ID {AssetId}", assetId);
                return StatusCode(500, "An error occurred while retrieving autofill data.");
            }
        }
    }
}