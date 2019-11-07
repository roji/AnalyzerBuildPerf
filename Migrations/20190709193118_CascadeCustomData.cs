using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class CascadeCustomData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_id__account",
                schema: "admin",
                table: "account_custom_data");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_id__activity",
                schema: "engage",
                table: "activity_custom_data");

            migrationBuilder.DropForeignKey(
                name: "fk_contract_id__contract",
                schema: "engage",
                table: "contract_custom_data");



            migrationBuilder.AddForeignKey(
                name: "fk_account_custom_data_account_account_id",
                schema: "admin",
                table: "account_custom_data",
                column: "account_id",
                principalSchema: "admin",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_custom_data_activity_activity_id",
                schema: "engage",
                table: "activity_custom_data",
                column: "activity_id",
                principalSchema: "engage",
                principalTable: "activity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_contract_custom_data_contract_contract_id",
                schema: "engage",
                table: "contract_custom_data",
                column: "contract_id",
                principalSchema: "engage",
                principalTable: "contract",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);



            migrationBuilder.CreateIndex(
                name: "ix_account_custom_data_account_id",
                schema: "admin",
                table: "account_custom_data",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_custom_data_activity_id",
                schema: "engage",
                table: "activity_custom_data",
                column: "activity_id");

            migrationBuilder.CreateIndex(
                name: "ix_contract_custom_data_contract_id",
                schema: "engage",
                table: "contract_custom_data",
                column: "contract_id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "ix_account_custom_data_account_id",
                schema: "admin",
                table: "account_custom_data");

            migrationBuilder.DropIndex(
                name: "ix_activity_custom_data_activity_id",
                schema: "engage",
                table: "activity_custom_data");

            migrationBuilder.DropIndex(
                name: "ix_contract_custom_data_contract_id",
                schema: "engage",
                table: "contract_custom_data");



            migrationBuilder.DropForeignKey(
                name: "fk_account_custom_data_account_account_id",
                schema: "admin",
                table: "account_custom_data");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_custom_data_activity_activity_id",
                schema: "engage",
                table: "activity_custom_data");

            migrationBuilder.DropForeignKey(
                name: "fk_contract_custom_data_contract_contract_id",
                schema: "engage",
                table: "contract_custom_data");



            migrationBuilder.AddForeignKey(
                name: "fk_account_id__account",
                schema: "admin",
                table: "account_custom_data",
                column: "account_id",
                principalSchema: "admin",
                principalTable: "account",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_activity_id__activity",
                schema: "engage",
                table: "activity_custom_data",
                column: "activity_id",
                principalSchema: "engage",
                principalTable: "activity",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_contract_id__contract",
                schema: "engage",
                table: "contract_custom_data",
                column: "contract_id",
                principalSchema: "engage",
                principalTable: "contract",
                principalColumn: "id");
        }
    }
}
