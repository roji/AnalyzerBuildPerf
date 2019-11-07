using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bolstra.Migrations
{
    public partial class AddEmailTemplateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_custom_attribute_section_id__account_custom_attribut",
                schema: "admin",
                table: "account_custom_attribute");

            migrationBuilder.AlterColumn<long>(
                name: "account_custom_attribute_section_id",
                schema: "admin",
                table: "account_custom_attribute",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateTable(
                name: "email_template",
                schema: "engage",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_by = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    company_id = table.Column<long>(nullable: false),
                    title = table.Column<string>(maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("email_template_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_email_template_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_email_template_company_id",
                schema: "engage",
                table: "email_template",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_email_template_created_by",
                schema: "engage",
                table: "email_template",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_email_template_last_modified_by",
                schema: "engage",
                table: "email_template",
                column: "last_modified_by");

            migrationBuilder.AddForeignKey(
                name: "fk_account_custom_attribute_account_custom_attribute_section_a~",
                schema: "admin",
                table: "account_custom_attribute",
                column: "account_custom_attribute_section_id",
                principalSchema: "admin",
                principalTable: "account_custom_attribute_section",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_custom_attribute_account_custom_attribute_section_a~",
                schema: "admin",
                table: "account_custom_attribute");

            migrationBuilder.DropTable(
                name: "email_template",
                schema: "engage");

            migrationBuilder.AlterColumn<long>(
                name: "account_custom_attribute_section_id",
                schema: "admin",
                table: "account_custom_attribute",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_account_custom_attribute_section_id__account_custom_attribut",
                schema: "admin",
                table: "account_custom_attribute",
                column: "account_custom_attribute_section_id",
                principalSchema: "admin",
                principalTable: "account_custom_attribute_section",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
