using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Models;
using ValuationBackend.Models.DTOs;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialRatingCardController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public SpecialRatingCardController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        // GET: api/SpecialRatingCard/autofill/{assetId}
        [HttpGet("autofill/{assetId:int}")]
        public async Task<ActionResult<AutofillDataDto>> GetAutofillData(int assetId)
        {
            try
            {
                var asset = await Task.FromResult(_assetService.GetAssetById(assetId));
                if (asset == null)
                {
                    return NotFound($"Asset with ID {assetId} not found.");
                }

                // Generate card number - simplified for now
                var newNumber = $"SPRC-{asset.AssetNo}-001";

                var autofillData = new AutofillDataDto
                {
                    Owner = asset.Owner,
                    Description = asset.Description.ToString(),
                    NewNumber = newNumber,
                };

                return Ok(autofillData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/SpecialRatingCard/asset/{assetId}
        [HttpPost("asset/{assetId:int}")]
        public async Task<ActionResult<SpecialRatingCardDto>> Create(
            int assetId,
            CreateSpecialRatingCardDto dto)
        {
            try
            {
                // For now, return a simple response
                var result = new SpecialRatingCardDto
                {
                    Id = 1,
                    AssetId = assetId,
                    AssetNo = "AST-001",
                    NewNumber = "SPRC-001",
                    Owner = "Owner",
                    Description = "Description",
                    CreatedAt = DateTime.UtcNow
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/SpecialRatingCard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialRatingCardDto>>> GetAll()
        {
            return Ok(new List<SpecialRatingCardDto>());
        }

        // GET: api/SpecialRatingCard/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SpecialRatingCardDto>> GetById(int id)
        {
            return NotFound($"Special Rating Card with ID {id} not found.");
        }
    }
}