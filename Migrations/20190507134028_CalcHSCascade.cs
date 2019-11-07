using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class CalcHSCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_parent_healthscore_id__healthscore",
                schema: "health",
                table: "healthscore_component");

            migrationBuilder.CreateIndex(
                name: "ix_healthscore_component_parent_healthscore_id",
                schema: "health",
                table: "healthscore_component",
                column: "parent_healthscore_id");

            migrationBuilder.AddForeignKey(
                name: "fk_healthscore_component_healthscore_parent_healthscore_id",
                schema: "health",
                table: "healthscore_component",
                column: "parent_healthscore_id",
                principalSchema: "health",
                principalTable: "healthscore",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "fk_healthscore_component_healthscore_parent_healthscore_id",
               schema: "health",
               table: "healthscore_component");

            migrationBuilder.DropIndex(
                name: "ix_healthscore_component_parent_healthscore_id",
                schema: "health",
                table: "healthscore_component");

            migrationBuilder.AddForeignKey(
                name: "fk_parent_healthscore_id__healthscore",
                schema: "health",
                table: "healthscore_component",
                column: "parent_healthscore_id",
                principalSchema: "health",
                principalTable: "healthscore",
                principalColumn: "id");
        }
    }
}
