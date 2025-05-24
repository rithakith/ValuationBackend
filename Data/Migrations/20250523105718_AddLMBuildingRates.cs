using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLMBuildingRates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LMBuildingRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReportId = table.Column<int>(type: "integer", nullable: false),
                    MasterFileRefNo = table.Column<string>(type: "text", nullable: false),
                    AssessmentNumber = table.Column<string>(type: "text", nullable: true),
                    Owner = table.Column<string>(type: "text", nullable: true),
                    ConstructedBy = table.Column<string>(type: "text", nullable: true),
                    YearOfConstruction = table.Column<string>(type: "text", nullable: true),
                    DescriptionOfProperty = table.Column<string>(type: "text", nullable: true),
                    FloorArea = table.Column<string>(type: "text", nullable: true),
                    RatePerSQFT = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    LocationLatitude = table.Column<string>(type: "text", nullable: true),
                    LocationLongitude = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMBuildingRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LMBuildingRates_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LMBuildingRates_ReportId",
                table: "LMBuildingRates",
                column: "ReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LMBuildingRates");
        }
    }
}
