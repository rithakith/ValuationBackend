using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class CreateOfficesRatingCardsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfficesRatingCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssetId = table.Column<int>(type: "integer", nullable: false),
                    NewNumber = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    BuildingSelection = table.Column<string>(type: "text", nullable: true),
                    LocalAuthority = table.Column<string>(type: "text", nullable: true),
                    LocalAuthorityCode = table.Column<string>(type: "text", nullable: true),
                    AssessmentNumber = table.Column<string>(type: "text", nullable: true),
                    ObsoleteNumber = table.Column<string>(type: "text", nullable: true),
                    WallType = table.Column<string>(type: "text", nullable: true),
                    FloorType = table.Column<string>(type: "text", nullable: true),
                    Conveniences = table.Column<string>(type: "text", nullable: true),
                    Condition = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    AccessType = table.Column<string>(type: "text", nullable: true),
                    OfficeGrade = table.Column<string>(type: "text", nullable: true),
                    ParkingSpace = table.Column<string>(type: "text", nullable: true),
                    PropertySubCategory = table.Column<string>(type: "text", nullable: true),
                    PropertyType = table.Column<string>(type: "text", nullable: true),
                    WardNumber = table.Column<int>(type: "integer", nullable: true),
                    RoadName = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Occupier = table.Column<string>(type: "text", nullable: true),
                    RentPM = table.Column<decimal>(type: "numeric", nullable: true),
                    Terms = table.Column<string>(type: "text", nullable: true),
                    FloorNumber = table.Column<int>(type: "integer", nullable: true),
                    CeilingHeight = table.Column<decimal>(type: "numeric", nullable: true),
                    OfficeSuite = table.Column<string>(type: "text", nullable: true),
                    TotalArea = table.Column<decimal>(type: "numeric", nullable: true),
                    UsableFloorArea = table.Column<decimal>(type: "numeric", nullable: true),
                    SuggestedRate = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                column: "AssetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficesRatingCards");
        }
    }
}