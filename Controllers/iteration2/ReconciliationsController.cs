using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Models;
using ValuationBackend.Services;

namespace ValuationBackend.Controllers.iteration2
{
    /// <summary>
    /// Controller for managing asset reconciliations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReconciliationsController : ControllerBase
    {
        private readonly IReconciliationService _reconciliationService;

        public ReconciliationsController(IReconciliationService reconciliationService)
        {
            _reconciliationService = reconciliationService;
        }

        /// <summary>
        /// Gets all reconciliations ordered by update date
        /// </summary>
        /// <returns>List of all reconciliations with their associated assets</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reconciliation>>> GetAll()
        {
            return await _reconciliationService.GetAllReconciliationsAsync();
        }

        /// <summary>
        /// Gets a specific reconciliation by ID
        /// </summary>
        /// <param name="id">The ID of the reconciliation to retrieve</param>
        /// <returns>The reconciliation with its associated asset</returns>
        /// <response code="200">Returns the reconciliation</response>
        /// <response code="404">If the reconciliation is not found</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Reconciliation>> Get(int id)
        {
            var reconciliation = await _reconciliationService.GetReconciliationByIdAsync(id);
            if (reconciliation == null)
            {
                return NotFound();
            }

            return reconciliation;
        }

        /// <summary>
        /// Gets reconciliations for a specific asset
        /// </summary>
        /// <param name="assetId">The ID of the asset to get reconciliations for</param>
        /// <returns>List of reconciliations for the specified asset</returns>
        [HttpGet("by-asset/{assetId}")]
        public async Task<ActionResult<IEnumerable<Reconciliation>>> GetByAsset(int assetId)
        {
            return await _reconciliationService.GetReconciliationsByAssetIdAsync(assetId);
        }

        /// <summary>
        /// Gets reconciliations by street name
        /// </summary>
        /// <param name="streetName">The street name to search for</param>
        /// <returns>List of reconciliations matching the street name</returns>
        [HttpGet("by-street")]
        public async Task<ActionResult<IEnumerable<Reconciliation>>> GetByStreet([FromQuery] string streetName)
        {
            if (string.IsNullOrWhiteSpace(streetName))
            {
                return BadRequest("Street name is required");
            }

            return await _reconciliationService.GetReconciliationsByStreetNameAsync(streetName);
        }

        /// <summary>
        /// Creates a new reconciliation
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Reconciliations
        ///     {
        ///         "assetId": 1,
        ///         "streetName": "Galle Road",
        ///         "obsoleteNo": "123/A",
        ///         "newNo": "456/B"
        ///     }
        /// 
        /// Note: Use assetId values between 1-12 to reference existing assets
        /// </remarks>
        /// <param name="reconciliation">The reconciliation to create</param>
        /// <returns>The created reconciliation</returns>
        /// <response code="201">Returns the newly created reconciliation</response>
        /// <response code="400">If the request data is invalid</response>
        [HttpPost]
        public async Task<ActionResult<Reconciliation>> Post(Reconciliation reconciliation)
        {
            try
            {
                var created = await _reconciliationService.CreateReconciliationAsync(reconciliation);
                return CreatedAtAction(
                    nameof(Get),
                    new { id = created.Id },
                    created
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing reconciliation
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/Reconciliations/1
        ///     {
        ///         "id": 1,
        ///         "assetId": 1,
        ///         "streetName": "Galle Road",
        ///         "obsoleteNo": "123/A",
        ///         "newNo": "456/B-UPDATED"
        ///     }
        /// 
        /// Notes:
        /// - The id in the URL must match the id in the request body
        /// - Use assetId values between 1-12 to reference existing assets
        /// - The original updatedAt value will be overwritten
        /// </remarks>
        /// <param name="id">The ID of the reconciliation to update</param>
        /// <param name="reconciliation">The updated reconciliation data</param>
        /// <returns>No content if successful</returns>
        /// <response code="204">If the update was successful</response>
        /// <response code="400">If the request data is invalid</response>
        /// <response code="404">If the reconciliation is not found</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Reconciliation reconciliation)
        {
            if (id != reconciliation.Id)
            {
                return BadRequest($"ID mismatch. The ID in the URL ({id}) must match the ID in the request body ({reconciliation.Id})");
            }

            try
            {
                await _reconciliationService.UpdateReconciliationAsync(id, reconciliation);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a specific reconciliation
        /// </summary>
        /// <param name="id">The ID of the reconciliation to delete</param>
        /// <returns>No content if successful</returns>
        /// <response code="204">If the deletion was successful</response>
        /// <response code="404">If the reconciliation is not found</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _reconciliationService.DeleteReconciliationAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
