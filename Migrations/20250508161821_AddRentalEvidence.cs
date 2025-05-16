using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddRentalEvidence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalEvidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MasterFileId = table.Column<string>(type: "text", nullable: false),
                    AssessmentNo = table.Column<string>(type: "text", nullable: false),
                    MasterFileRefNo = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    Occupier = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FloorRateSQFT = table.Column<string>(type: "text", nullable: false),
                    RatePerSqft = table.Column<string>(type: "text", nullable: false),
                    RatePerMonth = table.Column<string>(type: "text", nullable: false),
                    LocationLongitude = table.Column<string>(type: "text", nullable: false),
                    LocationLatitude = table.Column<string>(type: "text", nullable: false),
                    HeadOfTerms = table.Column<string>(type: "text", nullable: false),
                    Situation = table.Column<string>(type: "text", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalEvidences", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalEvidences");
        }
    }
}
