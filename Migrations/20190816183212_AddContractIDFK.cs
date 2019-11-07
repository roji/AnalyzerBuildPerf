using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bolstra.Migrations
{
    public partial class AddContractIDFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stopwatch",
                schema: "engage");

            migrationBuilder.DropForeignKey(
               name: "fk_contract_id__contract",
               schema: "engage",
               table: "invoice_payment");

            migrationBuilder.CreateIndex(
               name: "ix_invoice_payment_contract_id",
               schema: "engage",
               table: "invoice_payment",
               column:"contract_id");

            migrationBuilder.AddForeignKey(
               name: "fk_invoice_payment_contract_contract_id",
               schema: "engage",
               table: "invoice_payment",
               column: "contract_id",
               principalSchema: "engage",
               principalTable: "contract",
               principalColumn: "id",
               onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropForeignKey(
              name: "fk_contract_id__contract",
              schema: "engage",
              table: "contract_history");

            migrationBuilder.CreateIndex(
               name: "ix_contract_history_contract_id",
               schema: "engage",
               table: "contract_history",
               column: "contract_id");

            migrationBuilder.AddForeignKey(
               name: "fk_contract_history_contract_contract_id",
               schema: "engage",
               table: "contract_history",
               column: "contract_id",
               principalSchema: "engage",
               principalTable: "contract",
               principalColumn: "id",
               onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
              name: "fk_contract_history_contract_contract_id",
              schema: "engage",
              table: "contract_history");

            migrationBuilder.DropIndex(
               name: "ix_contract_history_contract_id",
               schema: "engage",
               table: "contract_history");

            migrationBuilder.AddForeignKey(
               name: "fk_contract_id__contract",
               schema: "engage",
               table: "contract_history",
               column: "contract_id",
               principalSchema: "engage",
               principalTable: "contract",
               principalColumn: "id",
               onDelete: ReferentialAction.NoAction);

            migrationBuilder.DropForeignKey(
              name: "fk_invoice_payment_contract_contract_id",
              schema: "engage",
              table: "invoice_payment");

            migrationBuilder.DropIndex(
              name: "ix_invoice_payment_contract_id",
              schema: "engage",
              table: "invoice_payment");

            migrationBuilder.AddForeignKey(
               name: "fk_contract_id__contract",
               schema: "engage",
               table: "invoice_payment",
               column: "contract_id",
               principalSchema: "engage",
               principalTable: "contract",
               principalColumn: "id",
               onDelete: ReferentialAction.Cascade);

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
        }
    }
}
