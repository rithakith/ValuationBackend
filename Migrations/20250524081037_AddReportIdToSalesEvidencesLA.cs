using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddReportIdToSalesEvidencesLA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add ReportId column to SalesEvidencesLA table
            migrationBuilder.Sql(@"
                ALTER TABLE ""SalesEvidencesLA"" 
                ADD COLUMN ""ReportId"" integer NOT NULL DEFAULT 0;
                
                CREATE INDEX ""IX_SalesEvidencesLA_ReportId"" 
                ON ""SalesEvidencesLA"" (""ReportId"");
                
                ALTER TABLE ""SalesEvidencesLA"" 
                ADD CONSTRAINT ""FK_SalesEvidencesLA_Reports_ReportId"" 
                FOREIGN KEY (""ReportId"") REFERENCES ""Reports"" (""ReportId"") 
                ON DELETE CASCADE;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove ReportId column and related constraints
            migrationBuilder.Sql(@"
                ALTER TABLE ""SalesEvidencesLA"" 
                DROP CONSTRAINT IF EXISTS ""FK_SalesEvidencesLA_Reports_ReportId"";
                
                DROP INDEX IF EXISTS ""IX_SalesEvidencesLA_ReportId"";
                
                ALTER TABLE ""SalesEvidencesLA"" 
                DROP COLUMN IF EXISTS ""ReportId"";
            ");
        }
    }
}
