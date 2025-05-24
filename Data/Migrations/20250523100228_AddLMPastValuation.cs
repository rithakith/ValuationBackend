using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLMPastValuation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LMPastValuations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReportId = table.Column<int>(type: "integer", nullable: false),
                    MasterFileRefNo = table.Column<string>(type: "text", nullable: false),
                    FileNo_GnDivision = table.Column<string>(type: "text", nullable: true),
                    Situation = table.Column<string>(type: "text", nullable: true),
                    DateOfValuation = table.Column<string>(type: "text", nullable: true),
                    PurposeOfValuation = table.Column<string>(type: "text", nullable: true),
                    PlanOfParticulars = table.Column<string>(type: "text", nullable: true),
                    Extent = table.Column<string>(type: "text", nullable: true),
                    Rate = table.Column<string>(type: "text", nullable: true),
                    RateType = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    LocationLongitude = table.Column<string>(type: "text", nullable: true),
                    LocationLatitude = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMPastValuations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LMPastValuations_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LMPastValuations_ReportId",
                table: "LMPastValuations",
                column: "ReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LMPastValuations");
        }
    }
}
