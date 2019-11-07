using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddAccountIdFK : Migration
    {
        private void CleanUpData(MigrationBuilder migrationBuilder)
        {
            var tables = new string[] {
                    "engage.checklist",
                    "engage.activity_assignment"
            };

            foreach (var table in tables)
            {
                var sql = $"DELETE FROM {table} a WHERE NOT EXISTS (SELECT id FROM engage.activity WHERE id = a.activity_id)";
                migrationBuilder.Sql(sql);
            }

            foreach (var table in tables)
            {
                var sql = $"DELETE FROM {table} WHERE activity_id in (Select id from engage.activity where engagement_id in " +
                $"(Select id from engage.engagement a where a.account_id is null OR NOT EXISTS (SELECT id FROM admin.account WHERE id = a.account_id)))";
                migrationBuilder.Sql(sql);
            }

            tables = new string[] {
                    "engage.milestone",
                    "engage.activity"
            };

            foreach (var table in tables)
            {
                var sql = $"DELETE FROM {table} a WHERE a.engagement_id in " +
                $"(Select id from engage.engagement a where a.account_id is null OR NOT EXISTS (SELECT id FROM admin.account WHERE id = a.account_id))";
                migrationBuilder.Sql(sql);
            }
            
            tables = new string[] {
                    "admin.account_user",
                    "engage.account_name",
                    "engage.engagement",
                    "engage.contract",
                    "health.account_health_setting"
            };

            foreach (var table in tables)
            {
                var sql = $"DELETE FROM {table} a WHERE a.account_id is null OR NOT EXISTS (SELECT id FROM admin.account WHERE id = a.account_id)";
                migrationBuilder.Sql(sql);
            }

            tables = new string[] {
                    "engage.activity",
                    "engage.activity_contact",
            };
            foreach (var table in tables)
            {
                var sql = $"DELETE FROM {table} a WHERE a.account_id is not null and NOT EXISTS (SELECT id FROM admin.account WHERE id = a.account_id)";
                migrationBuilder.Sql(sql);
            }

        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.DropForeignKey(
              name: "account_user_account_id_fkey",
              schema: "admin",
              table: "account_user");

            migrationBuilder.DropForeignKey(
               name: "fk_engagement_id__engagement",
               schema: "engage",
               table: "milestone");

            migrationBuilder.DropForeignKey(
              name: "fk_engagement_model_id__engagement_model",
              schema: "engage",
              table: "milestone_model");

            migrationBuilder.DropForeignKey(
              name: "fk_engagement_id__engagement",
              schema: "engage",
              table: "activity");

            migrationBuilder.DropForeignKey(
              name: "fk_activity_engagement_engagement_id",
              schema: "engage",
              table: "activity");

            migrationBuilder.DropForeignKey(
              name: "fk_activity_id__activity",
              schema: "engage",
              table: "checklist");

            migrationBuilder.DropForeignKey(
              name: "fk_activity_id__activity",
              schema: "engage",
              table: "activity_assignment");

            CleanUpData(migrationBuilder);

            migrationBuilder.DropIndex(
               name: "activity_assignment_activity_id_idx",
               schema: "engage",
               table: "activity_assignment");

            migrationBuilder.DropIndex(
                name: "checklist_activity_id_idx",
                schema: "engage",
                table: "checklist");

            migrationBuilder.DropIndex(
                name: "account_health_setting_account_id_idx",
                schema: "health",
                table: "account_health_setting");

            migrationBuilder.AlterColumn<long>(
                name: "company_id",
                schema: "engage",
                table: "activity_assignment",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "activity_id",
                schema: "engage",
                table: "activity_assignment",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                schema: "engage",
                table: "activity_assignment",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "account_id",
                schema: "health",
                table: "account_health_setting",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                 name: "engagement_id",
                 schema: "engage",
                 table: "milestone",
                 nullable: false,
                 oldClrType: typeof(long),
                 oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "engagement_model_id",
                schema: "engage",
                table: "milestone_model",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "activity_id",
                schema: "engage",
                table: "checklist",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_account_health_setting_account_id",
                schema: "health",
                table: "account_health_setting",
                column: "account_id");

            migrationBuilder.AlterColumn<long>(
                name: "account_id",
                schema: "engage",
                table: "engagement",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "account_id",
                schema: "engage",
                table: "account_name",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "account_id",
                schema: "engage",
                table: "contract",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_engagement_account_id",
                schema: "engage",
                table: "engagement",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_contact_account_id",
                schema: "engage",
                table: "activity_contact",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_account_id",
                schema: "engage",
                table: "activity",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_name_account_id",
                schema: "engage",
                table: "account_name",
                column: "account_id");

            migrationBuilder.CreateIndex(
               name: "ix_contract_account_id",
               schema: "engage",
               table: "contract",
               column: "account_id");

            migrationBuilder.CreateIndex(
               name: "ix_milestone_engagement_id",
               schema: "engage",
               table: "milestone",
               column: "engagement_id");

            migrationBuilder.CreateIndex(
              name: "ix_checklist_activity_id",
              schema: "engage",
              table: "checklist",
              column: "activity_id");

            migrationBuilder.CreateIndex(
              name: "ix_activity_assignment_activity_id",
              schema: "engage",
              table: "activity_assignment",
              column: "activity_id");

            migrationBuilder.CreateIndex(
             name: "ix_milestone_model_engagement_model_id",
             schema: "engage",
             table: "milestone_model",
             column: "engagement_model_id");

            migrationBuilder.AddForeignKey(
                name: "fk_account_name_account_account_id",
                schema: "engage",
                table: "account_name",
                column: "account_id",
                principalSchema: "admin",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_account_account_id",
                schema: "engage",
                table: "activity",
                column: "account_id",
                principalSchema: "admin",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_contact_account_account_id",
                schema: "engage",
                table: "activity_contact",
                column: "account_id",
                principalSchema: "admin",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);


           migrationBuilder.AddForeignKey(
                name: "fk_engagement_account_account_id",
                schema: "engage",
                table: "engagement",
                column: "account_id",
                principalSchema: "admin",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_contract_account_account_id",
                schema: "engage",
                table: "contract",
                column: "account_id",
                principalSchema: "admin",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_entry_company_user_user_id",
                schema: "engage",
                table: "time_entry",
                column: "user_id",
                principalSchema: "admin",
                principalTable: "company_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_health_setting_account_account_id",
                schema: "health",
                table: "account_health_setting",
                column: "account_id",
                principalSchema: "admin",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_user_account_account_id",
                schema: "admin",
                table: "account_user",
                column: "account_id",
                principalSchema: "admin",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_milestone_engagement_engagement_id",
                schema: "engage",
                table: "milestone",
                column: "engagement_id",
                principalSchema: "engage",
                principalTable: "engagement",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_milestone_model_engagement_model_engagement_model_id",
                schema: "engage",
                table: "milestone_model",
                column: "engagement_model_id",
                principalSchema: "engage",
                principalTable: "engagement_model",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
               name: "fk_activity_engagement_engagement_id",
               schema: "engage",
               table: "activity",
               column: "engagement_id",
               principalSchema: "engage",
               principalTable: "engagement",
               principalColumn: "id",
               onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
               name: "fk_checklist_activity_activity_id",
               schema: "engage",
               table: "checklist",
               column: "activity_id",
               principalSchema: "engage",
               principalTable: "activity",
               principalColumn: "id",
               onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
               name: "fk_activity_assignment_activity_activity_id",
               schema: "engage",
               table: "activity_assignment",
               column: "activity_id",
               principalSchema: "engage",
               principalTable: "activity",
               principalColumn: "id",
               onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "fk_activity_assignment_activity_activity_id",
               schema: "engage",
               table: "activity_assignment");

            migrationBuilder.DropForeignKey(
               name: "fk_activity_engagement_engagement_id",
               schema: "engage",
               table: "activity");

            migrationBuilder.DropForeignKey(
               name: "fk_milestone_model_engagement_model_engagement_model_id",
               schema: "engage",
               table: "milestone_model");

            migrationBuilder.DropForeignKey(
                name: "fk_milestone_engagement_engagement_id",
                schema: "engage",
                table: "milestone");

            migrationBuilder.DropForeignKey(
                name: "fk_account_name_account_account_id",
                schema: "engage",
                table: "account_name");

            migrationBuilder.DropForeignKey(
                name: "fk_contract_account_account_id",
                schema: "engage",
                table: "contract");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_account_account_id",
                schema: "engage",
                table: "activity");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_contact_account_account_id",
                schema: "engage",
                table: "activity_contact");

            migrationBuilder.DropForeignKey(
                name: "fk_engagement_account_account_id",
                schema: "engage",
                table: "engagement");

            migrationBuilder.DropForeignKey(
                name: "fk_time_entry_company_user_user_id",
                schema: "engage",
                table: "time_entry");

            migrationBuilder.DropForeignKey(
                name: "fk_account_health_setting_account_account_id",
                schema: "health",
                table: "account_health_setting");

            migrationBuilder.DropIndex(
                name: "ix_engagement_account_id",
                schema: "engage",
                table: "engagement");

            migrationBuilder.DropIndex(
                name: "ix_contract_account_id",
                schema: "engage",
                table: "contract");

            migrationBuilder.DropIndex(
                name: "ix_activity_contact_account_id",
                schema: "engage",
                table: "activity_contact");

            migrationBuilder.DropIndex(
                name: "ix_activity_account_id",
                schema: "engage",
                table: "activity");

            migrationBuilder.DropIndex(
                name: "ix_account_name_account_id",
                schema: "engage",
                table: "account_name");

            migrationBuilder.DropIndex(
               name: "ix_milestone_engagement_id",
               schema: "engage",
               table: "milestone");

            migrationBuilder.DropIndex(
              name: "ix_milestone_model_engagement_model_id",
              schema: "engage",
              table: "milestone_model");

            migrationBuilder.AlterColumn<long>(
                name: "account_id",
                schema: "health",
                table: "account_health_setting",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "account_id",
                schema: "engage",
                table: "engagement",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "account_id",
                schema: "engage",
                table: "account_name",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "account_id",
                schema: "engage",
                table: "contract",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "account_health_setting_account_id_idx",
                schema: "health",
                table: "account_health_setting",
                column: "account_id");

            migrationBuilder.AddForeignKey(
              name: "account_user_account_id_fkey",
              schema: "admin",
              table: "account_user",
              column: "account_id",
              principalSchema: "admin",
              principalTable: "account",
              principalColumn: "id",
              onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
               name: "fk_engagement_id__engagement",
               schema: "engage",
               table: "activity",
               column: "engagement_id",
               principalSchema: "engage",
               principalTable: "engagement",
               principalColumn: "id",
               onDelete: ReferentialAction.NoAction);
        }
    }
}
