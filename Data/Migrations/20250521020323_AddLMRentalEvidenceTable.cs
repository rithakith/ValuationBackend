using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLMRentalEvidenceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LMRentalEvidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReportId = table.Column<int>(type: "integer", nullable: false),
                    MasterFileRefNo = table.Column<string>(type: "text", nullable: false),
                    AssessmentNo = table.Column<string>(type: "text", nullable: true),
                    Owner = table.Column<string>(type: "text", nullable: true),
                    Occupier = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    FloorRate = table.Column<string>(type: "text", nullable: true),
                    RatePer = table.Column<string>(type: "text", nullable: true),
                    RatePerMonth = table.Column<string>(type: "text", nullable: true),
                    LocationLongitude = table.Column<string>(type: "text", nullable: true),
                    LocationLatitude = table.Column<string>(type: "text", nullable: true),
                    HeadOfTerms = table.Column<string>(type: "text", nullable: true),
                    Situation = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMRentalEvidences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LMRentalEvidences_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LMRentalEvidences_ReportId",
                table: "LMRentalEvidences",
                column: "ReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LMRentalEvidences");
        }
    }
}
