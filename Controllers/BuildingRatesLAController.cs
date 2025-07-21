using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingRatesLAController : ControllerBase
    {
        private readonly IBuildingRatesLAService _buildingRatesService;

        public BuildingRatesLAController(IBuildingRatesLAService buildingRatesService)
        {
            _buildingRatesService = buildingRatesService;
        }

        // GET: api/BuildingRatesLA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingRatesLAResponseDto>>> GetBuildingRatesLA()
        {
            return Ok(await _buildingRatesService.GetAllAsync());
        }

        // GET: api/BuildingRatesLA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingRatesLAResponseDto>> GetBuildingRateLA(int id)
        {
            var buildingRate = await _buildingRatesService.GetByIdAsync(id);

            if (buildingRate == null)
            {
                return NotFound();
            }

            return buildingRate;
        }

        // POST: api/BuildingRatesLA
        [HttpPost]
        public async Task<ActionResult<BuildingRatesLACreationResponseDto>> CreateBuildingRateLA(BuildingRatesLACreateDto dto)
        {
            var result = await _buildingRatesService.CreateAsync(dto);
            
            return Ok(new BuildingRatesLACreationResponseDto
            { 
                Msg = "success", 
                ReportId = result.ReportId.ToString() 
            });
        }

        // PUT: api/BuildingRatesLA/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBuildingRateLA(int id, BuildingRatesLAUpdateDto dto)
        {
            var result = await _buildingRatesService.UpdateAsync(id, dto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/BuildingRatesLA/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuildingRateLA(int id)
        {
            var result = await _buildingRatesService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/BuildingRatesLA/ByReport/{reportId}
        [HttpGet("ByReport/{reportId}")]
        public async Task<ActionResult<BuildingRatesLAResponseDto>> GetBuildingRateLAByReportId(int reportId)
        {
            var buildingRate = await _buildingRatesService.GetByReportIdAsync(reportId);

            if (buildingRate == null)
            {
                return NotFound();
            }

            return buildingRate;
        }
    }
}
