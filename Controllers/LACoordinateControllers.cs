using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PastValuationsLACoordinateController : ControllerBase
    {
        private readonly IPastValuationsLACoordinateService _coordinateService;

        public PastValuationsLACoordinateController(IPastValuationsLACoordinateService coordinateService)
        {
            _coordinateService = coordinateService;
        }

        // GET: api/PastValuationsLACoordinate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PastValuationsLACoordinateResponseDto>>> GetCoordinates()
        {
            var coordinates = await _coordinateService.GetAllAsync();
            return Ok(coordinates);
        }

        // GET: api/PastValuationsLACoordinate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PastValuationsLACoordinateResponseDto>> GetCoordinate(int id)
        {
            var coordinate = await _coordinateService.GetByIdAsync(id);

            if (coordinate == null)
            {
                return NotFound($"Coordinate with ID {id} not found.");
            }

            return Ok(coordinate);
        }

        // GET: api/PastValuationsLACoordinate/report/5
        [HttpGet("report/{reportId}")]
        public async Task<ActionResult<IEnumerable<PastValuationsLACoordinateResponseDto>>> GetCoordinatesByReportId(int reportId)
        {
            var coordinates = await _coordinateService.GetByReportIdAsync(reportId);
            return Ok(coordinates);
        }

        // POST: api/PastValuationsLACoordinate
        [HttpPost]
        public async Task<ActionResult<PastValuationsLACoordinateResponseDto>> CreateCoordinate(PastValuationsLACoordinateCreateDto dto)
        {
            try
            {
                var createdCoordinate = await _coordinateService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetCoordinate), new { id = createdCoordinate.Id }, createdCoordinate);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/PastValuationsLACoordinate/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PastValuationsLACoordinateResponseDto>> UpdateCoordinate(int id, PastValuationsLACoordinateUpdateDto dto)
        {
            try
            {
                var updatedCoordinate = await _coordinateService.UpdateAsync(id, dto);
                if (updatedCoordinate == null)
                {
                    return NotFound($"Coordinate with ID {id} not found.");
                }

                return Ok(updatedCoordinate);
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

        // DELETE: api/PastValuationsLACoordinate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCoordinate(int id)
        {
            var result = await _coordinateService.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"Coordinate with ID {id} not found.");
            }

            return NoContent();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class BuildingRatesLACoordinateController : ControllerBase
    {
        private readonly IBuildingRatesLACoordinateService _coordinateService;

        public BuildingRatesLACoordinateController(IBuildingRatesLACoordinateService coordinateService)
        {
            _coordinateService = coordinateService;
        }

        // GET: api/BuildingRatesLACoordinate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingRatesLACoordinateResponseDto>>> GetCoordinates()
        {
            var coordinates = await _coordinateService.GetAllAsync();
            return Ok(coordinates);
        }

        // GET: api/BuildingRatesLACoordinate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingRatesLACoordinateResponseDto>> GetCoordinate(int id)
        {
            var coordinate = await _coordinateService.GetByIdAsync(id);

            if (coordinate == null)
            {
                return NotFound($"Coordinate with ID {id} not found.");
            }

            return Ok(coordinate);
        }

        // GET: api/BuildingRatesLACoordinate/report/5
        [HttpGet("report/{reportId}")]
        public async Task<ActionResult<IEnumerable<BuildingRatesLACoordinateResponseDto>>> GetCoordinatesByReportId(int reportId)
        {
            var coordinates = await _coordinateService.GetByReportIdAsync(reportId);
            return Ok(coordinates);
        }

        // POST: api/BuildingRatesLACoordinate
        [HttpPost]
        public async Task<ActionResult<BuildingRatesLACoordinateResponseDto>> CreateCoordinate(BuildingRatesLACoordinateCreateDto dto)
        {
            try
            {
                var createdCoordinate = await _coordinateService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetCoordinate), new { id = createdCoordinate.Id }, createdCoordinate);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/BuildingRatesLACoordinate/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BuildingRatesLACoordinateResponseDto>> UpdateCoordinate(int id, BuildingRatesLACoordinateUpdateDto dto)
        {
            try
            {
                var updatedCoordinate = await _coordinateService.UpdateAsync(id, dto);
                if (updatedCoordinate == null)
                {
                    return NotFound($"Coordinate with ID {id} not found.");
                }

                return Ok(updatedCoordinate);
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

        // DELETE: api/BuildingRatesLACoordinate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCoordinate(int id)
        {
            var result = await _coordinateService.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"Coordinate with ID {id} not found.");
            }

            return NoContent();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class SalesEvidenceLACoordinateController : ControllerBase
    {
        private readonly ISalesEvidenceLACoordinateService _coordinateService;

        public SalesEvidenceLACoordinateController(ISalesEvidenceLACoordinateService coordinateService)
        {
            _coordinateService = coordinateService;
        }

        // GET: api/SalesEvidenceLACoordinate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesEvidenceLACoordinateResponseDto>>> GetCoordinates()
        {
            var coordinates = await _coordinateService.GetAllAsync();
            return Ok(coordinates);
        }

        // GET: api/SalesEvidenceLACoordinate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesEvidenceLACoordinateResponseDto>> GetCoordinate(int id)
        {
            var coordinate = await _coordinateService.GetByIdAsync(id);

            if (coordinate == null)
            {
                return NotFound($"Coordinate with ID {id} not found.");
            }

            return Ok(coordinate);
        }

        // GET: api/SalesEvidenceLACoordinate/report/5
        [HttpGet("report/{reportId}")]
        public async Task<ActionResult<IEnumerable<SalesEvidenceLACoordinateResponseDto>>> GetCoordinatesByReportId(int reportId)
        {
            var coordinates = await _coordinateService.GetByReportIdAsync(reportId);
            return Ok(coordinates);
        }

        // POST: api/SalesEvidenceLACoordinate
        [HttpPost]
        public async Task<ActionResult<SalesEvidenceLACoordinateResponseDto>> CreateCoordinate(SalesEvidenceLACoordinateCreateDto dto)
        {
            try
            {
                var createdCoordinate = await _coordinateService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetCoordinate), new { id = createdCoordinate.Id }, createdCoordinate);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/SalesEvidenceLACoordinate/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SalesEvidenceLACoordinateResponseDto>> UpdateCoordinate(int id, SalesEvidenceLACoordinateUpdateDto dto)
        {
            try
            {
                var updatedCoordinate = await _coordinateService.UpdateAsync(id, dto);
                if (updatedCoordinate == null)
                {
                    return NotFound($"Coordinate with ID {id} not found.");
                }

                return Ok(updatedCoordinate);
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

        // DELETE: api/SalesEvidenceLACoordinate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCoordinate(int id)
        {
            var result = await _coordinateService.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"Coordinate with ID {id} not found.");
            }

            return NoContent();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class RentalEvidenceLACoordinateController : ControllerBase
    {
        private readonly IRentalEvidenceLACoordinateService _coordinateService;

        public RentalEvidenceLACoordinateController(IRentalEvidenceLACoordinateService coordinateService)
        {
            _coordinateService = coordinateService;
        }

        // GET: api/RentalEvidenceLACoordinate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalEvidenceLACoordinateResponseDto>>> GetCoordinates()
        {
            var coordinates = await _coordinateService.GetAllAsync();
            return Ok(coordinates);
        }

        // GET: api/RentalEvidenceLACoordinate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalEvidenceLACoordinateResponseDto>> GetCoordinate(int id)
        {
            var coordinate = await _coordinateService.GetByIdAsync(id);

            if (coordinate == null)
            {
                return NotFound($"Coordinate with ID {id} not found.");
            }

            return Ok(coordinate);
        }

        // GET: api/RentalEvidenceLACoordinate/report/5
        [HttpGet("report/{reportId}")]
        public async Task<ActionResult<IEnumerable<RentalEvidenceLACoordinateResponseDto>>> GetCoordinatesByReportId(int reportId)
        {
            var coordinates = await _coordinateService.GetByReportIdAsync(reportId);
            return Ok(coordinates);
        }

        // POST: api/RentalEvidenceLACoordinate
        [HttpPost]
        public async Task<ActionResult<RentalEvidenceLACoordinateResponseDto>> CreateCoordinate(RentalEvidenceLACoordinateCreateDto dto)
        {
            try
            {
                var createdCoordinate = await _coordinateService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetCoordinate), new { id = createdCoordinate.Id }, createdCoordinate);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/RentalEvidenceLACoordinate/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RentalEvidenceLACoordinateResponseDto>> UpdateCoordinate(int id, RentalEvidenceLACoordinateUpdateDto dto)
        {
            try
            {
                var updatedCoordinate = await _coordinateService.UpdateAsync(id, dto);
                if (updatedCoordinate == null)
                {
                    return NotFound($"Coordinate with ID {id} not found.");
                }

                return Ok(updatedCoordinate);
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

        // DELETE: api/RentalEvidenceLACoordinate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCoordinate(int id)
        {
            var result = await _coordinateService.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"Coordinate with ID {id} not found.");
            }

            return NoContent();
        }
    }
}
