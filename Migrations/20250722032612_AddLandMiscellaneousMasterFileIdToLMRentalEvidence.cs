using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddLandMiscellaneousMasterFileIdToLMRentalEvidence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LandMiscellaneousMasterFileId",
                table: "LMRentalEvidences",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LMRentalEvidence_LandMiscellaneousMasterFileId",
                table: "LMRentalEvidences",
                column: "LandMiscellaneousMasterFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_LMRentalEvidences_LandMiscellaneousMasterFiles_LandMiscella~",
                table: "LMRentalEvidences",
                column: "LandMiscellaneousMasterFileId",
                principalTable: "LandMiscellaneousMasterFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LMRentalEvidences_LandMiscellaneousMasterFiles_LandMiscella~",
                table: "LMRentalEvidences");

            migrationBuilder.DropIndex(
                name: "IX_LMRentalEvidence_LandMiscellaneousMasterFileId",
                table: "LMRentalEvidences");

            migrationBuilder.DropColumn(
                name: "LandMiscellaneousMasterFileId",
                table: "LMRentalEvidences");
        }
    }
}
