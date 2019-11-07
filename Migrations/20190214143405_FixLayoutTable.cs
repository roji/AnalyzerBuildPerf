using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class FixLayoutTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Update created_by, last_modified_by column to be not null
            string sql = @"UPDATE admin.layout set created_by = 1000000000 where created_by is null";

            migrationBuilder.Sql(sql);

            sql = @"UPDATE admin.layout set last_modified_by = 1000000000 where last_modified_by is null";

            migrationBuilder.Sql(sql);

            //Update created_by, last_modified_by column to be not null
            sql = @"UPDATE engage.layout set created_by = 1000000000 where created_by is null";

            migrationBuilder.Sql(sql);

            sql = @"UPDATE engage.layout set last_modified_by = 1000000000 where last_modified_by is null";

            migrationBuilder.Sql(sql);

            migrationBuilder.DropForeignKey(
                name: "fk_account_custom_attribute_account_custom_attribute_section_a~",
                table: "account_custom_attribute",
                schema: "admin"
                );

            migrationBuilder.DropForeignKey(
                name: "fk_account_user_custom_attribute_section_id__account_user_custo",
                table: "account_user_custom_attribute",
                schema: "admin"
                );

            migrationBuilder.DropForeignKey(
                name: "fk_activity_custom_attribute_section_id__activity_custom_attrib",
                table: "activity_custom_attribute",
                schema: "engage"
                );

            migrationBuilder.DropForeignKey(
                name: "fk_contract_custom_attribute_section_id__contract_custom_attrib",
                table: "contract_custom_attribute",
                schema: "engage"
                );

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "engage",
                table: "layout_section",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 225,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "admin",
                table: "layout_section",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 225,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "company_id",
                schema: "admin",
                table: "layout",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "created_by",
                schema: "admin",
                table: "layout",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "last_modified_by",
                schema: "admin",
                table: "layout",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "company_id",
                schema: "engage",
                table: "layout",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "created_by",
                schema: "engage",
                table: "layout",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "last_modified_by",
                schema: "engage",
                table: "layout",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "engage",
                table: "layout_section",
                maxLength: 225,
                nullable: true,
                oldClrType: typeof(string));


            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "admin",
                table: "layout_section",
                maxLength: 225,
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<long>(
                name: "company_id",
                schema: "engage",
                table: "layout",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: false);

            migrationBuilder.AlterColumn<long>(
                name: "created_by",
                schema: "admin",
                table: "layout",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: false);

            migrationBuilder.AlterColumn<long>(
                name: "last_modified_by",
                schema: "admin",
                table: "layout",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: false);

            migrationBuilder.AlterColumn<long>(
                name: "company_id",
                schema: "engage",
                table: "layout",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: false);

            migrationBuilder.AlterColumn<long>(
                name: "created_by",
                schema: "engage",
                table: "layout",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: false);

            migrationBuilder.AlterColumn<long>(
                name: "last_modified_by",
                schema: "engage",
                table: "layout",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: false);
        }
    }
}
