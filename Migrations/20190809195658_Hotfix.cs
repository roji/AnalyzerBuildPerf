using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace Bolstra.Migrations
{
    public partial class Hotfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stopwatch",
                schema: "engage",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    activity_id = table.Column<long>(nullable: false),
                    company_id = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<long>(nullable: false),
                    ended_at = table.Column<DateTimeOffset>(nullable: false),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    owner_id = table.Column<long>(nullable: false),
                    started_at = table.Column<DateTimeOffset>(nullable: false),
                    status = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("stopwatch_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_stopwatch_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_stopwatch_user_created_by",
                        column: x => x.created_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_stopwatch_user_last_modified_by",
                        column: x => x.last_modified_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stopwatch",
                schema: "engage");
        }
    }
}
