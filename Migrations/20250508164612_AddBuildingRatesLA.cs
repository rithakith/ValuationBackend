using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddBuildingRatesLA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingRatesLA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MasterFileId = table.Column<string>(type: "text", nullable: false),
                    AssessmentNumber = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    ConstructedBy = table.Column<string>(type: "text", nullable: false),
                    YearOfConstruction = table.Column<string>(type: "text", nullable: false),
                    DescriptionOfProperty = table.Column<string>(type: "text", nullable: false),
                    FloorAreaSQFT = table.Column<string>(type: "text", nullable: false),
                    RatePerSQFT = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<string>(type: "text", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    LocationLatitude = table.Column<string>(type: "text", nullable: false),
                    LocationLongitude = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingRatesLA", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingRatesLA");
        }
    }
}
