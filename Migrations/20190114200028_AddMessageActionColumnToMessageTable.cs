using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddMessageActionColumnToMessageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_communication_thread_engagement_engagement_id",
                schema: "engage",
                table: "communication_thread");

            migrationBuilder.AddColumn<string>(
                name: "action",
                schema: "file",
                table: "message",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "engagement_id",
                schema: "engage",
                table: "communication_thread",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "ix_activity_engagement_id",
                schema: "engage",
                table: "activity",
                column: "engagement_id");

            migrationBuilder.AddForeignKey(
                name: "fk_activity_engagement_engagement_id",
                schema: "engage",
                table: "activity",
                column: "engagement_id",
                principalSchema: "engage",
                principalTable: "engagement",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_communication_thread_engagement_engagement_id",
                schema: "engage",
                table: "communication_thread",
                column: "engagement_id",
                principalSchema: "engage",
                principalTable: "engagement",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_activity_engagement_engagement_id",
                schema: "engage",
                table: "activity");

            migrationBuilder.DropForeignKey(
                name: "fk_communication_thread_engagement_engagement_id",
                schema: "engage",
                table: "communication_thread");

            migrationBuilder.DropIndex(
                name: "ix_activity_engagement_id",
                schema: "engage",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "action",
                schema: "file",
                table: "message");

            migrationBuilder.AlterColumn<long>(
                name: "engagement_id",
                schema: "engage",
                table: "communication_thread",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_communication_thread_engagement_engagement_id",
                schema: "engage",
                table: "communication_thread",
                column: "engagement_id",
                principalSchema: "engage",
                principalTable: "engagement",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
