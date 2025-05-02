using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddLandMiscellaneousMasterFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LandMiscellaneousMasterFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MasterFileNo = table.Column<int>(type: "integer", nullable: false),
                    PlanType = table.Column<string>(type: "text", nullable: false),
                    PlanNo = table.Column<string>(type: "text", nullable: false),
                    RequestingAuthorityReferenceNo = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandMiscellaneousMasterFiles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandMiscellaneousMasterFiles");
        }
    }
}
