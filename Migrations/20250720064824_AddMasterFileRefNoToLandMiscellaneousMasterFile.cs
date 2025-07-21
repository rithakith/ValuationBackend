using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddMasterFileRefNoToLandMiscellaneousMasterFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MasterFileRefNo",
                table: "LandMiscellaneousMasterFiles",
                type: "text",
                nullable: true);

            // Update existing records with MasterFileRefNo based on MasterFileNo
            migrationBuilder.Sql(@"
                UPDATE ""LandMiscellaneousMasterFiles"" 
                SET ""MasterFileRefNo"" = 'Metro 2/LA/' || ""MasterFileNo""
                WHERE ""MasterFileRefNo"" IS NULL;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterFileRefNo",
                table: "LandMiscellaneousMasterFiles");
        }
    }
}
