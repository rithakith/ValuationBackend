using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCoordinateTablesForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingRatesLACoordinates_Reports_ReportId",
                table: "BuildingRatesLACoordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_PastValuationsLACoordinates_Reports_ReportId",
                table: "PastValuationsLACoordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalEvidenceLACoordinates_Reports_ReportId",
                table: "RentalEvidenceLACoordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesEvidenceLACoordinates_Reports_ReportId",
                table: "SalesEvidenceLACoordinates");

            migrationBuilder.RenameColumn(
                name: "ReportId",
                table: "SalesEvidenceLACoordinates",
                newName: "SalesEvidenceId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesEvidenceLACoordinates_ReportId",
                table: "SalesEvidenceLACoordinates",
                newName: "IX_SalesEvidenceLACoordinates_SalesEvidenceId");

            migrationBuilder.RenameColumn(
                name: "ReportId",
                table: "RentalEvidenceLACoordinates",
                newName: "RentalEvidenceId");

            migrationBuilder.RenameIndex(
                name: "IX_RentalEvidenceLACoordinates_ReportId",
                table: "RentalEvidenceLACoordinates",
                newName: "IX_RentalEvidenceLACoordinates_RentalEvidenceId");

            migrationBuilder.RenameColumn(
                name: "ReportId",
                table: "PastValuationsLACoordinates",
                newName: "PastValuationId");

            migrationBuilder.RenameIndex(
                name: "IX_PastValuationsLACoordinates_ReportId",
                table: "PastValuationsLACoordinates",
                newName: "IX_PastValuationsLACoordinates_PastValuationId");

            migrationBuilder.RenameColumn(
                name: "ReportId",
                table: "BuildingRatesLACoordinates",
                newName: "BuildingRateId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingRatesLACoordinates_ReportId",
                table: "BuildingRatesLACoordinates",
                newName: "IX_BuildingRatesLACoordinates_BuildingRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingRatesLACoordinates_BuildingRatesLA_BuildingRateId",
                table: "BuildingRatesLACoordinates",
                column: "BuildingRateId",
                principalTable: "BuildingRatesLA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PastValuationsLACoordinates_PastValuationsLA_PastValuationId",
                table: "PastValuationsLACoordinates",
                column: "PastValuationId",
                principalTable: "PastValuationsLA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalEvidenceLACoordinates_RentalEvidencesLA_RentalEvidenc~",
                table: "RentalEvidenceLACoordinates",
                column: "RentalEvidenceId",
                principalTable: "RentalEvidencesLA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesEvidenceLACoordinates_SalesEvidencesLA_SalesEvidenceId",
                table: "SalesEvidenceLACoordinates",
                column: "SalesEvidenceId",
                principalTable: "SalesEvidencesLA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingRatesLACoordinates_BuildingRatesLA_BuildingRateId",
                table: "BuildingRatesLACoordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_PastValuationsLACoordinates_PastValuationsLA_PastValuationId",
                table: "PastValuationsLACoordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalEvidenceLACoordinates_RentalEvidencesLA_RentalEvidenc~",
                table: "RentalEvidenceLACoordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesEvidenceLACoordinates_SalesEvidencesLA_SalesEvidenceId",
                table: "SalesEvidenceLACoordinates");

            migrationBuilder.RenameColumn(
                name: "SalesEvidenceId",
                table: "SalesEvidenceLACoordinates",
                newName: "ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesEvidenceLACoordinates_SalesEvidenceId",
                table: "SalesEvidenceLACoordinates",
                newName: "IX_SalesEvidenceLACoordinates_ReportId");

            migrationBuilder.RenameColumn(
                name: "RentalEvidenceId",
                table: "RentalEvidenceLACoordinates",
                newName: "ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_RentalEvidenceLACoordinates_RentalEvidenceId",
                table: "RentalEvidenceLACoordinates",
                newName: "IX_RentalEvidenceLACoordinates_ReportId");

            migrationBuilder.RenameColumn(
                name: "PastValuationId",
                table: "PastValuationsLACoordinates",
                newName: "ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_PastValuationsLACoordinates_PastValuationId",
                table: "PastValuationsLACoordinates",
                newName: "IX_PastValuationsLACoordinates_ReportId");

            migrationBuilder.RenameColumn(
                name: "BuildingRateId",
                table: "BuildingRatesLACoordinates",
                newName: "ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingRatesLACoordinates_BuildingRateId",
                table: "BuildingRatesLACoordinates",
                newName: "IX_BuildingRatesLACoordinates_ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingRatesLACoordinates_Reports_ReportId",
                table: "BuildingRatesLACoordinates",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PastValuationsLACoordinates_Reports_ReportId",
                table: "PastValuationsLACoordinates",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalEvidenceLACoordinates_Reports_ReportId",
                table: "RentalEvidenceLACoordinates",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesEvidenceLACoordinates_Reports_ReportId",
                table: "SalesEvidenceLACoordinates",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
