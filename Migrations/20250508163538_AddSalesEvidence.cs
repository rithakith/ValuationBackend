using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesEvidence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesEvidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MasterFileId = table.Column<string>(type: "text", nullable: false),
                    AssetNumber = table.Column<string>(type: "text", nullable: false),
                    MasterFileRefNo = table.Column<string>(type: "text", nullable: false),
                    Road = table.Column<string>(type: "text", nullable: false),
                    Village = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    Occupier = table.Column<string>(type: "text", nullable: false),
                    Vendor = table.Column<string>(type: "text", nullable: false),
                    DeedNumber = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FloorRate = table.Column<string>(type: "text", nullable: false),
                    DeedAttestedNumber = table.Column<string>(type: "text", nullable: false),
                    NotaryName = table.Column<string>(type: "text", nullable: false),
                    LotNumber = table.Column<string>(type: "text", nullable: false),
                    PlanNumber = table.Column<string>(type: "text", nullable: false),
                    PlanDate = table.Column<string>(type: "text", nullable: false),
                    Extent = table.Column<string>(type: "text", nullable: false),
                    Consideration = table.Column<string>(type: "text", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    Rate = table.Column<string>(type: "text", nullable: false),
                    RateType = table.Column<string>(type: "text", nullable: false),
                    LocationLongitude = table.Column<string>(type: "text", nullable: false),
                    LocationLatitude = table.Column<string>(type: "text", nullable: false),
                    LandRegistryReferences = table.Column<string>(type: "text", nullable: false),
                    Situation = table.Column<string>(type: "text", nullable: false),
                    DescriptionOfProperty = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesEvidences", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesEvidences");
        }
    }
}
