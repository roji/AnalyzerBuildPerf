using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bolstra.Migrations
{
    public partial class AddFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "filter",
                schema: "admin",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_by = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    company_id = table.Column<long>(nullable: false),
                    name = table.Column<string>(maxLength: 75, nullable: false),
                    type = table.Column<string>(maxLength: 25, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    filter_criteria = table.Column<string>(type: "jsonb", nullable: true, defaultValue: "{}"),
                    is_public = table.Column<bool>(nullable: false, defaultValue: false),
                    is_default = table.Column<bool>(nullable: false, defaultValue: false),
                    identifier = table.Column<string>(maxLength: 25, nullable: true),
                    configuration = table.Column<string>(type: "jsonb", nullable: true, defaultValue: "{}")
                },
                constraints: table =>
                {
                    table.PrimaryKey("filter_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_filter_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_filter_company_id",
                schema: "admin",
                table: "filter",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_filter_created_by",
                schema: "admin",
                table: "filter",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_filter_last_modified_by",
                schema: "admin",
                table: "filter",
                column: "last_modified_by");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "filter",
                schema: "admin");
        }
    }
}
