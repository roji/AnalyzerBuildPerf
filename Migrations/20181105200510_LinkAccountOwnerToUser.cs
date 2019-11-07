using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class LinkAccountOwnerToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_company_user_account_owner_id",
                schema: "admin",
                table: "account");

            migrationBuilder.AddForeignKey(
                name: "fk_account_user_account_owner_id",
                schema: "admin",
                table: "account",
                column: "account_owner_id",
                principalSchema: "admin",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_user_account_owner_id",
                schema: "admin",
                table: "account");

            migrationBuilder.AddForeignKey(
                name: "fk_account_company_user_account_owner_id",
                schema: "admin",
                table: "account",
                column: "account_owner_id",
                principalSchema: "admin",
                principalTable: "company_user",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
