using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class FixCompanySettingTableHealthScoreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<double>(
                name: "weight",
                schema: "health",
                table: "healthscore_component",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "parent_healthscore_id",
                schema: "health",
                table: "healthscore_component",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "healthscore_id",
                schema: "health",
                table: "healthscore_component",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "range_low",
                schema: "health",
                table: "healthscore",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "range_high",
                schema: "health",
                table: "healthscore",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "range_good",
                schema: "health",
                table: "healthscore",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "range_bad",
                schema: "health",
                table: "healthscore",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "value",
                schema: "health",
                table: "account_healthscore_history",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "for_date",
                schema: "health",
                table: "account_healthscore_history",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "engage",
                table: "layout_section",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "admin",
                table: "layout_section",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "ix_company_setting_id",
                schema: "engage",
                table: "company_setting",
                column: "company_id",
                unique: true);

            migrationBuilder.CreateIndex(
               name: "ix_modules_name",
               schema: "admin",
               table: "modules",
               column: "name",
               unique: true);
               
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<double>(
                name: "weight",
                schema: "health",
                table: "healthscore_component",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<long>(
                name: "parent_healthscore_id",
                schema: "health",
                table: "healthscore_component",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "healthscore_id",
                schema: "health",
                table: "healthscore_component",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<double>(
                name: "range_low",
                schema: "health",
                table: "healthscore",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "range_high",
                schema: "health",
                table: "healthscore",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "range_good",
                schema: "health",
                table: "healthscore",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "range_bad",
                schema: "health",
                table: "healthscore",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "value",
                schema: "health",
                table: "account_healthscore_history",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<DateTime>(
                name: "for_date",
                schema: "health",
                table: "account_healthscore_history",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "engage",
                table: "layout_section",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 225);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "admin",
                table: "layout_section",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 225);

            migrationBuilder.DropIndex(
                name: "ix_company_setting_id",
                schema: "engage",
                table: "company_setting");

            migrationBuilder.DropIndex(
              name: "ix_modules_name",
              schema: "admin",
              table: "modules");

        }
    }
}
