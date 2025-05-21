using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLMSalesEvidenceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LMSalesEvidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReportId = table.Column<int>(type: "integer", nullable: false),
                    MasterFileRefNo = table.Column<string>(type: "text", nullable: false),
                    AssetNumber = table.Column<string>(type: "text", nullable: true),
                    Road = table.Column<string>(type: "text", nullable: true),
                    Village = table.Column<string>(type: "text", nullable: true),
                    Vendor = table.Column<string>(type: "text", nullable: true),
                    DeedNumber = table.Column<string>(type: "text", nullable: true),
                    DeedAttestedNumber = table.Column<string>(type: "text", nullable: true),
                    NotaryName = table.Column<string>(type: "text", nullable: true),
                    LotNumber = table.Column<string>(type: "text", nullable: true),
                    PlanNumber = table.Column<string>(type: "text", nullable: true),
                    PlanDate = table.Column<string>(type: "text", nullable: true),
                    Extent = table.Column<string>(type: "text", nullable: true),
                    Consideration = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    Rate = table.Column<string>(type: "text", nullable: true),
                    RateType = table.Column<string>(type: "text", nullable: true),
                    LocationLongitude = table.Column<string>(type: "text", nullable: true),
                    LocationLatitude = table.Column<string>(type: "text", nullable: true),
                    LandRegistryReferences = table.Column<string>(type: "text", nullable: true),
                    Situation = table.Column<string>(type: "text", nullable: true),
                    DescriptionOfProperty = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMSalesEvidences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LMSalesEvidences_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LMSalesEvidences_ReportId",
                table: "LMSalesEvidences",
                column: "ReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LMSalesEvidences");
        }
    }
}
