using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddMasterfileIdToCoordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterfileId",
                table: "SalesEvidenceLACoordinates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MasterfileId",
                table: "RentalEvidenceLACoordinates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MasterfileId",
                table: "PastValuationsLACoordinates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MasterfileId",
                table: "BuildingRatesLACoordinates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesEvidenceLACoordinates_MasterfileId",
                table: "SalesEvidenceLACoordinates",
                column: "MasterfileId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalEvidenceLACoordinates_MasterfileId",
                table: "RentalEvidenceLACoordinates",
                column: "MasterfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PastValuationsLACoordinates_MasterfileId",
                table: "PastValuationsLACoordinates",
                column: "MasterfileId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingRatesLACoordinates_MasterfileId",
                table: "BuildingRatesLACoordinates",
                column: "MasterfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingRatesLACoordinates_LandAquisitionMasterFiles_Master~",
                table: "BuildingRatesLACoordinates",
                column: "MasterfileId",
                principalTable: "LandAquisitionMasterFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PastValuationsLACoordinates_LandAquisitionMasterFiles_Maste~",
                table: "PastValuationsLACoordinates",
                column: "MasterfileId",
                principalTable: "LandAquisitionMasterFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalEvidenceLACoordinates_LandAquisitionMasterFiles_Maste~",
                table: "RentalEvidenceLACoordinates",
                column: "MasterfileId",
                principalTable: "LandAquisitionMasterFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesEvidenceLACoordinates_LandAquisitionMasterFiles_Master~",
                table: "SalesEvidenceLACoordinates",
                column: "MasterfileId",
                principalTable: "LandAquisitionMasterFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingRatesLACoordinates_LandAquisitionMasterFiles_Master~",
                table: "BuildingRatesLACoordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_PastValuationsLACoordinates_LandAquisitionMasterFiles_Maste~",
                table: "PastValuationsLACoordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalEvidenceLACoordinates_LandAquisitionMasterFiles_Maste~",
                table: "RentalEvidenceLACoordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesEvidenceLACoordinates_LandAquisitionMasterFiles_Master~",
                table: "SalesEvidenceLACoordinates");

            migrationBuilder.DropIndex(
                name: "IX_SalesEvidenceLACoordinates_MasterfileId",
                table: "SalesEvidenceLACoordinates");

            migrationBuilder.DropIndex(
                name: "IX_RentalEvidenceLACoordinates_MasterfileId",
                table: "RentalEvidenceLACoordinates");

            migrationBuilder.DropIndex(
                name: "IX_PastValuationsLACoordinates_MasterfileId",
                table: "PastValuationsLACoordinates");

            migrationBuilder.DropIndex(
                name: "IX_BuildingRatesLACoordinates_MasterfileId",
                table: "BuildingRatesLACoordinates");

            migrationBuilder.DropColumn(
                name: "MasterfileId",
                table: "SalesEvidenceLACoordinates");

            migrationBuilder.DropColumn(
                name: "MasterfileId",
                table: "RentalEvidenceLACoordinates");

            migrationBuilder.DropColumn(
                name: "MasterfileId",
                table: "PastValuationsLACoordinates");

            migrationBuilder.DropColumn(
                name: "MasterfileId",
                table: "BuildingRatesLACoordinates");
        }
    }
}
