using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddActivityIdFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "fk_activity_id__activity",
               schema: "engage",
               table: "time_entry");

            migrationBuilder.DropIndex(
               name: "time_entry_activity_id_idx",
               schema: "engage",
               table: "time_entry");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_id__activity",
                schema: "engage",
                table: "activity_label");

            migrationBuilder.DropForeignKey(
                name: "fk_label_id__label",
                schema: "engage",
                table: "activity_label");

            migrationBuilder.DropIndex(
                name: "activity_label_activity_id_idx",
                schema: "engage",
                table: "activity_label");

            migrationBuilder.DropIndex(
                name: "activity_label_company_id_idx",
                schema: "engage",
                table: "activity_label");

            migrationBuilder.CreateIndex(
                name: "ix_activity_label_label_id",
                schema: "engage",
                table: "activity_label",
                column: "label_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_label_activity_id",
                schema: "engage",
                table: "activity_label",
                column: "activity_id");

            migrationBuilder.AddForeignKey(
                name: "fk_activity_label_label_label_id",
                schema: "engage",
                table: "activity_label",
                column: "label_id",
                principalSchema: "engage",
                principalTable: "label",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_label_activity_activity_id",
                schema: "engage",
                table: "activity_label",
                column: "activity_id",
                principalSchema: "engage",
                principalTable: "activity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateIndex(
               name: "ix_time_entry_activity_id",
               schema: "engage",
               table: "time_entry",
               column: "activity_id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_entry_activity_activity_id",
                schema: "engage",
                table: "time_entry",
                column: "activity_id",
                principalSchema: "engage",
                principalTable: "activity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_activity_label_label_label_id",
                schema: "engage",
                table: "activity_label");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_label_activity_activity_id",
                schema: "engage",
                table: "activity_label");

            migrationBuilder.DropIndex(
                name: "ix_activity_label_label_id",
                schema: "engage",
                table: "activity_label");

            migrationBuilder.DropIndex(
                name: "ix_activity_label_activity_id",
                schema: "engage",
                table: "activity_label");

            migrationBuilder.DropForeignKey(
                name: "fk_time_entry_activity_activity_id",
                schema: "engage",
                table: "time_entry");

            migrationBuilder.DropIndex(
                name: "ix_time_entry_activity_id",
                schema: "engage",
                table: "time_entry");
        }
    }
}
