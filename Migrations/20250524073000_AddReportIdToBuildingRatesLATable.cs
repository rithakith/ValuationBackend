using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddReportIdToBuildingRatesLATable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // First, update existing columns to nullable if they were set as non-nullable
            migrationBuilder.AlterColumn<string>(
                name: "AssessmentNumber",
                table: "BuildingRatesLA",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "BuildingRatesLA",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ConstructedBy",
                table: "BuildingRatesLA",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "YearOfConstruction",
                table: "BuildingRatesLA",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionOfProperty",
                table: "BuildingRatesLA",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FloorAreaSQFT",
                table: "BuildingRatesLA",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "RatePerSQFT",
                table: "BuildingRatesLA",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Cost",
                table: "BuildingRatesLA",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "BuildingRatesLA",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LocationLatitude",
                table: "BuildingRatesLA",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LocationLongitude",
                table: "BuildingRatesLA",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            // Add ReportId column to existing BuildingRatesLA table
            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "BuildingRatesLA",
                type: "integer",
                nullable: false,
                defaultValue: 1); // Use a default value since we need to satisfy NOT NULL constraint

            // Create foreign key relationship
            migrationBuilder.CreateIndex(
                name: "IX_BuildingRatesLA_ReportId",
                table: "BuildingRatesLA",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingRatesLA_Reports_ReportId",
                table: "BuildingRatesLA",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingRatesLA_Reports_ReportId",
                table: "BuildingRatesLA");

            // Remove index
            migrationBuilder.DropIndex(
                name: "IX_BuildingRatesLA_ReportId",
                table: "BuildingRatesLA");

            // Remove ReportId column
            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "BuildingRatesLA");

            // Revert column nullability changes
            migrationBuilder.AlterColumn<string>(
                name: "AssessmentNumber",
                table: "BuildingRatesLA",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "BuildingRatesLA",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConstructedBy",
                table: "BuildingRatesLA",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "YearOfConstruction",
                table: "BuildingRatesLA",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionOfProperty",
                table: "BuildingRatesLA",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FloorAreaSQFT",
                table: "BuildingRatesLA",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RatePerSQFT",
                table: "BuildingRatesLA",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cost",
                table: "BuildingRatesLA",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "BuildingRatesLA",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LocationLatitude",
                table: "BuildingRatesLA",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LocationLongitude",
                table: "BuildingRatesLA",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
