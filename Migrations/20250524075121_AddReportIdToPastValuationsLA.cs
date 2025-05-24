using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddReportIdToPastValuationsLA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "PastValuationsLA",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PastValuationsLA_ReportId",
                table: "PastValuationsLA",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_PastValuationsLA_Reports_ReportId",
                table: "PastValuationsLA",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastValuationsLA_Reports_ReportId",
                table: "PastValuationsLA");

            migrationBuilder.DropIndex(
                name: "IX_PastValuationsLA_ReportId",
                table: "PastValuationsLA");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "PastValuationsLA");
        }
    }
}
