using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class FilterSaveColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "save_columns",
                schema: "engage",
                table: "activity_filter",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "save_columns",
                schema: "admin",
                table: "filter",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "save_columns",
                schema: "admin",
                table: "account_filter",
                nullable: true,
                defaultValue: false);

            migrationBuilder.Sql("update engage.activity_filter set save_columns = false");
            migrationBuilder.Sql("update admin.filter set save_columns = false");
            migrationBuilder.Sql("update admin.account_filter set save_columns = false");

            // modify to be non null
            migrationBuilder.AlterColumn<bool>(
                name: "save_columns",
                schema: "engage",
                table: "activity_filter",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "save_columns",
                schema: "admin",
                table: "filter",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "save_columns",
                schema: "admin",
                table: "account_filter",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "save_columns",
                schema: "engage",
                table: "activity_filter");

            migrationBuilder.DropColumn(
                name: "save_columns",
                schema: "admin",
                table: "filter");

            migrationBuilder.DropColumn(
                name: "save_columns",
                schema: "admin",
                table: "account_filter");
        }
    }
}
