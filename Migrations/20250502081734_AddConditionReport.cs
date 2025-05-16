using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddConditionReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConditionReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MasterFileId = table.Column<string>(type: "text", nullable: false),
                    NameOfTheVillage = table.Column<string>(type: "text", nullable: false),
                    NameOfTheLand = table.Column<string>(type: "text", nullable: false),
                    AtPlanNumber = table.Column<string>(type: "text", nullable: false),
                    AtLotNumber = table.Column<string>(type: "text", nullable: false),
                    PpCadNumber = table.Column<string>(type: "text", nullable: false),
                    PpCadLotNumber = table.Column<string>(type: "text", nullable: false),
                    AcquiredExtent = table.Column<string>(type: "text", nullable: false),
                    AssessmentNumber = table.Column<string>(type: "text", nullable: false),
                    RoadName = table.Column<string>(type: "text", nullable: false),
                    AccessCategory = table.Column<string>(type: "text", nullable: false),
                    AccessCategoryDescription = table.Column<string>(type: "text", nullable: false),
                    DescriptionOfLand = table.Column<string>(type: "text", nullable: false),
                    LandUseDescription = table.Column<string>(type: "text", nullable: false),
                    LandUseType = table.Column<string>(type: "text", nullable: false),
                    Frontage = table.Column<string>(type: "text", nullable: false),
                    DepthOfLand = table.Column<string>(type: "text", nullable: false),
                    LevelWithAccess = table.Column<string>(type: "text", nullable: false),
                    PlantationDetails = table.Column<string>(type: "text", nullable: false),
                    DetailsOfBusiness = table.Column<string>(type: "text", nullable: false),
                    AcquisitionName = table.Column<string>(type: "text", nullable: false),
                    DatePrepared = table.Column<string>(type: "text", nullable: false),
                    DateOfSection3BA = table.Column<string>(type: "text", nullable: false),
                    BoundaryNorth = table.Column<string>(type: "text", nullable: false),
                    BoundaryEast = table.Column<string>(type: "text", nullable: false),
                    BoundaryWest = table.Column<string>(type: "text", nullable: false),
                    BoundarySouth = table.Column<string>(type: "text", nullable: false),
                    BoundaryBottom = table.Column<string>(type: "text", nullable: false),
                    BuildingDescription = table.Column<string>(type: "text", nullable: false),
                    BuildingInfo = table.Column<string>(type: "text", nullable: false),
                    OtherConstructionsDescription = table.Column<string>(type: "text", nullable: false),
                    OtherConstructionsInfo = table.Column<string>(type: "text", nullable: false),
                    AcquiringOfficerSignature = table.Column<string>(type: "text", nullable: false),
                    GramasewakaSignature = table.Column<string>(type: "text", nullable: false),
                    ChiefValuerRepresentativeSignature = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionReports", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConditionReports");
        }
    }
}
