using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddMrrArrCalculatedFieldsToAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "arr_sum",
                schema: "admin",
                table: "account",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "mrr_sum",
                schema: "admin",
                table: "account",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "arr_sum",
                schema: "admin",
                table: "account");

            migrationBuilder.DropColumn(
                name: "mrr_sum",
                schema: "admin",
                table: "account");
        }
    }
}
