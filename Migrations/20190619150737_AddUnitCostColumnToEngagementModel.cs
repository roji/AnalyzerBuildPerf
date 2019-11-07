using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddUnitCostColumnToEngagementModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "unit_cost",
                schema: "engage",
                table: "engagement_model",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "unit_cost",
                schema: "engage",
                table: "engagement_model");
        }
    }
}
