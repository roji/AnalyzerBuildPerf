using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class SfdcIntegrationObjectUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "integration_template_id",
                schema: "events",
                table: "sfdc_integration_object",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "integration_id",
                schema: "events",
                table: "sfdc_integration_object",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "field_mapping",
                schema: "events",
                table: "sfdc_integration_object",
                type: "jsonb",
                nullable: true,
                defaultValue: "[]",
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldNullable: true,
                oldDefaultValue: "{}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "integration_template_id",
                schema: "events",
                table: "sfdc_integration_object",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "integration_id",
                schema: "events",
                table: "sfdc_integration_object",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "field_mapping",
                schema: "events",
                table: "sfdc_integration_object",
                type: "jsonb",
                nullable: true,
                defaultValue: "{}",
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldNullable: true,
                oldDefaultValue: "[]");
        }
    }
}
