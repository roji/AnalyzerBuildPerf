using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddParentAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "parent_id",
                schema: "admin",
                table: "account",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_account_parent_id",
                schema: "admin",
                table: "account",
                column: "parent_id");

            migrationBuilder.AddForeignKey(
                name: "fk_account_account_parent_id",
                schema: "admin",
                table: "account",
                column: "parent_id",
                principalSchema: "admin",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_account_parent_id",
                schema: "admin",
                table: "account");

            migrationBuilder.DropIndex(
                name: "ix_account_parent_id",
                schema: "admin",
                table: "account");

            migrationBuilder.DropColumn(
                name: "parent_id",
                schema: "admin",
                table: "account");
        }
    }
}
