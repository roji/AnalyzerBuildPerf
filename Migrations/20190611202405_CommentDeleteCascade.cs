using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class CommentDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comment_id__comment",
                schema: "file",
                table: "comment_reference");

            migrationBuilder.AddForeignKey(
                name: "fk_comment_id__comment",
                schema: "file",
                table: "comment_reference",
                column: "comment_id",
                principalSchema: "file",
                principalTable: "comment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comment_id__comment",
                schema: "file",
                table: "comment_reference");

            migrationBuilder.AddForeignKey(
                name: "fk_comment_id__comment",
                schema: "file",
                table: "comment_reference",
                column: "comment_id",
                principalSchema: "file",
                principalTable: "comment",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
