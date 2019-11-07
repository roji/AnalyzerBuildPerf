using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bolstra.Migrations
{
    public partial class DBTableCleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_attribute",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "account_collection",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "attachments",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "notes",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "account_category",
                schema: "admin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account_attribute",
                schema: "admin",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    account_category_id = table.Column<long>(nullable: true),
                    api_name = table.Column<string>(maxLength: 100, nullable: true),
                    company_id = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<long>(nullable: false),
                    definition = table.Column<string>(type: "jsonb", nullable: true, defaultValue: "{}"),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    order = table.Column<double>(nullable: true),
                    title = table.Column<string>(maxLength: 100, nullable: true),
                    type = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("account_attribute_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_account_attribute_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_account_attribute_user_created_by",
                        column: x => x.created_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_account_attribute_user_last_modified_by",
                        column: x => x.last_modified_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account_category",
                schema: "admin",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    company_id = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<long>(nullable: false),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    name = table.Column<string>(maxLength: 256, nullable: false),
                    type = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("account_category_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_account_category_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_account_category_user_created_by",
                        column: x => x.created_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_account_category_user_last_modified_by",
                        column: x => x.last_modified_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "attachments",
                schema: "admin",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    company_id = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<long>(nullable: false),
                    data = table.Column<string>(type: "jsonb", nullable: true, defaultValue: "{}"),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("attachments_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_attachments_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_attachments_user_created_by",
                        column: x => x.created_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_attachments_user_last_modified_by",
                        column: x => x.last_modified_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notes",
                schema: "admin",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    company_id = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<long>(nullable: false),
                    data = table.Column<string>(type: "jsonb", nullable: true, defaultValue: "{}"),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("notes_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_notes_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notes_user_created_by",
                        column: x => x.created_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notes_user_last_modified_by",
                        column: x => x.last_modified_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account_collection",
                schema: "admin",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    account_category_id = table.Column<long>(nullable: false),
                    account_id = table.Column<long>(nullable: true),
                    company_id = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<long>(nullable: false),
                    data = table.Column<string>(type: "jsonb", nullable: true, defaultValue: "{}"),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("account_collection_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_account_collection_account_category_account_category_id",
                        column: x => x.account_category_id,
                        principalSchema: "admin",
                        principalTable: "account_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_account_collection_account_account_id",
                        column: x => x.account_id,
                        principalSchema: "admin",
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_account_collection_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_account_collection_user_created_by",
                        column: x => x.created_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_account_collection_user_last_modified_by",
                        column: x => x.last_modified_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_account_attribute_company_id",
                schema: "admin",
                table: "account_attribute",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_attribute_created_by",
                schema: "admin",
                table: "account_attribute",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_account_attribute_last_modified_by",
                schema: "admin",
                table: "account_attribute",
                column: "last_modified_by");

            migrationBuilder.CreateIndex(
                name: "ix_account_category_company_id",
                schema: "admin",
                table: "account_category",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_category_created_by",
                schema: "admin",
                table: "account_category",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_account_category_last_modified_by",
                schema: "admin",
                table: "account_category",
                column: "last_modified_by");

            migrationBuilder.CreateIndex(
                name: "ix_account_collection_account_category_id",
                schema: "admin",
                table: "account_collection",
                column: "account_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_collection_account_id",
                schema: "admin",
                table: "account_collection",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_collection_company_id",
                schema: "admin",
                table: "account_collection",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_collection_created_by",
                schema: "admin",
                table: "account_collection",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_account_collection_last_modified_by",
                schema: "admin",
                table: "account_collection",
                column: "last_modified_by");

            migrationBuilder.CreateIndex(
                name: "ix_attachments_company_id",
                schema: "admin",
                table: "attachments",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_attachments_created_by",
                schema: "admin",
                table: "attachments",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_attachments_last_modified_by",
                schema: "admin",
                table: "attachments",
                column: "last_modified_by");

            migrationBuilder.CreateIndex(
                name: "ix_notes_company_id",
                schema: "admin",
                table: "notes",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_notes_created_by",
                schema: "admin",
                table: "notes",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_notes_last_modified_by",
                schema: "admin",
                table: "notes",
                column: "last_modified_by");
        }
    }
}
