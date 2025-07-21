using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExistingLotsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Update existing records to set random values for Lots (between 1 and 6)
            // Using PostgreSQL's RANDOM() function to generate random integers
            
            migrationBuilder.Sql("UPDATE \"LandAquisitionMasterFiles\" SET \"Lots\" = FLOOR(RANDOM() * 6) + 1 WHERE \"Lots\" = 0;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Rollback: Set all Lots back to 0
            migrationBuilder.Sql("UPDATE \"LandAquisitionMasterFiles\" SET \"Lots\" = 0;");
        }
    }
}
