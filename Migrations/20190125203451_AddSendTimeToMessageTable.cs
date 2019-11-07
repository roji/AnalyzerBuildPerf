using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddSendTimeToMessageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "send_time",
                schema: "file",
                table: "message",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "external_thread_id",
                schema: "engage",
                table: "communication_thread",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_communication_thread_external_thread_id",
                schema: "engage",
                table: "communication_thread",
                column: "external_thread_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_communication_thread_external_thread_id",
                schema: "engage",
                table: "communication_thread");

            migrationBuilder.DropColumn(
                name: "send_time",
                schema: "file",
                table: "message");

            migrationBuilder.DropColumn(
                name: "external_thread_id",
                schema: "engage",
                table: "communication_thread");
        }
    }
}
