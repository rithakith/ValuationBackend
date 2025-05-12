using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class CreateInspectionReportTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InspectionReports",
                columns: table => new
                {
                    InspectionReportId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReportId = table.Column<int>(type: "integer", nullable: false),
                    MasterFileId = table.Column<string>(type: "text", nullable: false),
                    MasterFileRefNo = table.Column<string>(type: "text", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DsDivision = table.Column<string>(type: "text", nullable: false),
                    District = table.Column<string>(type: "text", nullable: false),
                    Province = table.Column<string>(type: "text", nullable: false),
                    GnDivision = table.Column<string>(type: "text", nullable: false),
                    Village = table.Column<string>(type: "text", nullable: false),
                    OtherInformation = table.Column<string>(type: "text", nullable: false),
                    OtherConstructionDetails = table.Column<string>(type: "text", nullable: false),
                    DetailsOfAssestsInventoryItems = table.Column<string>(type: "text", nullable: false),
                    DetailsOfBusiness = table.Column<string>(type: "text", nullable: false),
                    Remark = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionReports", x => x.InspectionReportId);
                    table.ForeignKey(
                        name: "FK_InspectionReports_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InspectionReportId = table.Column<int>(type: "integer", nullable: false),
                    BuildingId = table.Column<string>(type: "text", nullable: false),
                    BuildingName = table.Column<string>(type: "text", nullable: false),
                    BuildingCategory = table.Column<string>(type: "text", nullable: false),
                    BuildingClass = table.Column<string>(type: "text", nullable: false),
                    DetailOfBuilding = table.Column<string>(type: "text", nullable: false),
                    NoOfFloorsAboveGround = table.Column<string>(type: "text", nullable: false),
                    NoOfFloorsBelowGround = table.Column<string>(type: "text", nullable: false),
                    AgeYears = table.Column<string>(type: "text", nullable: false),
                    ExpectedLifePeriodYears = table.Column<string>(type: "text", nullable: false),
                    ParkingSpace = table.Column<string>(type: "text", nullable: false),
                    Design = table.Column<string>(type: "text", nullable: false),
                    Conveniences = table.Column<string>(type: "text", nullable: false),
                    Structure = table.Column<string>(type: "text", nullable: false),
                    BuildingConditions = table.Column<string>(type: "text", nullable: false),
                    NatureOfConstruction = table.Column<string>(type: "text", nullable: false),
                    Condition = table.Column<string>(type: "text", nullable: false),
                    RoofMaterial = table.Column<string>(type: "text", nullable: false),
                    RoofFrame = table.Column<string>(type: "text", nullable: false),
                    RoofFinisher = table.Column<string>(type: "text", nullable: false),
                    Ceiling = table.Column<string>(type: "text", nullable: false),
                    FoundationStructure = table.Column<string>(type: "text", nullable: false),
                    WallStructure = table.Column<string>(type: "text", nullable: false),
                    FloorStructure = table.Column<string>(type: "text", nullable: false),
                    Door = table.Column<string>(type: "text", nullable: false),
                    Window = table.Column<string>(type: "text", nullable: false),
                    WindowProtection = table.Column<string>(type: "text", nullable: false),
                    BathroomToiletDoorsFittings = table.Column<string>(type: "text", nullable: false),
                    HandRail = table.Column<string>(type: "text", nullable: false),
                    PantryCupboard = table.Column<string>(type: "text", nullable: false),
                    OtherDoors = table.Column<string>(type: "text", nullable: false),
                    WallFinisher = table.Column<string>(type: "text", nullable: false),
                    FloorFinisher = table.Column<string>(type: "text", nullable: false),
                    BathroomToilet = table.Column<string>(type: "text", nullable: false),
                    Services = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionBuildings_InspectionReports_InspectionReportId",
                        column: x => x.InspectionReportId,
                        principalTable: "InspectionReports",
                        principalColumn: "InspectionReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionBuildings_InspectionReportId",
                table: "InspectionBuildings",
                column: "InspectionReportId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionReports_ReportId",
                table: "InspectionReports",
                column: "ReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionBuildings");

            migrationBuilder.DropTable(
                name: "InspectionReports");
        }
    }
}
