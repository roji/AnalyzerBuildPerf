using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class sfdcNameAndQueueName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "salesforce_name",
                schema: "events",
                table: "sfdc_integration_error",
                maxLength: 75,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "queue_name",
                schema: "admin",
                table: "company",
                maxLength: 75,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salesforce_name",
                schema: "events",
                table: "sfdc_integration_error");

            migrationBuilder.DropColumn(
                name: "queue_name",
                schema: "admin",
                table: "company");
        }
    }
}
