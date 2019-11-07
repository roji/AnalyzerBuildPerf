using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class RemoveCompanyIdFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "access_log_company_id_fkey",
                schema: "admin",
                table: "access_log");

            migrationBuilder.DropForeignKey(
                name: "fk_access_log_company_company_id",
                schema: "admin",
                table: "access_log");

            migrationBuilder.DropForeignKey(
                name: "account_company_id_fkey",
                schema: "admin",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "account_population_company_id_fkey",
                schema: "admin",
                table: "account_population");

            migrationBuilder.DropForeignKey(
                name: "account_user_company_id_fkey",
                schema: "admin",
                table: "account_user");

            migrationBuilder.DropForeignKey(
                name: "company_db_config_company_id_fkey",
                schema: "admin",
                table: "company_db_config");

      
            migrationBuilder.DropForeignKey(
                name: "company_user_company_id_fkey",
                schema: "admin",
                table: "company_user");


            migrationBuilder.DropForeignKey(
                name: "fk_filter_company_company_id",
                schema: "admin",
                table: "filter");

            migrationBuilder.DropForeignKey(
               name: "licensed_modules_company_id_fkey",
               schema: "admin",
               table: "licensed_modules");

            migrationBuilder.DropForeignKey(
                name: "fk_notification_company_company_id",
                schema: "admin",
                table: "notification");

            migrationBuilder.DropForeignKey(
                name: "fk_notification_recipient_company_company_id",
                schema: "admin",
                table: "notification_recipient");


            migrationBuilder.DropIndex(
                name: "ix_notification_recipient_company_id",
                schema: "admin",
                table: "notification_recipient");

            migrationBuilder.DropIndex(
                name: "ix_notification_company_id",
                schema: "admin",
                table: "notification");

            migrationBuilder.DropIndex(
                name: "ix_filter_company_id",
                schema: "admin",
                table: "filter");

            migrationBuilder.DropIndex(
                name: "ix_company_key_company_id",
                schema: "admin",
                table: "company_key");

            migrationBuilder.DropIndex(
                name: "ix_company_db_config_company_id",
                schema: "admin",
                table: "company_db_config");

            migrationBuilder.DropIndex(
                name: "ix_account_user_company_id",
                schema: "admin",
                table: "account_user");

            migrationBuilder.DropIndex(
                name: "ix_account_population_company_id",
                schema: "admin",
                table: "account_population");

            migrationBuilder.DropIndex(
                name: "ix_account_filter_company_id",
                schema: "admin",
                table: "account_filter");

            migrationBuilder.DropIndex(
                name: "ix_account_company_id",
                schema: "admin",
                table: "account");

            migrationBuilder.DropIndex(
                name: "ix_access_log_company_id",
                schema: "admin",
                table: "access_log");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_notification_recipient_company_id",
                schema: "admin",
                table: "notification_recipient",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_notification_company_id",
                schema: "admin",
                table: "notification",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_filter_company_id",
                schema: "admin",
                table: "filter",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_company_key_company_id",
                schema: "admin",
                table: "company_key",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_company_db_config_company_id",
                schema: "admin",
                table: "company_db_config",
                column: "company_id");


            migrationBuilder.CreateIndex(
                name: "ix_account_user_company_id",
                schema: "admin",
                table: "account_user",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_population_company_id",
                schema: "admin",
                table: "account_population",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_filter_company_id",
                schema: "admin",
                table: "account_filter",
                column: "company_id");


            migrationBuilder.CreateIndex(
                name: "ix_account_company_id",
                schema: "admin",
                table: "account",
                column: "company_id");

            migrationBuilder.CreateIndex(
               name: "ix_access_log_company_id",
               schema: "admin",
               table: "access_log",
               column: "company_id");

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
              name: "account_company_id_fkey",
              schema: "admin",
              table: "account",
              column: "company_id",
              principalSchema: "admin",
              principalTable: "company",
              principalColumn: "id",
              onDelete: ReferentialAction.Cascade);

               
            migrationBuilder.AddForeignKey(
                name: "account_population_company_id_fkey",
                schema: "admin",
                table: "account_population",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "account_user_company_id_fkey",
                schema: "admin",
                table: "account_user",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "company_db_config_company_id_fkey",
                schema: "admin",
                table: "company_db_config",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);


            migrationBuilder.AddForeignKey(
                name: "company_user_company_id_fkey",
                schema: "admin",
                table: "company_user",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);


            migrationBuilder.AddForeignKey(
                name: "fk_filter_company_company_id",
                schema: "admin",
                table: "filter",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

      
            migrationBuilder.AddForeignKey(
                name: "licensed_modules_company_id_fkey",
                schema: "admin",
                table: "licensed_modules",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_notification_company_company_id",
                schema: "admin",
                table: "notification",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_notification_recipient_company_company_id",
                schema: "admin",
                table: "notification_recipient",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
