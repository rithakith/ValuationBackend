using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddI2RentalEvidenceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficesRatingCard");

            migrationBuilder.CreateTable(
                name: "I2RentalEvidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssetId = table.Column<int>(type: "integer", nullable: false),
                    AssessmentNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    OwnerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OccupierName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DescriptionOfProperty = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Building = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PropertyCategory = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PropertySubcategory = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PropertyType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FloorRate = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    RatePer = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RatePerMonth = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    HeadOfTerms = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Situation = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Remarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_I2RentalEvidences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_I2RentalEvidences_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_I2RentalEvidence_AssetId",
                table: "I2RentalEvidences",
                column: "AssetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "I2RentalEvidences");

            migrationBuilder.CreateTable(
                name: "OfficesRatingCard",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_OfficesRatingCard_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
