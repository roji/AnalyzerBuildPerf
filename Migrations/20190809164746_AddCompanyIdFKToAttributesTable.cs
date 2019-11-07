using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddCompanyIdFKToAttributesTable : Migration
    {
        private void CleanUpData(MigrationBuilder migrationBuilder)
        {
            var tables = new string[] {
                    "admin.account_custom_attribute",
                    "admin.account_user_custom_attribute",
                    "engage.activity_custom_attribute",
                    "engage.contract_custom_attribute"
            };

            foreach (var table in tables)
            {
                string sql = $"DELETE FROM {table} a WHERE NOT EXISTS (SELECT id FROM admin.company WHERE id = a.company_id)";
                migrationBuilder.Sql(sql);
            }
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            CleanUpData(migrationBuilder);

            migrationBuilder.CreateIndex(
                name: "ix_account_custom_attribute_company_id",
                schema: "admin",
                table: "account_custom_attribute",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_user_custom_attribute_company_id",
                schema: "admin",
                table: "account_user_custom_attribute",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_custom_attribute_company_id",
                schema: "engage",
                table: "activity_custom_attribute",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_contract_custom_attribute_company_id",
                schema: "engage",
                table: "contract_custom_attribute",
                column: "company_id");

            migrationBuilder.AddForeignKey(
                name: "fk_account_custom_attribute_company_company_id",
                schema: "admin",
                table: "account_custom_attribute",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
               name: "fk_account_user_custom_attribute_company_company_id",
               schema: "admin",
               table: "account_user_custom_attribute",
               column: "company_id",
               principalSchema: "admin",
               principalTable: "company",
               principalColumn: "id",
               onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
               name: "fk_activity_custom_attribute_company_company_id",
               schema: "engage",
               table: "activity_custom_attribute",
               column: "company_id",
               principalSchema: "admin",
               principalTable: "company",
               principalColumn: "id",
               onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
               name: "fk_contract_custom_attribute_company_company_id",
               schema: "engage",
               table: "contract_custom_attribute",
               column: "company_id",
               principalSchema: "admin",
               principalTable: "company",
               principalColumn: "id",
               onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "fk_contract_custom_attribute_company_company_id",
               schema: "engage",
               table: "contract_custom_attribute");

            migrationBuilder.DropForeignKey(
               name: "fk_activity_custom_attribute_company_company_id",
               schema: "engage",
               table: "activity_custom_attribute");

            migrationBuilder.DropForeignKey(
               name: "fk_account_user_custom_attribute_company_company_id",
               schema: "admin",
               table: "account_user_custom_attribute");

            migrationBuilder.DropForeignKey(
               name: "fk_account_custom_attribute_company_company_id",
               schema: "admin",
               table: "account_custom_attribute");

            migrationBuilder.DropIndex(
                name: "ix_contract_custom_attribute_company_id",
                schema: "engage",
                table: "contract_custom_attribute");

            migrationBuilder.DropIndex(
                name: "ix_activity_custom_attribute_company_id",
                schema: "engage",
                table: "activity_custom_attribute");

            migrationBuilder.DropIndex(
                name: "ix_account_user_custom_attribute_company_id",
                schema: "admin",
                table: "account_user_custom_attribute");

            migrationBuilder.DropIndex(
                name: "ix_account_custom_attribute_company_id",
                schema: "admin",
                table: "account_custom_attribute");
        }
    }
}
