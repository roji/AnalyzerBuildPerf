using Microsoft.EntityFrameworkCore.Migrations;
using System;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bolstra.Migrations
{
    public partial class HealthScoreImport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "note",
                schema: "health",
                table: "account_healthscore_history",
                maxLength: 75,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "healthscore_import",
                schema: "health",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_by = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    company_id = table.Column<long>(nullable: false),
                    title = table.Column<string>(maxLength: 75, nullable: false),
                    healthscore_id = table.Column<long>(nullable: false),
                    import_status = table.Column<int>(nullable: false),
                    completed_at = table.Column<DateTimeOffset>(nullable: false),
                    records_imported = table.Column<int>(nullable: false),
                    records_errored = table.Column<int>(nullable: false),
                    process_log = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("healthscore_import_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_healthscore_import_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_healthscore_import_healthscore_healthscore_id",
                        column: x => x.healthscore_id,
                        principalSchema: "health",
                        principalTable: "healthscore",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_healthscore_import_company_id",
                schema: "health",
                table: "healthscore_import",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_healthscore_import_created_by",
                schema: "health",
                table: "healthscore_import",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_healthscore_import_healthscore_id",
                schema: "health",
                table: "healthscore_import",
                column: "healthscore_id");

            migrationBuilder.CreateIndex(
                name: "ix_healthscore_import_last_modified_by",
                schema: "health",
                table: "healthscore_import",
                column: "last_modified_by");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "healthscore_import",
                schema: "health");

            migrationBuilder.DropColumn(
                name: "note",
                schema: "health",
                table: "account_healthscore_history");
        }
    }
}
