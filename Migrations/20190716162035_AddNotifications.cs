using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bolstra.Migrations
{
    public partial class AddNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notification",
                schema: "admin",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_by = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    company_id = table.Column<long>(nullable: false),
                    account_id = table.Column<long>(nullable: true),
                    title = table.Column<string>(maxLength: 100, nullable: false),
                    type = table.Column<string>(maxLength: 30, nullable: false),
                    message = table.Column<string>(nullable: true),
                    expiration = table.Column<DateTime>(type: "date", nullable: true),
                    all_users = table.Column<bool>(nullable: false, defaultValue: false),
                    additional_data = table.Column<string>(type: "jsonb", nullable: true, defaultValue: "{}")
                },
                constraints: table =>
                {
                    table.PrimaryKey("notification_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_notification_account_account_id",
                        column: x => x.account_id,
                        principalSchema: "admin",
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notification_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notification_recipient",
                schema: "admin",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_by = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    company_id = table.Column<long>(nullable: false),
                    notification_id = table.Column<long>(nullable: false),
                    company_user_id = table.Column<long>(nullable: false),
                    read = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("notification_recipient_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_notification_recipient_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notification_recipient_account_user_company_user_id",
                        column: x => x.company_user_id,
                        principalSchema: "admin",
                        principalTable: "account_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notification_recipient_notification_notification_id",
                        column: x => x.notification_id,
                        principalSchema: "admin",
                        principalTable: "notification",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_notification_account_id",
                schema: "admin",
                table: "notification",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_notification_company_id",
                schema: "admin",
                table: "notification",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_notification_recipient_company_id",
                schema: "admin",
                table: "notification_recipient",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_notification_recipient_company_user_id",
                schema: "admin",
                table: "notification_recipient",
                column: "company_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_notification_recipient_notification_id",
                schema: "admin",
                table: "notification_recipient",
                column: "notification_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notification_recipient",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "notification",
                schema: "admin");
        }
    }
}
