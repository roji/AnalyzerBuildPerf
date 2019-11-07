using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bolstra.Migrations
{
    public partial class RenameEmailTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "email_template",
                schema: "file");

            migrationBuilder.CreateTable(
                name: "message_template",
                schema: "file",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_by = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    company_id = table.Column<long>(nullable: false),
                    title = table.Column<string>(maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("message_template_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_message_template_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_message_template_company_id",
                schema: "file",
                table: "message_template",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_message_template_created_by",
                schema: "file",
                table: "message_template",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_message_template_last_modified_by",
                schema: "file",
                table: "message_template",
                column: "last_modified_by");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "message_template",
                schema: "file");

            migrationBuilder.CreateTable(
                name: "email_template",
                schema: "file",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    company_id = table.Column<long>(nullable: false),
                    content = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<long>(nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(nullable: true, defaultValue: true),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    title = table.Column<string>(maxLength: 255, nullable: false)
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
                schema: "file",
                table: "email_template",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_email_template_created_by",
                schema: "file",
                table: "email_template",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_email_template_last_modified_by",
                schema: "file",
                table: "email_template",
                column: "last_modified_by");
        }
    }
}
