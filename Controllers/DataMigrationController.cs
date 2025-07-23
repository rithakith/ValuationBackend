using Microsoft.AspNetCore.Mvc;
using ValuationBackend.Data;

namespace ValuationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataMigrationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DataMigrationController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Populates foreign keys for LM Rental Evidence records based on existing string references
        /// </summary>
        [HttpPost("populate-lm-rental-evidence-foreign-keys")]
        public async Task<IActionResult> PopulateLMRentalEvidenceForeignKeys()
        {
            try
            {
                await PopulateForeignKeysMigration.PopulateLMRentalEvidenceForeignKeys(_context);
                return Ok(new { message = "Foreign keys populated successfully for LM Rental Evidence." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to populate foreign keys", details = ex.Message });
            }
        }

        /// <summary>
        /// Validates foreign key relationships for LM Rental Evidence
        /// </summary>
        [HttpGet("validate-lm-rental-evidence-foreign-keys")]
        public async Task<IActionResult> ValidateLMRentalEvidenceForeignKeys()
        {
            try
            {
                await PopulateForeignKeysMigration.ValidateForeignKeyRelationships(_context);
                return Ok(new { message = "Foreign key validation completed. Check console output for details." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to validate foreign keys", details = ex.Message });
            }
        }

        /// <summary>
        /// Runs both population and validation in sequence
        /// </summary>
        [HttpPost("migrate-lm-rental-evidence")]
        public async Task<IActionResult> MigrateLMRentalEvidence()
        {
            try
            {
                await PopulateForeignKeysMigration.PopulateLMRentalEvidenceForeignKeys(_context);
                await PopulateForeignKeysMigration.ValidateForeignKeyRelationships(_context);
                return Ok(new { message = "LM Rental Evidence migration completed successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to migrate LM Rental Evidence", details = ex.Message });
            }
        }
    }
}
