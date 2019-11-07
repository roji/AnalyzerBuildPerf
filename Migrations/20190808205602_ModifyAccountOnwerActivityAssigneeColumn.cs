using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class ModifyAccountOnwerActivityAssigneeColumn : Migration
    {
        private void CleanUpData(MigrationBuilder migrationBuilder)
        {
            var tables = new string[] {
                    "admin.access_log",
                    "engage.activity_assignment"
            };

            foreach (var table in tables)
            {
                string sql = $"DELETE FROM {table} a WHERE NOT EXISTS (SELECT id FROM admin.company_user WHERE id = a.user_id)";
                migrationBuilder.Sql(sql);
            }
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            CleanUpData(migrationBuilder);

            migrationBuilder.DropForeignKey(
                name: "fk_access_log_company_company_id",
                schema: "admin",
                table: "access_log");

            migrationBuilder.DropForeignKey(
                name: "account_account_owner_id_fkey",
                schema: "admin",
                table: "account");

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                schema: "admin",
                table: "access_log",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "company_id",
                schema: "admin",
                table: "access_log",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.DropIndex(
               name: "activity_assignment_user_id_idx",
               schema: "engage",
               table: "activity_assignment");

            migrationBuilder.CreateIndex(
                name: "ix_activity_assignment_user_id",
                schema: "engage",
                table: "activity_assignment",
                column: "user_id");

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
                name: "fk_access_log_company_user_user_id",
                schema: "admin",
                table: "access_log",
                column: "user_id",
                principalSchema: "admin",
                principalTable: "company_user",
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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_assignment_company_user_user_id",
                schema: "engage",
                table: "activity_assignment",
                column: "user_id",
                principalSchema: "admin",
                principalTable: "company_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_access_log_company_company_id",
                schema: "admin",
                table: "access_log");

            migrationBuilder.DropForeignKey(
                name: "fk_access_log_company_user_user_id",
                schema: "admin",
                table: "access_log");

            migrationBuilder.DropForeignKey(
                name: "fk_account_company_user_account_owner_id",
                schema: "admin",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_assignment_company_user_user_id",
                schema: "engage",
                table: "activity_assignment");

            migrationBuilder.DropIndex(
                name: "ix_activity_assignment_user_id",
                schema: "engage",
                table: "activity_assignment");

            migrationBuilder.CreateIndex(
               name: "activity_assignment_user_id_idx",
               schema: "engage",
               table: "activity_assignment",
               column: "user_id");

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
                name: "account_account_owner_id_fkey",
                schema: "admin",
                table: "account",
                column: "account_owner_id",
                principalSchema: "admin",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
