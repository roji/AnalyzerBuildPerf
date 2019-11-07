using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddIsDefaultToFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_default",
                schema: "engage",
                table: "activity_filter",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_default",
                schema: "admin",
                table: "account_filter",
                nullable: false,
                defaultValue: false);

            migrationBuilder.Sql("update engage.activity_filter set is_default=false");
            migrationBuilder.Sql("update admin.account_filter set is_default=false");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_default",
                schema: "engage",
                table: "activity_filter");

            migrationBuilder.DropColumn(
                name: "is_default",
                schema: "admin",
                table: "account_filter");
        }
    }
}
