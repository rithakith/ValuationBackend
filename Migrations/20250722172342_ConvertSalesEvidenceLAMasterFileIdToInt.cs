using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class ConvertSalesEvidenceLAMasterFileIdToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Add temporary column for integer MasterFileId
            migrationBuilder.AddColumn<int>(
                name: "MasterFileId_temp",
                table: "SalesEvidencesLA",
                type: "integer",
                nullable: true);

            // Step 2: Update temp column with converted values - only for numeric strings
            migrationBuilder.Sql(@"
                UPDATE ""SalesEvidencesLA""
                SET ""MasterFileId_temp"" = CAST(""MasterFileId"" AS INTEGER)
                WHERE ""MasterFileId"" ~ '^[0-9]+$'
                AND EXISTS (
                    SELECT 1 FROM ""LandAquisitionMasterFiles"" 
                    WHERE ""Id"" = CAST(""SalesEvidencesLA"".""MasterFileId"" AS INTEGER)
                );
            ");

            // Step 3: Delete records with invalid MasterFileId references
            migrationBuilder.Sql(@"
                DELETE FROM ""SalesEvidencesLA""
                WHERE ""MasterFileId_temp"" IS NULL;
            ");

            // Step 4: Drop the old column
            migrationBuilder.DropColumn(
                name: "MasterFileId",
                table: "SalesEvidencesLA");

            // Step 5: Rename temp column
            migrationBuilder.RenameColumn(
                name: "MasterFileId_temp",
                table: "SalesEvidencesLA",
                newName: "MasterFileId");

            // Step 6: Make the column non-nullable
            migrationBuilder.AlterColumn<int>(
                name: "MasterFileId",
                table: "SalesEvidencesLA",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            // Step 7: Create index and foreign key
            migrationBuilder.CreateIndex(
                name: "IX_SalesEvidencesLA_MasterFileId",
                table: "SalesEvidencesLA",
                column: "MasterFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesEvidencesLA_LandAquisitionMasterFiles_MasterFileId",
                table: "SalesEvidencesLA",
                column: "MasterFileId",
                principalTable: "LandAquisitionMasterFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesEvidencesLA_LandAquisitionMasterFiles_MasterFileId",
                table: "SalesEvidencesLA");

            migrationBuilder.DropIndex(
                name: "IX_SalesEvidencesLA_MasterFileId",
                table: "SalesEvidencesLA");

            // Add temporary string column
            migrationBuilder.AddColumn<string>(
                name: "MasterFileId_temp",
                table: "SalesEvidencesLA",
                type: "text",
                nullable: true);

            // Convert integer values back to string
            migrationBuilder.Sql(@"
                UPDATE ""SalesEvidencesLA""
                SET ""MasterFileId_temp"" = CAST(""MasterFileId"" AS TEXT);
            ");

            // Drop the integer column
            migrationBuilder.DropColumn(
                name: "MasterFileId",
                table: "SalesEvidencesLA");

            // Rename temp column back
            migrationBuilder.RenameColumn(
                name: "MasterFileId_temp",
                table: "SalesEvidencesLA",
                newName: "MasterFileId");

            // Make the column non-nullable
            migrationBuilder.AlterColumn<string>(
                name: "MasterFileId",
                table: "SalesEvidencesLA",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
