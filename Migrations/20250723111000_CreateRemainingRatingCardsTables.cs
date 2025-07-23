using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class CreateRemainingRatingCardsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create ShopsRatingCards table
            migrationBuilder.CreateTable(
                name: "ShopsRatingCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssetId = table.Column<int>(type: "integer", nullable: false),
                    NewNumber = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
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
                    ShopGrade = table.Column<string>(type: "text", nullable: true),
                    ParkingSpace = table.Column<string>(type: "text", nullable: true),
                    PropertySubCategory = table.Column<string>(type: "text", nullable: true),
                    PropertyType = table.Column<string>(type: "text", nullable: true),
                    WardNumber = table.Column<int>(type: "integer", nullable: true),
                    RoadName = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Occupier = table.Column<string>(type: "text", nullable: true),
                    RentPM = table.Column<decimal>(type: "numeric", nullable: true),
                    Terms = table.Column<string>(type: "text", nullable: true),
                    DisplayArea = table.Column<string>(type: "text", nullable: true),
                    FrontageWidth = table.Column<decimal>(type: "numeric", nullable: true),
                    ShopDepth = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalArea = table.Column<decimal>(type: "numeric", nullable: true),
                    SuggestedRate = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopsRatingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopsRatingCards_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Create AgricultureRatingCards table
            migrationBuilder.CreateTable(
                name: "AgricultureRatingCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssetId = table.Column<int>(type: "integer", nullable: false),
                    NewNumber = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LocalAuthority = table.Column<string>(type: "text", nullable: true),
                    LocalAuthorityCode = table.Column<string>(type: "text", nullable: true),
                    AssessmentNumber = table.Column<string>(type: "text", nullable: true),
                    ObsoleteNumber = table.Column<string>(type: "text", nullable: true),
                    CropType = table.Column<string>(type: "text", nullable: true),
                    SoilType = table.Column<string>(type: "text", nullable: true),
                    IrrigationType = table.Column<string>(type: "text", nullable: true),
                    TopographyType = table.Column<string>(type: "text", nullable: true),
                    AccessType = table.Column<string>(type: "text", nullable: true),
                    PropertySubCategory = table.Column<string>(type: "text", nullable: true),
                    PropertyType = table.Column<string>(type: "text", nullable: true),
                    WardNumber = table.Column<int>(type: "integer", nullable: true),
                    RoadName = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Occupier = table.Column<string>(type: "text", nullable: true),
                    RentPM = table.Column<decimal>(type: "numeric", nullable: true),
                    Terms = table.Column<string>(type: "text", nullable: true),
                    TotalAcreage = table.Column<decimal>(type: "numeric", nullable: true),
                    CultivatedArea = table.Column<decimal>(type: "numeric", nullable: true),
                    YieldPerAcre = table.Column<decimal>(type: "numeric", nullable: true),
                    WaterSource = table.Column<string>(type: "text", nullable: true),
                    SuggestedRate = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgricultureRatingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgricultureRatingCards_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Create SpecialRatingCards table
            migrationBuilder.CreateTable(
                name: "SpecialRatingCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssetId = table.Column<int>(type: "integer", nullable: false),
                    NewNumber = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LocalAuthority = table.Column<string>(type: "text", nullable: true),
                    LocalAuthorityCode = table.Column<string>(type: "text", nullable: true),
                    AssessmentNumber = table.Column<string>(type: "text", nullable: true),
                    ObsoleteNumber = table.Column<string>(type: "text", nullable: true),
                    SpecialPropertyType = table.Column<string>(type: "text", nullable: true),
                    SpecialCategory = table.Column<string>(type: "text", nullable: true),
                    FacilityType = table.Column<string>(type: "text", nullable: true),
                    OperatingStatus = table.Column<string>(type: "text", nullable: true),
                    LicenseStatus = table.Column<string>(type: "text", nullable: true),
                    Capacity = table.Column<int>(type: "integer", nullable: true),
                    AccessType = table.Column<string>(type: "text", nullable: true),
                    PropertySubCategory = table.Column<string>(type: "text", nullable: true),
                    PropertyType = table.Column<string>(type: "text", nullable: true),
                    WardNumber = table.Column<int>(type: "integer", nullable: true),
                    RoadName = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Occupier = table.Column<string>(type: "text", nullable: true),
                    RentPM = table.Column<decimal>(type: "numeric", nullable: true),
                    Terms = table.Column<string>(type: "text", nullable: true),
                    AnnualRevenue = table.Column<decimal>(type: "numeric", nullable: true),
                    OperatingCosts = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalArea = table.Column<decimal>(type: "numeric", nullable: true),
                    SpecialFeatures = table.Column<string>(type: "text", nullable: true),
                    SuggestedRate = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialRatingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialRatingCards_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Create indexes
            migrationBuilder.CreateIndex(
                name: "IX_ShopsRatingCards_AssetId",
                table: "ShopsRatingCards",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureRatingCards_AssetId",
                table: "AgricultureRatingCards",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialRatingCards_AssetId",
                table: "SpecialRatingCards",
                column: "AssetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopsRatingCards");

            migrationBuilder.DropTable(
                name: "AgricultureRatingCards");

            migrationBuilder.DropTable(
                name: "SpecialRatingCards");
        }
    }
}