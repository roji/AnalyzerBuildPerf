using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class FixNotificationRecepientFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_notification_recipient_account_user_company_user_id",
                schema: "admin",
                table: "notification_recipient");

            migrationBuilder.AddForeignKey(
                name: "fk_notification_recipient_company_user_company_user_id",
                schema: "admin",
                table: "notification_recipient",
                column: "company_user_id",
                principalSchema: "admin",
                principalTable: "company_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_notification_recipient_company_user_company_user_id",
                schema: "admin",
                table: "notification_recipient");

            migrationBuilder.AddForeignKey(
                name: "fk_notification_recipient_account_user_company_user_id",
                schema: "admin",
                table: "notification_recipient",
                column: "company_user_id",
                principalSchema: "admin",
                principalTable: "account_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
