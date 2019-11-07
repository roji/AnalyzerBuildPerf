using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddUserIdForeignKeyOnCompanyUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_company_user_user_id",
                schema: "admin",
                table: "company_user",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_company_user_user_user_id",
                schema: "admin",
                table: "company_user",
                column: "user_id",
                principalSchema: "admin",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_company_user_user_user_id",
                schema: "admin",
                table: "company_user");

            migrationBuilder.DropIndex(
                name: "ix_company_user_user_id",
                schema: "admin",
                table: "company_user");
        }
    }
}
