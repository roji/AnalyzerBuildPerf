using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class HealthscoreRollUpToParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "roll_up_to_parent",
                schema: "health",
                table: "healthscore",
                nullable: true,
                defaultValue: false);

            migrationBuilder.Sql("update health.healthscore set roll_up_to_parent = false");

            migrationBuilder.AlterColumn<bool>(
                name: "roll_up_to_parent",
                schema: "health",
                table: "healthscore",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roll_up_to_parent",
                schema: "health",
                table: "healthscore");
        }
    }
}
