using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ValuationBackend.Migrations
{
    public partial class AddOfficesRatingCardTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfficesRatingCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(nullable: false),
                    BuildingSelection = table.Column<string>(maxLength: 100, nullable: true),
                    LocalAuthority = table.Column<string>(maxLength: 200, nullable: true),
                    LocalAuthorityCode = table.Column<string>(maxLength: 50, nullable: true),
                    AssessmentNumber = table.Column<string>(maxLength: 50, nullable: true),
                    NewNumber = table.Column<string>(maxLength: 50, nullable: true),
                    ObsoleteNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Owner = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    WallType = table.Column<string>(maxLength: 100, nullable: true),
                    FloorType = table.Column<string>(maxLength: 100, nullable: true),
                    Conveniences = table.Column<string>(maxLength: 100, nullable: true),
                    Condition = table.Column<string>(maxLength: 50, nullable: true),
                    Age = table.Column<int>(nullable: true),
                    AccessType = table.Column<string>(maxLength: 100, nullable: true),
                    OfficeGrade = table.Column<string>(maxLength: 50, nullable: true),
                    ParkingSpace = table.Column<string>(maxLength: 200, nullable: true),
                    PropertySubCategory = table.Column<string>(maxLength: 100, nullable: true),
                    PropertyType = table.Column<string>(maxLength: 100, nullable: true),
                    WardNumber = table.Column<int>(nullable: true),
                    RoadName = table.Column<string>(maxLength: 200, nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Occupier = table.Column<string>(maxLength: 200, nullable: true),
                    RentPM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Terms = table.Column<string>(maxLength: 500, nullable: true),
                    FloorNumber = table.Column<int>(nullable: true),
                    CeilingHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OfficeSuite = table.Column<string>(maxLength: 1000, nullable: true),
                    TotalArea = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UsableFloorArea = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SuggestedRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficesRatingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficesRatingCards_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfficesRatingCards_AssetId",
                table: "OfficesRatingCards",
                column: "AssetId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficesRatingCards");
        }
    }
}