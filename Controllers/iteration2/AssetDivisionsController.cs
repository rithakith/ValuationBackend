using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;

namespace ValuationBackend.Controllers.iteration2
{
    /// <summary>
    /// Controller for managing asset divisions
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AssetDivisionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssetDivisionsController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all asset divisions ordered by creation date
        /// </summary>
        /// <returns>List of all asset divisions with their associated assets</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetDivision>>> GetAll()
        {
            return await _context.AssetDivisions
                .Include(d => d.Asset)
                .OrderByDescending(d => d.CreatedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Gets a specific asset division by ID
        /// </summary>
        /// <param name="id">The ID of the asset division to retrieve</param>
        /// <returns>The asset division with its associated asset</returns>
        /// <response code="200">Returns the asset division</response>
        /// <response code="404">If the asset division is not found</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<AssetDivision>> Get(int id)
        {
            var division = await _context.AssetDivisions
                .Include(d => d.Asset)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (division == null)
            {
                return NotFound();
            }

            return division;
        }

        /// <summary>
        /// Creates a new asset division
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/AssetDivisions
        ///     {
        ///         "id": 0,
        ///         "assetId": 1,
        ///         "newAssetNo": "ASSET-001-C",
        ///         "area": 1000.50,
        ///         "landType": "Residential",
        ///         "description": "New division of asset AST-001-2024",
        ///         "createdAt": "2025-05-26T15:11:47.828Z"
        ///     }
        /// 
        /// Note: Use assetId = 1 to reference the AST-001-2024 asset, or any ID from 1-12 for other existing assets.
        /// </remarks>
        /// <param name="division">The asset division to create</param>
        /// <returns>The created asset division</returns>
        /// <response code="201">Returns the newly created asset division</response>
        /// <response code="400">If the referenced asset does not exist</response>
        [HttpPost]
        public async Task<ActionResult<AssetDivision>> Post(AssetDivision division)
        {
            // Verify that the referenced Asset exists
            var assetExists = await _context.Assets.AnyAsync(a => a.Id == division.AssetId);
            if (!assetExists)
            {
                return BadRequest($"Asset with ID {division.AssetId} does not exist. Use a value between 1-12 to reference an existing asset.");
            }

            division.CreatedAt = DateTime.UtcNow;
            _context.AssetDivisions.Add(division);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Get),
                new { id = division.Id },
                division
            );
        }        /// <summary>
        /// Updates an existing asset division
        /// </summary>
        /// <remarks>
        /// Sample request for updating asset division with ID 1:
        /// 
        ///     PUT /api/AssetDivisions/1
        ///     {
        ///         "id": 1,              # Must match the ID in the URL
        ///         "assetId": 1,         # Must be between 1-12
        ///         "newAssetNo": "ASSET-001-A-UPDATED",
        ///         "area": 1500.50,
        ///         "landType": "Commercial",
        ///         "description": "Updated north portion of original asset",
        ///         "createdAt": "2025-05-26T15:25:58.014Z"  # Will be preserved from existing record
        ///     }
        /// 
        /// Important:
        /// 1. The 'id' in the request body MUST match the ID in the URL path
        /// 2. Use 'assetId' values between 1-12 to reference existing assets
        /// 3. The 'asset' navigation property should be omitted from the request
        /// 4. The original 'createdAt' value will be preserved
        /// </remarks>
        /// <param name="id">The ID of the asset division to update</param>
        /// <param name="division">The updated asset division data</param>
        /// <returns>No content if successful</returns>
        /// <response code="204">If the update was successful</response>
        /// <response code="400">If the ID doesn't match or the referenced asset doesn't exist</response>
        /// <response code="404">If the asset division is not found</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AssetDivision division)
        {            if (division == null)
            {
                return BadRequest("Request body cannot be null");
            }

            if (id != division.Id)
            {
                return BadRequest($"ID mismatch. The ID in the URL ({id}) must match the ID in the request body ({division.Id})");
            }

            if (division.AssetId <= 0)
            {
                return BadRequest("AssetId must be a positive number");
            }

            if (string.IsNullOrWhiteSpace(division.NewAssetNo))
            {
                return BadRequest("NewAssetNo is required");
            }

            if (division.Area <= 0)
            {
                return BadRequest("Area must be a positive number");
            }

            if (string.IsNullOrWhiteSpace(division.LandType))
            {
                return BadRequest("LandType is required");
            }

            var existingDivision = await _context.AssetDivisions.FindAsync(id);
            if (existingDivision == null)
            {
                return NotFound($"Asset division with ID {id} was not found");
            }

            // Verify that the referenced Asset exists if AssetId is being changed
            if (existingDivision.AssetId != division.AssetId)
            {
                var assetExists = await _context.Assets.AnyAsync(a => a.Id == division.AssetId);
                if (!assetExists)
                {
                    return BadRequest($"Asset with ID {division.AssetId} does not exist. Use a value between 1-12 to reference an existing asset.");
                }
            }

            // Preserve the original CreatedAt value
            division.CreatedAt = existingDivision.CreatedAt;

            _context.Entry(existingDivision).CurrentValues.SetValues(division);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific asset division
        /// </summary>
        /// <param name="id">The ID of the asset division to delete</param>
        /// <returns>No content if successful</returns>
        /// <response code="204">If the deletion was successful</response>
        /// <response code="404">If the asset division is not found</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var division = await _context.AssetDivisions.FindAsync(id);
            if (division == null)
            {
                return NotFound();
            }

            _context.AssetDivisions.Remove(division);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
