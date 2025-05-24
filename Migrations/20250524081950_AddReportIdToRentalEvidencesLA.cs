using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddReportIdToRentalEvidencesLA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add ReportId column to RentalEvidencesLA table
            // First clear any existing data to avoid foreign key constraint issues
            migrationBuilder.Sql(@"
                DELETE FROM ""RentalEvidencesLA"";
                
                ALTER TABLE ""RentalEvidencesLA"" 
                ADD COLUMN ""ReportId"" integer NOT NULL DEFAULT 0;
                
                CREATE INDEX ""IX_RentalEvidencesLA_ReportId"" 
                ON ""RentalEvidencesLA"" (""ReportId"");
                
                ALTER TABLE ""RentalEvidencesLA"" 
                ADD CONSTRAINT ""FK_RentalEvidencesLA_Reports_ReportId"" 
                FOREIGN KEY (""ReportId"") REFERENCES ""Reports"" (""ReportId"") ON DELETE CASCADE;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove ReportId column and related constraints
            migrationBuilder.Sql(@"
                ALTER TABLE ""RentalEvidencesLA"" 
                DROP CONSTRAINT IF EXISTS ""FK_RentalEvidencesLA_Reports_ReportId"";
                
                DROP INDEX IF EXISTS ""IX_RentalEvidencesLA_ReportId"";
                
                ALTER TABLE ""RentalEvidencesLA"" 
                DROP COLUMN IF EXISTS ""ReportId"";
            ");
        }
    }
}
