using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddLandMiscellaneousMasterFileIdToLMTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LandMiscellaneousMasterFileId",
                table: "LMSalesEvidences",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LandMiscellaneousMasterFileId",
                table: "LMPastValuations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LandMiscellaneousMasterFileId",
                table: "LMBuildingRates",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LMSalesEvidence_LandMiscellaneousMasterFileId",
                table: "LMSalesEvidences",
                column: "LandMiscellaneousMasterFileId");

            migrationBuilder.CreateIndex(
                name: "IX_LMPastValuation_LandMiscellaneousMasterFileId",
                table: "LMPastValuations",
                column: "LandMiscellaneousMasterFileId");

            migrationBuilder.CreateIndex(
                name: "IX_LMBuildingRates_LandMiscellaneousMasterFileId",
                table: "LMBuildingRates",
                column: "LandMiscellaneousMasterFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_LMBuildingRates_LandMiscellaneousMasterFiles_LandMiscellane~",
                table: "LMBuildingRates",
                column: "LandMiscellaneousMasterFileId",
                principalTable: "LandMiscellaneousMasterFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LMPastValuations_LandMiscellaneousMasterFiles_LandMiscellan~",
                table: "LMPastValuations",
                column: "LandMiscellaneousMasterFileId",
                principalTable: "LandMiscellaneousMasterFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LMSalesEvidences_LandMiscellaneousMasterFiles_LandMiscellan~",
                table: "LMSalesEvidences",
                column: "LandMiscellaneousMasterFileId",
                principalTable: "LandMiscellaneousMasterFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LMBuildingRates_LandMiscellaneousMasterFiles_LandMiscellane~",
                table: "LMBuildingRates");

            migrationBuilder.DropForeignKey(
                name: "FK_LMPastValuations_LandMiscellaneousMasterFiles_LandMiscellan~",
                table: "LMPastValuations");

            migrationBuilder.DropForeignKey(
                name: "FK_LMSalesEvidences_LandMiscellaneousMasterFiles_LandMiscellan~",
                table: "LMSalesEvidences");

            migrationBuilder.DropIndex(
                name: "IX_LMSalesEvidence_LandMiscellaneousMasterFileId",
                table: "LMSalesEvidences");

            migrationBuilder.DropIndex(
                name: "IX_LMPastValuation_LandMiscellaneousMasterFileId",
                table: "LMPastValuations");

            migrationBuilder.DropIndex(
                name: "IX_LMBuildingRates_LandMiscellaneousMasterFileId",
                table: "LMBuildingRates");

            migrationBuilder.DropColumn(
                name: "LandMiscellaneousMasterFileId",
                table: "LMSalesEvidences");

            migrationBuilder.DropColumn(
                name: "LandMiscellaneousMasterFileId",
                table: "LMPastValuations");

            migrationBuilder.DropColumn(
                name: "LandMiscellaneousMasterFileId",
                table: "LMBuildingRates");
        }
    }
}
