using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixPastValuationsLAReportId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add ReportId column to PastValuationsLA table
            migrationBuilder.Sql(@"
                ALTER TABLE ""PastValuationsLA"" 
                ADD COLUMN ""ReportId"" integer NOT NULL DEFAULT 0;
                
                CREATE INDEX ""IX_PastValuationsLA_ReportId"" 
                ON ""PastValuationsLA"" (""ReportId"");
                
                ALTER TABLE ""PastValuationsLA"" 
                ADD CONSTRAINT ""FK_PastValuationsLA_Reports_ReportId"" 
                FOREIGN KEY (""ReportId"") REFERENCES ""Reports"" (""ReportId"") 
                ON DELETE CASCADE;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove ReportId column and related constraints
            migrationBuilder.Sql(@"
                ALTER TABLE ""PastValuationsLA"" 
                DROP CONSTRAINT IF EXISTS ""FK_PastValuationsLA_Reports_ReportId"";
                
                DROP INDEX IF EXISTS ""IX_PastValuationsLA_ReportId"";
                
                ALTER TABLE ""PastValuationsLA"" 
                DROP COLUMN IF EXISTS ""ReportId"";
            ");
        }
    }
}
