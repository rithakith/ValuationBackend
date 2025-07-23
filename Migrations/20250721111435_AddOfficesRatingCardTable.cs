using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddOfficesRatingCardTable : Migration
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
                    BuildingSelection = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LocalAuthority = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    LocalAuthorityCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AssessmentNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NewNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ObsoleteNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Owner = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    WallType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FloorType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Conveniences = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Condition = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    AccessType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OfficeGrade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ParkingSpace = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PropertySubCategory = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PropertyType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    WardNumber = table.Column<int>(type: "integer", nullable: true),
                    RoadName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Occupier = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    RentPM = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Terms = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FloorNumber = table.Column<int>(type: "integer", nullable: true),
                    CeilingHeight = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    OfficeSuite = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    TotalArea = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    UsableFloorArea = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    SuggestedRate = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false)
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
