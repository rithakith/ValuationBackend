using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePastValuationsLAMasterFileIdToIntWithConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Add a temporary integer column
            migrationBuilder.AddColumn<int>(
                name: "MasterFileId_temp",
                table: "PastValuationsLA",
                type: "integer",
                nullable: true);

            // Step 2: Update the temporary column with converted values
            // Only convert values that are valid integers, set others to NULL
            migrationBuilder.Sql(@"
                UPDATE ""PastValuationsLA"" 
                SET ""MasterFileId_temp"" = CASE 
                    WHEN ""MasterFileId"" ~ '^[0-9]+$' THEN ""MasterFileId""::integer 
                    ELSE NULL 
                END;");

            // Step 3: Drop the old text column
            migrationBuilder.DropColumn(
                name: "MasterFileId",
                table: "PastValuationsLA");

            // Step 4: Rename the temporary column to the original name
            migrationBuilder.RenameColumn(
                name: "MasterFileId_temp",
                table: "PastValuationsLA",
                newName: "MasterFileId");

            // Step 5: Make the column NOT NULL (set default value for any remaining nulls)
            migrationBuilder.Sql(@"
                UPDATE ""PastValuationsLA"" 
                SET ""MasterFileId"" = 1 
                WHERE ""MasterFileId"" IS NULL;");

            migrationBuilder.AlterColumn<int>(
                name: "MasterFileId",
                table: "PastValuationsLA",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            // Step 6: Create index for foreign key
            migrationBuilder.CreateIndex(
                name: "IX_PastValuationsLA_MasterFileId",
                table: "PastValuationsLA",
                column: "MasterFileId");

            // Step 7: Add foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_PastValuationsLA_LandAquisitionMasterFiles_MasterFileId",
                table: "PastValuationsLA",
                column: "MasterFileId",
                principalTable: "LandAquisitionMasterFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_PastValuationsLA_LandAquisitionMasterFiles_MasterFileId",
                table: "PastValuationsLA");

            // Drop index
            migrationBuilder.DropIndex(
                name: "IX_PastValuationsLA_MasterFileId",
                table: "PastValuationsLA");

            // Convert back to string
            migrationBuilder.AlterColumn<string>(
                name: "MasterFileId",
                table: "PastValuationsLA",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
