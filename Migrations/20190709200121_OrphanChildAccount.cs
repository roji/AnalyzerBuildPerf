using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class OrphanChildAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "account_id",
                schema: "admin",
                table: "account_custom_data",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.DropForeignKey(
                name: "fk_account_account_parent_id",
                schema: "admin",
                table: "account");

            migrationBuilder.AddForeignKey(
                name: "fk_account_account_parent_id",
                schema: "admin",
                table: "account",
                column: "parent_id",
                principalSchema: "admin",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "account_id",
                schema: "admin",
                table: "account_custom_data",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.DropForeignKey(
                name: "fk_account_account_parent_id",
                schema: "admin",
                table: "account");

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
    }
}
