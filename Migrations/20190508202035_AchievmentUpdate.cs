using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AchievmentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM health.account_achievement a
                                 USING health.account_achievement b
                                 WHERE a.id > b.id
                                 AND a.achievement_id = b.achievement_id
                                 AND a.account_health_setting_id = b.account_health_setting_id
                                 AND a.company_id = b.company_id;");

            migrationBuilder.DropForeignKey(
                name: "fk_account_health_setting_id__account_heath_setting",
                schema: "health",
                table: "account_achievement");

            migrationBuilder.DropForeignKey(
                name: "fk_achievement_id__achievement",
                schema: "health",
                table: "account_achievement");

            migrationBuilder.DropIndex(
                name: "account_achievement_account_health_setting_id_idx",
                schema: "health",
                table: "account_achievement");

            migrationBuilder.DropIndex(
                name: "account_achievement_achievement_id_idx",
                schema: "health",
                table: "account_achievement");

            migrationBuilder.AlterColumn<bool>(
                name: "is_achieved",
                schema: "health",
                table: "account_achievement",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "achievement_id",
                schema: "health",
                table: "account_achievement",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "account_health_setting_id",
                schema: "health",
                table: "account_achievement",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_account_achievement_account_health_setting_id_achievement_id",
                schema: "health",
                table: "account_achievement",
                columns: new[] { "account_health_setting_id", "achievement_id" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_account_achievement_account_health_setting_account_health_s~",
                schema: "health",
                table: "account_achievement",
                column: "account_health_setting_id",
                principalSchema: "health",
                principalTable: "account_health_setting",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_achievement_achievement_achievement_id",
                schema: "health",
                table: "account_achievement",
                column: "achievement_id",
                principalSchema: "health",
                principalTable: "achievement",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_achievement_account_health_setting_account_health_s~",
                schema: "health",
                table: "account_achievement");

            migrationBuilder.DropForeignKey(
                name: "fk_account_achievement_achievement_achievement_id",
                schema: "health",
                table: "account_achievement");

            migrationBuilder.DropIndex(
                name: "ix_account_achievement_account_health_setting_id_achievement_id",
                schema: "health",
                table: "account_achievement");

            migrationBuilder.AlterColumn<bool>(
                name: "is_achieved",
                schema: "health",
                table: "account_achievement",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "achievement_id",
                schema: "health",
                table: "account_achievement",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "account_health_setting_id",
                schema: "health",
                table: "account_achievement",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "account_achievement_account_health_setting_id_idx",
                schema: "health",
                table: "account_achievement",
                column: "account_health_setting_id");

            migrationBuilder.CreateIndex(
                name: "account_achievement_achievement_id_idx",
                schema: "health",
                table: "account_achievement",
                column: "achievement_id");

            migrationBuilder.AddForeignKey(
                name: "fk_account_health_setting_id__account_heath_setting",
                schema: "health",
                table: "account_achievement",
                column: "account_health_setting_id",
                principalSchema: "health",
                principalTable: "account_health_setting",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_achievement_id__achievement",
                schema: "health",
                table: "account_achievement",
                column: "achievement_id",
                principalSchema: "health",
                principalTable: "achievement",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
