using Microsoft.EntityFrameworkCore;
using ValuationBackend.Models;

namespace ValuationBackend.Data
{
    public static class PopulateForeignKeysMigration
    {
        /// <summary>
        /// Populates the LandMiscellaneousMasterFileId foreign key in LMRentalEvidence 
        /// based on existing MasterFileRefNo values
        /// </summary>
        public static async Task PopulateLMRentalEvidenceForeignKeys(AppDbContext context)
        {
            // Get all rental evidences where foreign key is null but string reference exists
            var rentalEvidences = await context.LMRentalEvidences
                .Where(re => re.LandMiscellaneousMasterFileId == null &&
                            !string.IsNullOrEmpty(re.MasterFileRefNo))
                .ToListAsync();

            if (!rentalEvidences.Any())
            {
                Console.WriteLine("No rental evidences found that need foreign key population.");
                return;
            }

            Console.WriteLine($"Found {rentalEvidences.Count} rental evidences to update.");

            int updatedCount = 0;
            int skippedCount = 0;

            foreach (var evidence in rentalEvidences)
            {
                // Find the corresponding master file
                var masterFile = await context.LandMiscellaneousMasterFiles
                    .FirstOrDefaultAsync(mf => mf.MasterFileRefNo == evidence.MasterFileRefNo);

                if (masterFile != null)
                {
                    evidence.LandMiscellaneousMasterFileId = masterFile.Id;
                    updatedCount++;
                    Console.WriteLine($"Updated rental evidence ID {evidence.Id} with master file ID {masterFile.Id}");
                }
                else
                {
                    skippedCount++;
                    Console.WriteLine($"Warning: No master file found for reference number '{evidence.MasterFileRefNo}' (Rental Evidence ID: {evidence.Id})");
                }
            }

            if (updatedCount > 0)
            {
                await context.SaveChangesAsync();
                Console.WriteLine($"Successfully updated {updatedCount} rental evidence records.");
            }

            if (skippedCount > 0)
            {
                Console.WriteLine($"Skipped {skippedCount} records due to missing master file references.");
            }
        }

        /// <summary>
        /// Validates the foreign key relationships after population
        /// </summary>
        public static async Task ValidateForeignKeyRelationships(AppDbContext context)
        {
            // Check for rental evidences with valid foreign keys
            var withForeignKeys = await context.LMRentalEvidences
                .CountAsync(re => re.LandMiscellaneousMasterFileId.HasValue);

            // Check for rental evidences without foreign keys but with string references
            var withoutForeignKeys = await context.LMRentalEvidences
                .CountAsync(re => !re.LandMiscellaneousMasterFileId.HasValue &&
                                 !string.IsNullOrEmpty(re.MasterFileRefNo));

            // Check for orphaned references (string references that don't match any master file)
            var orphanedReferences = await context.LMRentalEvidences
                .Where(re => !string.IsNullOrEmpty(re.MasterFileRefNo))
                .Where(re => !context.LandMiscellaneousMasterFiles
                    .Any(mf => mf.MasterFileRefNo == re.MasterFileRefNo))
                .CountAsync();

            Console.WriteLine("=== Foreign Key Relationship Validation ===");
            Console.WriteLine($"Rental evidences with foreign keys: {withForeignKeys}");
            Console.WriteLine($"Rental evidences without foreign keys (but with string refs): {withoutForeignKeys}");
            Console.WriteLine($"Orphaned string references: {orphanedReferences}");

            if (withoutForeignKeys > 0)
            {
                Console.WriteLine("Warning: Some rental evidences still lack foreign key relationships.");
            }

            if (orphanedReferences > 0)
            {
                Console.WriteLine("Warning: Some rental evidences reference master files that don't exist.");
            }
        }
    }
}
