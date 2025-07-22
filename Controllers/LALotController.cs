using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LALotController : ControllerBase
    {
        private readonly ILALotService _laLotService;

        public LALotController(ILALotService laLotService)
        {
            _laLotService = laLotService;
        }

        // GET: api/LALot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LALotResponseDto>>> GetLALots()
        {
            var lots = await _laLotService.GetAllAsync();
            return Ok(lots);
        }

        // GET: api/LALot/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LALotResponseDto>> GetLALot(int id)
        {
            var laLot = await _laLotService.GetByIdAsync(id);

            if (laLot == null)
            {
                return NotFound($"LALot with ID {id} not found.");
            }

            return Ok(laLot);
        }

        // GET: api/LALot/masterfile/5
        [HttpGet("masterfile/{masterFileId}")]
        public async Task<ActionResult<IEnumerable<LALotResponseDto>>> GetLALotsByMasterFileId(int masterFileId)
        {
            var lots = await _laLotService.GetByMasterFileIdAsync(masterFileId);
            return Ok(lots);
        }

        // POST: api/LALot
        [HttpPost]
        public async Task<ActionResult<LALotResponseDto>> CreateLALot(LALotCreateDto dto)
        {
            try
            {
                var createdLALot = await _laLotService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetLALot), new { id = createdLALot.Id }, createdLALot);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/LALot/5
        [HttpPut("{id}")]
        public async Task<ActionResult<LALotResponseDto>> UpdateLALot(int id, LALotUpdateDto dto)
        {
            try
            {
                var updatedLALot = await _laLotService.UpdateAsync(id, dto);
                if (updatedLALot == null)
                {
                    return NotFound($"LALot with ID {id} not found.");
                }

                return Ok(updatedLALot);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/LALot/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLALot(int id)
        {
            var result = await _laLotService.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"LALot with ID {id} not found.");
            }

            return NoContent();
        }
    }
}
