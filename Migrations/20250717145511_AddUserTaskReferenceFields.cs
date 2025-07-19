using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTaskReferenceFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LandAcquisitionId",
                table: "UserTasks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LandMiscellaneousId",
                table: "UserTasks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNumber",
                table: "UserTasks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "UserTasks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkItemDescription",
                table: "UserTasks",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "LandMiscellaneousMasterFiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "RequestingAuthorityReferenceNo",
                table: "LandMiscellaneousMasterFiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PlanType",
                table: "LandMiscellaneousMasterFiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PlanNo",
                table: "LandMiscellaneousMasterFiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LandAcquisitionId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "LandMiscellaneousId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "ReferenceNumber",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "WorkItemDescription",
                table: "UserTasks");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "LandMiscellaneousMasterFiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RequestingAuthorityReferenceNo",
                table: "LandMiscellaneousMasterFiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlanType",
                table: "LandMiscellaneousMasterFiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlanNo",
                table: "LandMiscellaneousMasterFiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
