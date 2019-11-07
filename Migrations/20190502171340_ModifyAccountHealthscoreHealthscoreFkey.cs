using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class ModifyAccountHealthscoreHealthscoreFkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // drop existing fk key
            migrationBuilder.DropForeignKey(
                name: "fk_healthscore_id__healthscore",
                schema: "health",
                table: "account_healthscore");

            // create new fk
            migrationBuilder.CreateIndex(
                name: "ix_account_healthscore_healthscore_id",
                schema: "health",
                table: "account_healthscore",
                column: "healthscore_id");

            migrationBuilder.AddForeignKey(
                name: "fk_account_healthscore_healthscore_healthscore_id",
                schema: "health",
                table: "account_healthscore",
                column: "healthscore_id",
                principalSchema: "health",
                principalTable: "healthscore",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "admin",
                table: "modules",
                maxLength: 75,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 75,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "admin",
                table: "modules",
                maxLength: 75,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 75);

            migrationBuilder.DropForeignKey(
                name: "fk_account_healthscore_healthscore_healthscore_id",
                schema: "health",
                table: "account_healthscore");

            migrationBuilder.DropIndex(
                name: "ix_account_healthscore_healthscore_id",
                schema: "health",
                table: "account_healthscore");

            migrationBuilder.AddForeignKey(
                name: "fk_healthscore_id__healthscore",
                schema: "health",
                table: "account_healthscore",
                column: "healthscore_id",
                principalSchema: "health",
                principalTable: "healthscore",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
