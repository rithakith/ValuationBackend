using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnusedFieldsFromAssetNumberChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AssetNumberChanges");

            migrationBuilder.DropColumn(
                name: "FieldSize",
                table: "AssetNumberChanges");

            migrationBuilder.DropColumn(
                name: "FieldType",
                table: "AssetNumberChanges");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AssetNumberChanges",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldSize",
                table: "AssetNumberChanges",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldType",
                table: "AssetNumberChanges",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
