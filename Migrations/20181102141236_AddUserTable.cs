using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bolstra.Migrations
{
    public partial class AddUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "lifecycle_start_at",
                schema: "health",
                table: "account_health_setting",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<long>(
                name: "lifecycle_id",
                schema: "health",
                table: "account_health_setting",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "default_healthscore_id",
                schema: "health",
                table: "account_health_setting",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateTable(
                name: "user",
                schema: "admin",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_by = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    first_name = table.Column<string>(maxLength: 50, nullable: false),
                    last_name = table.Column<string>(maxLength: 50, nullable: false),
                    color = table.Column<string>(maxLength: 7, nullable: true),
                    is_saas_admin = table.Column<bool>(nullable: true, defaultValue: false),
                    is_service_user = table.Column<bool>(nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pkey", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_analytic_source_category_id",
                schema: "triggers",
                table: "analytic_source",
                column: "category_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_achievement_lifestage_id",
                schema: "health",
                table: "achievement",
                column: "lifestage_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_health_setting_default_healthscore_id",
                schema: "health",
                table: "account_health_setting",
                column: "default_healthscore_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_health_setting_lifecycle_id",
                schema: "health",
                table: "account_health_setting",
                column: "lifecycle_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_account_owner_id",
                schema: "admin",
                table: "account",
                column: "account_owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_created_by",
                schema: "admin",
                table: "user",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_user_email",
                schema: "admin",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_last_modified_by",
                schema: "admin",
                table: "user",
                column: "last_modified_by");

            migrationBuilder.AddForeignKey(
                name: "fk_access_log_company_company_id",
                schema: "admin",
                table: "access_log",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_company_user_account_owner_id",
                schema: "admin",
                table: "account",
                column: "account_owner_id",
                principalSchema: "admin",
                principalTable: "company_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_health_setting_healthscore_default_healthscore_id",
                schema: "health",
                table: "account_health_setting",
                column: "default_healthscore_id",
                principalSchema: "health",
                principalTable: "healthscore",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_account_health_setting_lifecycle_lifecycle_id",
                schema: "health",
                table: "account_health_setting",
                column: "lifecycle_id",
                principalSchema: "health",
                principalTable: "lifecycle",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_achievement_lifestage_lifestage_id",
                schema: "health",
                table: "achievement",
                column: "lifestage_id",
                principalSchema: "health",
                principalTable: "lifestage",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            MigrateCompanyUserToUserTable(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_access_log_company_company_id",
                schema: "admin",
                table: "access_log");

            migrationBuilder.DropForeignKey(
                name: "fk_account_company_user_account_owner_id",
                schema: "admin",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "fk_account_health_setting_healthscore_default_healthscore_id",
                schema: "health",
                table: "account_health_setting");

            migrationBuilder.DropForeignKey(
                name: "fk_account_health_setting_lifecycle_lifecycle_id",
                schema: "health",
                table: "account_health_setting");

            migrationBuilder.DropForeignKey(
                name: "fk_achievement_lifestage_lifestage_id",
                schema: "health",
                table: "achievement");

            migrationBuilder.DropTable(
                name: "user",
                schema: "admin");

            migrationBuilder.DropIndex(
                name: "ix_analytic_source_category_id",
                schema: "triggers",
                table: "analytic_source");

            migrationBuilder.DropIndex(
                name: "ix_achievement_lifestage_id",
                schema: "health",
                table: "achievement");

            migrationBuilder.DropIndex(
                name: "ix_account_health_setting_default_healthscore_id",
                schema: "health",
                table: "account_health_setting");

            migrationBuilder.DropIndex(
                name: "ix_account_health_setting_lifecycle_id",
                schema: "health",
                table: "account_health_setting");

            migrationBuilder.DropIndex(
                name: "ix_account_account_owner_id",
                schema: "admin",
                table: "account");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "lifecycle_start_at",
                schema: "health",
                table: "account_health_setting",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "lifecycle_id",
                schema: "health",
                table: "account_health_setting",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "default_healthscore_id",
                schema: "health",
                table: "account_health_setting",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
