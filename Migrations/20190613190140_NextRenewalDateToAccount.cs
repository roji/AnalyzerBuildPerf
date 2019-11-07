using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class NextRenewalDateToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "comment_reference_comment_id_idx",
                schema: "file",
                table: "comment_reference");
                
            migrationBuilder.DropForeignKey(
                name: "fk_referencei_type_id__reference_type",
                schema: "file",
                table: "comment_reference");

            migrationBuilder.AlterColumn<long>(
                name: "reference_type_id",
                schema: "file",
                table: "comment_reference",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "reference_id",
                schema: "file",
                table: "comment_reference",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "comment_id",
                schema: "file",
                table: "comment_reference",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "next_renewal_date",
                schema: "admin",
                table: "account",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "comment_reference_comment_id_idx",
                schema: "file",
                table: "comment_reference",
                column: "comment_id");

            migrationBuilder.AddForeignKey(
                name: "fk_comment_reference_comment_comment_id",
                schema: "file",
                table: "comment_reference",
                column: "comment_id",
                principalSchema: "file",
                principalTable: "comment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_comment_reference_reference_type_reference_type_id",
                schema: "file",
                table: "comment_reference",
                column: "reference_type_id",
                principalSchema: "file",
                principalTable: "reference_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comment_reference_comment_comment_id",
                schema: "file",
                table: "comment_reference");

            migrationBuilder.DropForeignKey(
                name: "fk_comment_reference_reference_type_reference_type_id",
                schema: "file",
                table: "comment_reference");

            migrationBuilder.DropIndex(
                name: "ix_comment_reference_comment_id",
                schema: "file",
                table: "comment_reference");

            migrationBuilder.DropColumn(
                name: "next_renewal_date",
                schema: "admin",
                table: "account");

            migrationBuilder.AlterColumn<long>(
                name: "reference_type_id",
                schema: "file",
                table: "comment_reference",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "reference_id",
                schema: "file",
                table: "comment_reference",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "comment_id",
                schema: "file",
                table: "comment_reference",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "fk_referencei_type_id__reference_type",
                schema: "file",
                table: "comment_reference",
                column: "reference_type_id",
                principalSchema: "file",
                principalTable: "reference_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.CreateIndex(
                name: "comment_reference_comment_id_id",
                schema: "file",
                table: "comment_reference",
                column: "comment_id");

        }
    }
}
