using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddSalesforeceIdUniqeIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_healthscore_id__healthscore",
                schema: "health",
                table: "account_healthscore_history");

            migrationBuilder.AddForeignKey(
                name: "fk_account_healthscore_history_account_healthscore_account_healthscore_id",
                schema: "health",
                table: "account_healthscore_history",
                column: "account_healthscore_id",
                principalSchema: "health",
                principalTable: "account_healthscore",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropIndex(
                name: "account_healthscore_history_account_healthscore_id_idx",
                schema: "health",
                table: "account_healthscore_history");

            migrationBuilder.DropIndex(
                name: "healthscore_company_id_idx",
                schema: "health",
                table: "healthscor");

            migrationBuilder.DropForeignKey(
                name: "fk_lifestage_id__lifestage",
                schema: "health",
                table: "achievement");

            migrationBuilder.DropForeignKey(
                name: "fk_lifecycle_id__lifecycle",
                schema: "health",
                table: "lifestage");

            migrationBuilder.DropIndex(
                name: "lifestage_lifecycle_id_idx",
                schema: "health",
                table: "lifestage");

            migrationBuilder.AddForeignKey(
                name: "fk_lifestage_lifecycle_lifecycle_id",
                schema: "health",
                table: "lifestage",
                column: "lifecycle_id",
                principalSchema: "health",
                principalTable: "lifecycle",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateIndex(
               name: "ix_lifecycle_lifecycle_id",
               schema: "health",
               table: "lifestage",
               column: "lifecycle_id");

            migrationBuilder.CreateIndex(
               name: "ix_account_achievement_achievement_id",
               schema: "health",
               table: "account_achievement",
               column: "achievement_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_healthscore_history_account_healthscore_id",
                schema: "health",
                table: "account_healthscore_history",
                column: "account_healthscore_id");

            //migrationBuilder.DropIndex(
            //    name: "ix_contract_company_id",
            //    schema: "engage",
            //    table: "contract");

            migrationBuilder.DropIndex(
                name: "ix_account_user_company_id",
                schema: "admin",
                table: "account_user");

            migrationBuilder.DropIndex(
                name: "ix_account_company_id",
                schema: "admin",
                table: "account");

            //migrationBuilder.CreateIndex(
            //    name: "ix_contract_company_id_salesforce_id",
            //    schema: "engage",
            //    table: "contract",
            //    columns: new[] { "company_id", "salesforce_id" },
            //    unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_account_user_company_id_salesforce_id",
                schema: "admin",
                table: "account_user",
                columns: new[] { "company_id", "salesforce_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_account_company_id_salesforce_id",
                schema: "admin",
                table: "account",
                columns: new[] { "company_id", "salesforce_id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(ix_contract_company_id_salesforce_id
            //    name: "ix_contract_company_id_salesforce_id",
            //    schema: "engage",
            //    table: "contract");

            migrationBuilder.DropIndex(
                name: "ix_account_user_company_id_salesforce_id",
                schema: "admin",
                table: "account_user");

            migrationBuilder.DropIndex(
                name: "ix_account_company_id_salesforce_id",
                schema: "admin",
                table: "account");

            //migrationBuilder.CreateIndex(
            //    name: "ix_contract_company_id",
            //    schema: "engage",
            //    table: "contract",
            //    column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_user_company_id",
                schema: "admin",
                table: "account_user",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_company_id",
                schema: "admin",
                table: "account",
                column: "company_id");

            migrationBuilder.DropIndex(
               name: "ix_account_healthscore_history_account_healthscore_id",
               schema: "health",
               table: "account_healthscore_history");
               
            migrationBuilder.CreateIndex(
                name: "account_healthscore_history_account_healthscore_id_idx",
                schema: "health",
                table: "account_healthscore_history",
                column: "account_healthscore_id");

            migrationBuilder.DropForeignKey(
               name: "fk_account_healthscore_history_account_healthscore_account_healthscore_id",
               schema: "health",
               table: "account_healthscore_history");

            migrationBuilder.AddForeignKey(
                name: "fk_account_healthscore_id__healthscore",
                schema: "health",
                table: "account_healthscore_history",
                column: "account_healthscore_id",
                principalSchema: "health",
                principalTable: "account_healthscore",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.DropIndex(
              name: "ix_account_achievement_achievement_id",
              schema: "health",
              table: "account_achievement");

           migrationBuilder.DropForeignKey(
                name: "fk_lifestage_lifecycle_lifecycle_id",
                schema: "health",
                table: "lifestage");

            migrationBuilder.DropIndex(
                name: "ix_lifecycle_lifecycle_id",
                schema: "health",
                table: "lifestage");

            migrationBuilder.AddForeignKey(
                name: "fk_lifecycle_id__lifecycle",
                schema: "health",
                table: "lifestage",
                column: "lifecycle_id",
                principalSchema: "health",
                principalTable: "lifecycle",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.CreateIndex(
               name: "lifestage_lifecycle_id_idx",
               schema: "health",
               table: "lifestage",
               column: "lifecycle_id");
        }
    }
}
