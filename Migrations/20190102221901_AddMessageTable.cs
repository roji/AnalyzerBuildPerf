using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bolstra.Migrations
{
    public partial class AddMessageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "communication_thread_id",
                schema: "engage",
                table: "activity",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "message_id",
                schema: "engage",
                table: "activity",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "email_template",
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
                    table.PrimaryKey("email_template_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_email_template_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "message",
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
                    subject = table.Column<string>(maxLength: 255, nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    from = table.Column<string>(nullable: false),
                    to = table.Column<string[]>(nullable: false),
                    cc = table.Column<string[]>(nullable: true),
                    bcc = table.Column<string[]>(nullable: true),
                    status = table.Column<string>(maxLength: 20, nullable: true),
                    type = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("message_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_message_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "communication_thread",
                schema: "engage",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_by = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    company_id = table.Column<long>(nullable: false),
                    engagement_id = table.Column<long>(nullable: false),
                    initial_message_id = table.Column<long>(nullable: false),
                    thread = table.Column<long[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("communication_thread_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_communication_thread_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_communication_thread_engagement_engagement_id",
                        column: x => x.engagement_id,
                        principalSchema: "engage",
                        principalTable: "engagement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_communication_thread_message_initial_message_id",
                        column: x => x.initial_message_id,
                        principalSchema: "file",
                        principalTable: "message",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_activity_communication_thread_id",
                schema: "engage",
                table: "activity",
                column: "communication_thread_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_message_id",
                schema: "engage",
                table: "activity",
                column: "message_id");

            migrationBuilder.CreateIndex(
                name: "ix_communication_thread_company_id",
                schema: "engage",
                table: "communication_thread",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_communication_thread_created_by",
                schema: "engage",
                table: "communication_thread",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_communication_thread_engagement_id",
                schema: "engage",
                table: "communication_thread",
                column: "engagement_id");

            migrationBuilder.CreateIndex(
                name: "ix_communication_thread_initial_message_id",
                schema: "engage",
                table: "communication_thread",
                column: "initial_message_id");

            migrationBuilder.CreateIndex(
                name: "ix_communication_thread_last_modified_by",
                schema: "engage",
                table: "communication_thread",
                column: "last_modified_by");

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

            migrationBuilder.CreateIndex(
                name: "ix_message_company_id",
                schema: "file",
                table: "message",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_message_created_by",
                schema: "file",
                table: "message",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_message_last_modified_by",
                schema: "file",
                table: "message",
                column: "last_modified_by");

            migrationBuilder.AddForeignKey(
                name: "fk_activity_communication_thread_communication_thread_id",
                schema: "engage",
                table: "activity",
                column: "communication_thread_id",
                principalSchema: "engage",
                principalTable: "communication_thread",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_message_message_id",
                schema: "engage",
                table: "activity",
                column: "message_id",
                principalSchema: "file",
                principalTable: "message",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_activity_communication_thread_communication_thread_id",
                schema: "engage",
                table: "activity");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_message_message_id",
                schema: "engage",
                table: "activity");

            migrationBuilder.DropTable(
                name: "communication_thread",
                schema: "engage");

            migrationBuilder.DropTable(
                name: "email_template",
                schema: "file");

            migrationBuilder.DropTable(
                name: "message",
                schema: "file");

            migrationBuilder.DropIndex(
                name: "ix_activity_communication_thread_id",
                schema: "engage",
                table: "activity");

            migrationBuilder.DropIndex(
                name: "ix_activity_message_id",
                schema: "engage",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "communication_thread_id",
                schema: "engage",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "message_id",
                schema: "engage",
                table: "activity");
        }
    }
}
