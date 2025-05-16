using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddPastValuationsLA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PastValuationsLA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MasterFileId = table.Column<string>(type: "text", nullable: false),
                    MasterFileRefNo = table.Column<string>(type: "text", nullable: false),
                    FileNoGNDivision = table.Column<string>(type: "text", nullable: false),
                    Situation = table.Column<string>(type: "text", nullable: false),
                    DateOfValuation = table.Column<string>(type: "text", nullable: false),
                    PurposeOfValuation = table.Column<string>(type: "text", nullable: false),
                    PlanOfParticulars = table.Column<string>(type: "text", nullable: false),
                    Extent = table.Column<string>(type: "text", nullable: false),
                    Rate = table.Column<string>(type: "text", nullable: false),
                    RateType = table.Column<string>(type: "text", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    LocationLongitude = table.Column<string>(type: "text", nullable: false),
                    LocationLatitude = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastValuationsLA", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PastValuationsLA");
        }
    }
}
