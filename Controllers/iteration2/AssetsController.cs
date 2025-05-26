using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Models;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers.iteration2
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetsController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet]
        public ActionResult<List<Asset>> GetAllAssets()
        {
            try
            {
                var assets = _assetService.GetAllAssets();
                return Ok(assets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Asset> GetAssetById(int id)
        {
            try
            {
                var asset = _assetService.GetAssetById(id);
                if (asset == null)
                    return NotFound($"Asset with ID {id} not found");

                return Ok(asset);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("by-request/{requestId}")]
        public ActionResult<List<Asset>> GetAssetsByRequestId(int requestId)
        {
            try
            {
                var assets = _assetService.GetAssetsByRequestId(requestId);
                return Ok(assets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("by-asset-no/{assetNo}")]
        public ActionResult<List<Asset>> GetAssetsByAssetNo(string assetNo)
        {
            try
            {
                var assets = _assetService.GetAssetsByAssetNo(assetNo);
                return Ok(assets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("by-property-type/{propertyType}")]
        public ActionResult<List<Asset>> GetAssetsByPropertyType(PropertyType propertyType)
        {
            try
            {
                var assets = _assetService.GetAssetsByPropertyType(propertyType);
                return Ok(assets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("by-ward/{ward}")]
        public ActionResult<List<Asset>> GetAssetsByWard(string ward)
        {
            try
            {
                var assets = _assetService.GetAssetsByWard(ward);
                return Ok(assets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("by-owner/{owner}")]
        public ActionResult<List<Asset>> GetAssetsByOwner(string owner)
        {
            try
            {
                var assets = _assetService.GetAssetsByOwner(owner);
                return Ok(assets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("by-rating-card/{isRatingCard}")]
        public ActionResult<List<Asset>> GetAssetsByRatingCard(bool isRatingCard)
        {
            try
            {
                var assets = _assetService.GetAssetsByRatingCard(isRatingCard);
                return Ok(assets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<Asset> CreateAsset([FromBody] Asset asset)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdAsset = _assetService.CreateAsset(asset);
                return CreatedAtAction(nameof(GetAssetById), new { id = createdAsset.Id }, createdAsset);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Asset> UpdateAsset(int id, [FromBody] Asset asset)
        {
            try
            {
                if (id != asset.Id)
                    return BadRequest("ID mismatch");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updatedAsset = _assetService.UpdateAsset(asset);
                return Ok(updatedAsset);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAsset(int id)
        {
            try
            {
                var deleted = _assetService.DeleteAsset(id);
                if (!deleted)
                    return NotFound($"Asset with ID {id} not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpHead("{id}")]
        public ActionResult AssetExists(int id)
        {
            try
            {
                var exists = _assetService.AssetExists(id);
                return exists ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
