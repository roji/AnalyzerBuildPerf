using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class FixAccountUserCustomDataFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_user_id__account_user",
                schema: "admin",
                table: "account_user_custom_data");

            migrationBuilder.CreateIndex(
                name: "ix_account_user_custom_data_account_user_id",
                schema: "admin",
                table: "account_user_custom_data",
                column: "account_user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_account_user_custom_data_account_user_account_user_id",
                schema: "admin",
                table: "account_user_custom_data",
                column: "account_user_id",
                principalSchema: "admin",
                principalTable: "account_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropIndex(
                name: "ix_account_user_account_id",
                schema: "admin",
                table: "account_user");

            migrationBuilder.DropIndex(
                name: "ix_account_user_email",
                schema: "admin",
                table: "account_user");

            migrationBuilder.CreateIndex(
                name: "ix_account_user_account_id_email",
                schema: "admin",
                table: "account_user",
                columns: new[] { "account_id", "email" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_account_user_account_id_email",
                schema: "admin",
                table: "account_user");

            migrationBuilder.CreateIndex(
                name: "ix_account_user_account_id",
                schema: "admin",
                table: "account_user",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_user_email",
                schema: "admin",
                table: "account_user",
                column: "email");

            migrationBuilder.DropForeignKey(
                name: "fk_account_user_custom_data_account_user_account_user_id",
                schema: "admin",
                table: "account_user_custom_data");

            migrationBuilder.DropIndex(
                name: "ix_account_user_custom_data_account_user_id",
                schema: "admin",
                table: "account_user_custom_data");

            migrationBuilder.AddForeignKey(
                name: "fk_account_user_id__account_user",
                schema: "admin",
                table: "account_user_custom_data",
                column: "account_user_id",
                principalSchema: "admin",
                principalTable: "account_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
