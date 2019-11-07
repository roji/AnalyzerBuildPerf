using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bolstra.Migrations
{
    public partial class DropAppointmentTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment_assignment",
                schema: "engage");

            migrationBuilder.DropTable(
                name: "appointment_relation",
                schema: "engage");

            migrationBuilder.DropTable(
                name: "stopwatch",
                schema: "engage");

            migrationBuilder.DropTable(
                name: "appointment",
                schema: "engage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appointment",
                schema: "engage",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    color_id = table.Column<long>(nullable: false),
                    company_id = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<long>(nullable: false),
                    ended_at = table.Column<DateTimeOffset>(nullable: false),
                    label = table.Column<string>(maxLength: 255, nullable: true),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    started_at = table.Column<DateTimeOffset>(nullable: false),
                    type = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appointment_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_appointment_color_color_id",
                        column: x => x.color_id,
                        principalSchema: "engage",
                        principalTable: "color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointment_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointment_user_created_by",
                        column: x => x.created_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointment_user_last_modified_by",
                        column: x => x.last_modified_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stopwatch",
                schema: "engage",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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

            migrationBuilder.CreateTable(
                name: "appointment_assignment",
                schema: "engage",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    appointment_id = table.Column<long>(nullable: false),
                    company_id = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<long>(nullable: false),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    user_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appointment_assignment_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_appointment_assignment_appointment_appointment_id",
                        column: x => x.appointment_id,
                        principalSchema: "engage",
                        principalTable: "appointment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointment_assignment_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointment_assignment_user_created_by",
                        column: x => x.created_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointment_assignment_user_last_modified_by",
                        column: x => x.last_modified_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointment_relation",
                schema: "engage",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    appointment_id = table.Column<long>(nullable: false),
                    company_id = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<long>(nullable: false),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<long>(nullable: false),
                    relation_id = table.Column<long>(nullable: false),
                    relation_type = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appointment_relation_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_appointment_relation_appointment_appointment_id",
                        column: x => x.appointment_id,
                        principalSchema: "engage",
                        principalTable: "appointment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointment_relation_company_company_id",
                        column: x => x.company_id,
                        principalSchema: "admin",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointment_relation_user_created_by",
                        column: x => x.created_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointment_relation_user_last_modified_by",
                        column: x => x.last_modified_by,
                        principalSchema: "admin",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_appointment_color_id",
                schema: "engage",
                table: "appointment",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointment_company_id",
                schema: "engage",
                table: "appointment",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointment_created_by",
                schema: "engage",
                table: "appointment",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_appointment_last_modified_by",
                schema: "engage",
                table: "appointment",
                column: "last_modified_by");

            migrationBuilder.CreateIndex(
                name: "ix_appointment_assignment_appointment_id",
                schema: "engage",
                table: "appointment_assignment",
                column: "appointment_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointment_assignment_company_id",
                schema: "engage",
                table: "appointment_assignment",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointment_assignment_created_by",
                schema: "engage",
                table: "appointment_assignment",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_appointment_assignment_last_modified_by",
                schema: "engage",
                table: "appointment_assignment",
                column: "last_modified_by");

            migrationBuilder.CreateIndex(
                name: "ix_appointment_relation_appointment_id",
                schema: "engage",
                table: "appointment_relation",
                column: "appointment_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointment_relation_company_id",
                schema: "engage",
                table: "appointment_relation",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointment_relation_created_by",
                schema: "engage",
                table: "appointment_relation",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_appointment_relation_last_modified_by",
                schema: "engage",
                table: "appointment_relation",
                column: "last_modified_by");

            migrationBuilder.CreateIndex(
                name: "ix_stopwatch_company_id",
                schema: "engage",
                table: "stopwatch",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_stopwatch_created_by",
                schema: "engage",
                table: "stopwatch",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_stopwatch_last_modified_by",
                schema: "engage",
                table: "stopwatch",
                column: "last_modified_by");
        }
    }
}
