using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class FixMessageThreadTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_activity_message_message_id",
                schema: "engage",
                table: "activity");

            migrationBuilder.DropForeignKey(
                name: "fk_communication_thread_message_initial_message_id",
                schema: "engage",
                table: "communication_thread");

            migrationBuilder.DropIndex(
                name: "ix_communication_thread_initial_message_id",
                schema: "engage",
                table: "communication_thread");

            migrationBuilder.DropIndex(
                name: "ix_activity_message_id",
                schema: "engage",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "initial_message_id",
                schema: "engage",
                table: "communication_thread");

            migrationBuilder.DropColumn(
                name: "thread",
                schema: "engage",
                table: "communication_thread");

            migrationBuilder.DropColumn(
                name: "message_id",
                schema: "engage",
                table: "activity");

            migrationBuilder.AlterColumn<string[]>(
                name: "to",
                schema: "file",
                table: "message",
                nullable: true,
                oldClrType: typeof(string[]));

            migrationBuilder.AddColumn<long>(
                name: "activity_id",
                schema: "file",
                table: "message",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "thread_id",
                schema: "file",
                table: "message",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_message_activity_id",
                schema: "file",
                table: "message",
                column: "activity_id");

            migrationBuilder.CreateIndex(
                name: "ix_message_thread_id",
                schema: "file",
                table: "message",
                column: "thread_id");

            migrationBuilder.AddForeignKey(
                name: "fk_message_activity_activity_id",
                schema: "file",
                table: "message",
                column: "activity_id",
                principalSchema: "engage",
                principalTable: "activity",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_message_communication_thread_thread_id",
                schema: "file",
                table: "message",
                column: "thread_id",
                principalSchema: "engage",
                principalTable: "communication_thread",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_message_activity_activity_id",
                schema: "file",
                table: "message");

            migrationBuilder.DropForeignKey(
                name: "fk_message_communication_thread_thread_id",
                schema: "file",
                table: "message");

            migrationBuilder.DropIndex(
                name: "ix_message_activity_id",
                schema: "file",
                table: "message");

            migrationBuilder.DropIndex(
                name: "ix_message_thread_id",
                schema: "file",
                table: "message");

            migrationBuilder.DropColumn(
                name: "activity_id",
                schema: "file",
                table: "message");

            migrationBuilder.DropColumn(
                name: "thread_id",
                schema: "file",
                table: "message");

            migrationBuilder.AlterColumn<string[]>(
                name: "to",
                schema: "file",
                table: "message",
                nullable: false,
                oldClrType: typeof(string[]),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "initial_message_id",
                schema: "engage",
                table: "communication_thread",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long[]>(
                name: "thread",
                schema: "engage",
                table: "communication_thread",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "message_id",
                schema: "engage",
                table: "activity",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_communication_thread_initial_message_id",
                schema: "engage",
                table: "communication_thread",
                column: "initial_message_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_message_id",
                schema: "engage",
                table: "activity",
                column: "message_id");

            migrationBuilder.AddForeignKey(
                name: "fk_activity_message_message_id",
                schema: "engage",
                table: "activity",
                column: "message_id",
                principalSchema: "file",
                principalTable: "message",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_communication_thread_message_initial_message_id",
                schema: "engage",
                table: "communication_thread",
                column: "initial_message_id",
                principalSchema: "file",
                principalTable: "message",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
