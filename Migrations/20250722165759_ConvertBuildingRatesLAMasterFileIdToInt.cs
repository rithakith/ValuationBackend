using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class ConvertBuildingRatesLAMasterFileIdToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Add a temporary column for the integer values
            migrationBuilder.AddColumn<int>(
                name: "MasterFileId_Temp",
                table: "BuildingRatesLA",
                type: "integer",
                nullable: true);

            // Step 2: Convert existing string data to integers with validation
            migrationBuilder.Sql(@"
                UPDATE ""BuildingRatesLA""
                SET ""MasterFileId_Temp"" = CASE 
                    WHEN ""MasterFileId"" ~ '^[0-9]+$' AND ""MasterFileId"" != '' THEN 
                        CAST(""MasterFileId"" AS integer)
                    ELSE 
                        1  -- Default to 1 if invalid or empty
                END;
            ");

            // Step 3: Drop the old string column
            migrationBuilder.DropColumn(
                name: "MasterFileId",
                table: "BuildingRatesLA");

            // Step 4: Rename the temporary column to the original name
            migrationBuilder.RenameColumn(
                name: "MasterFileId_Temp",
                table: "BuildingRatesLA",
                newName: "MasterFileId");

            // Step 5: Make the column non-nullable
            migrationBuilder.AlterColumn<int>(
                name: "MasterFileId",
                table: "BuildingRatesLA",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            // Step 6: Create index and foreign key
            migrationBuilder.CreateIndex(
                name: "IX_BuildingRatesLA_MasterFileId",
                table: "BuildingRatesLA",
                column: "MasterFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingRatesLA_LandAquisitionMasterFiles_MasterFileId",
                table: "BuildingRatesLA",
                column: "MasterFileId",
                principalTable: "LandAquisitionMasterFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop foreign key and index
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingRatesLA_LandAquisitionMasterFiles_MasterFileId",
                table: "BuildingRatesLA");

            migrationBuilder.DropIndex(
                name: "IX_BuildingRatesLA_MasterFileId",
                table: "BuildingRatesLA");

            // Step 2: Add temporary string column
            migrationBuilder.AddColumn<string>(
                name: "MasterFileId_Temp",
                table: "BuildingRatesLA",
                type: "text",
                nullable: true);

            // Step 3: Convert integer values back to strings
            migrationBuilder.Sql(@"
                UPDATE ""BuildingRatesLA""
                SET ""MasterFileId_Temp"" = CAST(""MasterFileId"" AS text);
            ");

            // Step 4: Drop the integer column
            migrationBuilder.DropColumn(
                name: "MasterFileId",
                table: "BuildingRatesLA");

            // Step 5: Rename temporary column back
            migrationBuilder.RenameColumn(
                name: "MasterFileId_Temp",
                table: "BuildingRatesLA",
                newName: "MasterFileId");

            // Step 6: Make column non-nullable string
            migrationBuilder.AlterColumn<string>(
                name: "MasterFileId",
                table: "BuildingRatesLA",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
