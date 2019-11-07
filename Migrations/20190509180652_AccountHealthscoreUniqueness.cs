using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AccountHealthscoreUniqueness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_health_setting_id__account_heath_setting",
                schema: "health",
                table: "account_healthscore");

            migrationBuilder.DropForeignKey(
                name: "fk_account_healthscore_healthscore_healthscore_id",
                schema: "health",
                table: "account_healthscore");

            migrationBuilder.DropIndex(
                name: "account_healthscore_account_health_setting_id_idx",
                schema: "health",
                table: "account_healthscore");

            migrationBuilder.DropIndex(
                name: "ix_account_healthscore_healthscore_id",
                schema: "health",
                table: "account_healthscore");

            migrationBuilder.AlterColumn<long>(
                name: "healthscore_id",
                schema: "health",
                table: "account_healthscore",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "account_health_setting_id",
                schema: "health",
                table: "account_healthscore",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_account_healthscore_account_health_setting_id_healthscore_id",
                schema: "health",
                table: "account_healthscore",
                columns: new[] { "account_health_setting_id", "healthscore_id" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_account_healthscore_account_health_setting_account_health_s~",
                schema: "health",
                table: "account_healthscore",
                column: "account_health_setting_id",
                principalSchema: "health",
                principalTable: "account_health_setting",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_healthscore_healthscore_healthscore_id",
                schema: "health",
                table: "account_healthscore",
                column: "healthscore_id",
                principalSchema: "health",
                principalTable: "healthscore",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_healthscore_account_health_setting_account_health_s~",
                schema: "health",
                table: "account_healthscore");

            migrationBuilder.DropForeignKey(
                name: "fk_account_healthscore_healthscore_healthscore_id",
                schema: "health",
                table: "account_healthscore");

            migrationBuilder.DropIndex(
                name: "ix_account_healthscore_account_health_setting_id_healthscore_id",
                schema: "health",
                table: "account_healthscore");

            migrationBuilder.AlterColumn<long>(
                name: "healthscore_id",
                schema: "health",
                table: "account_healthscore",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "account_health_setting_id",
                schema: "health",
                table: "account_healthscore",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "account_healthscore_account_health_setting_id_idx",
                schema: "health",
                table: "account_healthscore",
                column: "account_health_setting_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_healthscore_healthscore_id",
                schema: "health",
                table: "account_healthscore",
                column: "healthscore_id");

            migrationBuilder.AddForeignKey(
                name: "fk_account_health_setting_id__account_heath_setting",
                schema: "health",
                table: "account_healthscore",
                column: "account_health_setting_id",
                principalSchema: "health",
                principalTable: "account_health_setting",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_account_healthscore_healthscore_healthscore_id",
                schema: "health",
                table: "account_healthscore",
                column: "healthscore_id",
                principalSchema: "health",
                principalTable: "healthscore",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
