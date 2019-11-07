using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddAccountIdandHealthscoreIdtoHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "account_id",
                schema: "health",
                table: "account_healthscore_history",
                nullable: true,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "healthscore_id",
                schema: "health",
                table: "account_healthscore_history",
                nullable: true,
                defaultValue: 0L);

            // give default values for new columns
            string updateSql = @"
                update health.account_healthscore_history set healthscore_id =
	                (select
                        healthscore_id
                     from health.account_healthscore ah where ah.id = health.account_healthscore_history.account_healthscore_id)";
            migrationBuilder.Sql(updateSql);

            updateSql = @"
                update health.account_healthscore_history set account_id =
                    (select
	                    account_id
                    from
	                    health.account_health_setting ahs inner join health.account_healthscore ah on ahs.id = ah.account_health_setting_id
                    where
	                    ah.id = health.account_healthscore_history.account_healthscore_id)";
            migrationBuilder.Sql(updateSql);

            // make required
            migrationBuilder.AlterColumn<long>(
                name: "account_id",
                schema: "health",
                table: "account_healthscore_history",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "healthscore_id",
                schema: "health",
                table: "account_healthscore_history",
                nullable: false,
                defaultValue: 0L);

            // idx
            migrationBuilder.CreateIndex(
                name: "ix_account_healthscore_history_account_id",
                schema: "health",
                table: "account_healthscore_history",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_healthscore_history_healthscore_id",
                schema: "health",
                table: "account_healthscore_history",
                column: "healthscore_id");

            migrationBuilder.AddForeignKey(
                name: "fk_account_healthscore_history_account_account_id",
                schema: "health",
                table: "account_healthscore_history",
                column: "account_id",
                principalSchema: "admin",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_healthscore_history_healthscore_healthscore_id",
                schema: "health",
                table: "account_healthscore_history",
                column: "healthscore_id",
                principalSchema: "health",
                principalTable: "healthscore",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_healthscore_history_account_account_id",
                schema: "health",
                table: "account_healthscore_history");

            migrationBuilder.DropForeignKey(
                name: "fk_account_healthscore_history_healthscore_healthscore_id",
                schema: "health",
                table: "account_healthscore_history");

            migrationBuilder.DropIndex(
                name: "ix_account_healthscore_history_account_id",
                schema: "health",
                table: "account_healthscore_history");

            migrationBuilder.DropIndex(
                name: "ix_account_healthscore_history_healthscore_id",
                schema: "health",
                table: "account_healthscore_history");

            migrationBuilder.DropColumn(
                name: "account_id",
                schema: "health",
                table: "account_healthscore_history");

            migrationBuilder.DropColumn(
                name: "healthscore_id",
                schema: "health",
                table: "account_healthscore_history");
        }
    }
}
