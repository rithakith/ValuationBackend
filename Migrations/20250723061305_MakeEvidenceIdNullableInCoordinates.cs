using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class MakeEvidenceIdNullableInCoordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "SalesEvidenceId",
                table: "SalesEvidenceLACoordinates",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "RentalEvidenceId",
                table: "RentalEvidenceLACoordinates",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PastValuationId",
                table: "PastValuationsLACoordinates",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingRateId",
                table: "BuildingRatesLACoordinates",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingRatesLACoordinates_BuildingRatesLA_BuildingRateId",
                table: "BuildingRatesLACoordinates",
                column: "BuildingRateId",
                principalTable: "BuildingRatesLA",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PastValuationsLACoordinates_PastValuationsLA_PastValuationId",
                table: "PastValuationsLACoordinates",
                column: "PastValuationId",
                principalTable: "PastValuationsLA",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalEvidenceLACoordinates_RentalEvidencesLA_RentalEvidenc~",
                table: "RentalEvidenceLACoordinates",
                column: "RentalEvidenceId",
                principalTable: "RentalEvidencesLA",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesEvidenceLACoordinates_SalesEvidencesLA_SalesEvidenceId",
                table: "SalesEvidenceLACoordinates",
                column: "SalesEvidenceId",
                principalTable: "SalesEvidencesLA",
                principalColumn: "Id");
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

            migrationBuilder.AlterColumn<int>(
                name: "SalesEvidenceId",
                table: "SalesEvidenceLACoordinates",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RentalEvidenceId",
                table: "RentalEvidenceLACoordinates",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PastValuationId",
                table: "PastValuationsLACoordinates",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuildingRateId",
                table: "BuildingRatesLACoordinates",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
    }
}
