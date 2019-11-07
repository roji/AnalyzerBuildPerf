using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddCompanyIdFK : Migration
    {
        private void CleanUpData(MigrationBuilder migrationBuilder)
        {
            var tables = new string[] {
                    "admin.company_key",
                    "admin.company_user_role",
                    "engage.account_priority",
                    "engage.account_name",
                    "engage.activity",
                    "engage.activity_lane",
                    "engage.activity_board",
                    "engage.activity_contact",
                    "engage.activity_status",
                    "engage.activity_type",
                    "engage.engagement",
                    "engage.engagement_model",
                    "engage.engagement_status",
                    "engage.company_key",
                    "engage.engagement_status",
                    "engage.label",
                    "events.sfdc_integration",
                    "events.sfdc_integration_object",
                    "file.attachment_reference",
                    "file.attachment",
                    "file.comment_reference",
                    "file.comment",
                    "health.account_healthscore",
                    "health.account_health_setting",
                    "health.account_achievement",
                    "health.achievement",
                    "health.healthscore",
                    "health.lifestage",
                    "health.lifecycle",
                    "triggers.trigger",
                    "triggers.report",
                    "triggers.dashboard",
                    "triggers.analytic_source"
            };

            foreach (var table in tables)
            {
                string sql = $"DELETE FROM {table} WHERE NOT EXISTS (SELECT id FROM admin.company WHERE id = company_id)";
                migrationBuilder.Sql(sql);
            } 
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            CleanUpData(migrationBuilder);

            migrationBuilder.CreateIndex(
                name: "ix_trigger_company_id",
                schema: "triggers",
                table: "trigger",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_report_company_id",
                schema: "triggers",
                table: "report",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_dashboard_company_id",
                schema: "triggers",
                table: "dashboard",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_analytic_source_company_id",
                schema: "triggers",
                table: "analytic_source",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_lifestage_company_id",
                schema: "health",
                table: "lifestage",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_lifecycle_company_id",
                schema: "health",
                table: "lifecycle",
                column: "company_id");


            migrationBuilder.CreateIndex(
                name: "ix_healthscore_component_company_id",
                schema: "health",
                table: "healthscore_component",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_healthscore_company_id",
                schema: "health",
                table: "healthscore",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_achievement_company_id",
                schema: "health",
                table: "achievement",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_healthscore_history_company_id",
                schema: "health",
                table: "account_healthscore_history",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_healthscore_company_id",
                schema: "health",
                table: "account_healthscore",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_health_setting_company_id",
                schema: "health",
                table: "account_health_setting",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_achievement_company_id",
                schema: "health",
                table: "account_achievement",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_comment_reference_company_id",
                schema: "file",
                table: "comment_reference",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_comment_company_id",
                schema: "file",
                table: "comment",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_attachment_reference_company_id",
                schema: "file",
                table: "attachment_reference",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_attachment_company_id",
                schema: "file",
                table: "attachment",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_subscriber_company_id",
                schema: "events",
                table: "subscriber",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_sfdc_integration_object_company_id",
                schema: "events",
                table: "sfdc_integration_object",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_sfdc_integration_error_company_id",
                schema: "events",
                table: "sfdc_integration_error",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_sfdc_integration_company_id",
                schema: "events",
                table: "sfdc_integration",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_container_version_reference_company_id",
                schema: "events",
                table: "container_version_reference",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_container_version_log_company_id",
                schema: "events",
                table: "container_version_log",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_container_version_active_history_company_id",
                schema: "events",
                table: "container_version_active_history",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_container_version_company_id",
                schema: "events",
                table: "container_version",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_container_company_id",
                schema: "events",
                table: "container",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_entry_company_id",
                schema: "engage",
                table: "time_entry",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_milestone_model_company_id",
                schema: "engage",
                table: "milestone_model",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_milestone_company_id",
                schema: "engage",
                table: "milestone",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_layout_section_row_company_id",
                schema: "engage",
                table: "layout_section_row",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_layout_section_company_id",
                schema: "engage",
                table: "layout_section",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_layout_company_id",
                schema: "engage",
                table: "layout",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_label_company_id",
                schema: "engage",
                table: "label",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_invoice_payment_company_id",
                schema: "engage",
                table: "invoice_payment",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_integration_property_company_id",
                schema: "engage",
                table: "integration_property",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_integration_mapping_company_id",
                schema: "engage",
                table: "integration_mapping",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_expected_activity_company_id",
                schema: "engage",
                table: "expected_activity",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_engagement_status_company_id",
                schema: "engage",
                table: "engagement_status",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_engagement_model_company_id",
                schema: "engage",
                table: "engagement_model",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_engagement_company_id",
                schema: "engage",
                table: "engagement",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_contract_history_company_id",
                schema: "engage",
                table: "contract_history",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_contract_custom_data_company_id",
                schema: "engage",
                table: "contract_custom_data",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_contract_company_id",
                schema: "engage",
                table: "contract",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_color_company_id",
                schema: "engage",
                table: "color",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_checklist_model_company_id",
                schema: "engage",
                table: "checklist_model",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_checklist_company_id",
                schema: "engage",
                table: "checklist",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_analytics_join_key_company_id",
                schema: "engage",
                table: "analytics_join_key",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_type_company_id",
                schema: "engage",
                table: "activity_type",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_status_company_id",
                schema: "engage",
                table: "activity_status",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_lane_company_id",
                schema: "engage",
                table: "activity_lane",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_label_company_id",
                schema: "engage",
                table: "activity_label",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_custom_data_company_id",
                schema: "engage",
                table: "activity_custom_data",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_contact_company_id",
                schema: "engage",
                table: "activity_contact",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_board_company_id",
                schema: "engage",
                table: "activity_board",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_assignment_company_id",
                schema: "engage",
                table: "activity_assignment",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_company_id",
                schema: "engage",
                table: "activity",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_priority_company_id",
                schema: "engage",
                table: "account_priority",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_name_company_id",
                schema: "engage",
                table: "account_name",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_notification_recipient_company_id",
                schema: "admin",
                table: "notification_recipient",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_notification_company_id",
                schema: "admin",
                table: "notification",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_licensed_modules_company_id",
                schema: "admin",
                table: "licensed_modules",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_layout_section_row_company_id",
                schema: "admin",
                table: "layout_section_row",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_layout_section_company_id",
                schema: "admin",
                table: "layout_section",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_layout_company_id",
                schema: "admin",
                table: "layout",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_filter_company_id",
                schema: "admin",
                table: "filter",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_company_user_role_company_id",
                schema: "admin",
                table: "company_user_role",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_company_key_company_id",
                schema: "admin",
                table: "company_key",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_company_db_config_company_id",
                schema: "admin",
                table: "company_db_config",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_analytics_join_key_company_id",
                schema: "admin",
                table: "analytics_join_key",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_user_custom_data_company_id",
                schema: "admin",
                table: "account_user_custom_data",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_user_company_id",
                schema: "admin",
                table: "account_user",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_population_company_id",
                schema: "admin",
                table: "account_population",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_filter_company_id",
                schema: "admin",
                table: "account_filter",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_custom_data_company_id",
                schema: "admin",
                table: "account_custom_data",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_company_id",
                schema: "admin",
                table: "account",
                column: "company_id");

            migrationBuilder.CreateIndex(
              name: "ix_access_log_company_id",
              schema: "admin",
              table: "access_log",
              column: "company_id");

            migrationBuilder.AddForeignKey(
               name: "fk_access_log_company_company_id",
               schema: "admin",
               table: "access_log",
               column: "company_id",
               principalSchema: "admin",
               principalTable: "company",
               principalColumn: "id",
               onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_company_company_id",
                schema: "admin",
                table: "account",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_custom_data_company_company_id",
                schema: "admin",
                table: "account_custom_data",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_filter_company_company_id",
                schema: "admin",
                table: "account_filter",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_population_company_company_id",
                schema: "admin",
                table: "account_population",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_user_company_company_id",
                schema: "admin",
                table: "account_user",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_user_custom_data_company_company_id",
                schema: "admin",
                table: "account_user_custom_data",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_analytics_join_key_company_company_id",
                schema: "admin",
                table: "analytics_join_key",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_company_db_config_company_company_id",
                schema: "admin",
                table: "company_db_config",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_company_key_company_company_id",
                schema: "admin",
                table: "company_key",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_company_user_company_company_id",
                schema: "admin",
                table: "company_user",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_company_user_role_company_company_id",
                schema: "admin",
                table: "company_user_role",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_filter_company_company_id",
                schema: "admin",
                table: "filter",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_layout_company_company_id",
                schema: "admin",
                table: "layout",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_layout_section_company_company_id",
                schema: "admin",
                table: "layout_section",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_layout_section_row_company_company_id",
                schema: "admin",
                table: "layout_section_row",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_licensed_modules_company_id",
                schema: "admin",
                table: "licensed_modules",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_notification_company_company_id",
                schema: "admin",
                table: "notification",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_notification_recipient_company_company_id",
                schema: "admin",
                table: "notification_recipient",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_name_company_company_id",
                schema: "engage",
                table: "account_name",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_priority_company_company_id",
                schema: "engage",
                table: "account_priority",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_company_company_id",
                schema: "engage",
                table: "activity",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_assignment_company_company_id",
                schema: "engage",
                table: "activity_assignment",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_board_company_company_id",
                schema: "engage",
                table: "activity_board",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_contact_company_company_id",
                schema: "engage",
                table: "activity_contact",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_custom_data_company_company_id",
                schema: "engage",
                table: "activity_custom_data",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_filter_company_company_id",
                schema: "engage",
                table: "activity_filter",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_label_company_company_id",
                schema: "engage",
                table: "activity_label",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_lane_company_company_id",
                schema: "engage",
                table: "activity_lane",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_population_company_company_id",
                schema: "engage",
                table: "activity_population",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_status_company_company_id",
                schema: "engage",
                table: "activity_status",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_activity_type_company_company_id",
                schema: "engage",
                table: "activity_type",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_analytics_join_key_company_company_id",
                schema: "engage",
                table: "analytics_join_key",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_checklist_company_company_id",
                schema: "engage",
                table: "checklist",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_checklist_model_company_company_id",
                schema: "engage",
                table: "checklist_model",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_color_company_company_id",
                schema: "engage",
                table: "color",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);


            migrationBuilder.AddForeignKey(
                name: "fk_company_key_company_company_id",
                schema: "engage",
                table: "company_key",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_contract_company_company_id",
                schema: "engage",
                table: "contract",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_contract_custom_data_company_company_id",
                schema: "engage",
                table: "contract_custom_data",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_contract_history_company_company_id",
                schema: "engage",
                table: "contract_history",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_contract_population_company_company_id",
                schema: "engage",
                table: "contract_population",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_engagement_company_company_id",
                schema: "engage",
                table: "engagement",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_engagement_model_company_company_id",
                schema: "engage",
                table: "engagement_model",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_engagement_status_company_company_id",
                schema: "engage",
                table: "engagement_status",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_expected_activity_company_company_id",
                schema: "engage",
                table: "expected_activity",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_integration_mapping_company_company_id",
                schema: "engage",
                table: "integration_mapping",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_integration_property_company_company_id",
                schema: "engage",
                table: "integration_property",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_invoice_payment_company_company_id",
                schema: "engage",
                table: "invoice_payment",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_invoice_payment_population_company_company_id",
                schema: "engage",
                table: "invoice_payment_population",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_label_company_company_id",
                schema: "engage",
                table: "label",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_layout_company_company_id",
                schema: "engage",
                table: "layout",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_layout_section_company_company_id",
                schema: "engage",
                table: "layout_section",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_layout_section_row_company_company_id",
                schema: "engage",
                table: "layout_section_row",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_milestone_company_company_id",
                schema: "engage",
                table: "milestone",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_milestone_model_company_company_id",
                schema: "engage",
                table: "milestone_model",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_entry_company_company_id",
                schema: "engage",
                table: "time_entry",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_entry_population_company_company_id",
                schema: "engage",
                table: "time_entry_population",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_container_company_company_id",
                schema: "events",
                table: "container",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_container_version_company_company_id",
                schema: "events",
                table: "container_version",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_container_version_active_history_company_company_id",
                schema: "events",
                table: "container_version_active_history",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_container_version_capability_company_company_id",
                schema: "events",
                table: "container_version_capability",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_container_version_log_company_company_id",
                schema: "events",
                table: "container_version_log",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_container_version_reference_company_company_id",
                schema: "events",
                table: "container_version_reference",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sfdc_integration_company_company_id",
                schema: "events",
                table: "sfdc_integration",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sfdc_integration_error_company_company_id",
                schema: "events",
                table: "sfdc_integration_error",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sfdc_integration_object_company_company_id",
                schema: "events",
                table: "sfdc_integration_object",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_subscriber_company_company_id",
                schema: "events",
                table: "subscriber",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_attachment_company_company_id",
                schema: "file",
                table: "attachment",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_attachment_reference_company_company_id",
                schema: "file",
                table: "attachment_reference",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_comment_company_company_id",
                schema: "file",
                table: "comment",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_comment_reference_company_company_id",
                schema: "file",
                table: "comment_reference",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);


            migrationBuilder.AddForeignKey(
                name: "fk_account_achievement_company_company_id",
                schema: "health",
                table: "account_achievement",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_health_setting_company_company_id",
                schema: "health",
                table: "account_health_setting",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_healthscore_company_company_id",
                schema: "health",
                table: "account_healthscore",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_account_healthscore_history_company_company_id",
                schema: "health",
                table: "account_healthscore_history",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_achievement_company_company_id",
                schema: "health",
                table: "achievement",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_healthscore_company_company_id",
                schema: "health",
                table: "healthscore",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_healthscore_component_company_company_id",
                schema: "health",
                table: "healthscore_component",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);


            migrationBuilder.AddForeignKey(
                name: "fk_lifecycle_company_company_id",
                schema: "health",
                table: "lifecycle",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_lifestage_company_company_id",
                schema: "health",
                table: "lifestage",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_analytic_source_company_company_id",
                schema: "triggers",
                table: "analytic_source",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_dashboard_company_company_id",
                schema: "triggers",
                table: "dashboard",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_report_company_company_id",
                schema: "triggers",
                table: "report",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_trigger_company_company_id",
                schema: "triggers",
                table: "trigger",
                column: "company_id",
                principalSchema: "admin",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_access_log_company_company_id",
                schema: "admin",
                table: "access_log");

            migrationBuilder.DropForeignKey(
                name: "fk_account_company_company_id",
                schema: "admin",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "fk_account_custom_data_company_company_id",
                schema: "admin",
                table: "account_custom_data");

            migrationBuilder.DropForeignKey(
                name: "fk_account_filter_company_company_id",
                schema: "admin",
                table: "account_filter");

            migrationBuilder.DropForeignKey(
                name: "fk_account_population_company_company_id",
                schema: "admin",
                table: "account_population");

            migrationBuilder.DropForeignKey(
                name: "fk_account_user_company_company_id",
                schema: "admin",
                table: "account_user");

            migrationBuilder.DropForeignKey(
                name: "fk_account_user_custom_data_company_company_id",
                schema: "admin",
                table: "account_user_custom_data");

            migrationBuilder.DropForeignKey(
                name: "fk_analytics_join_key_company_company_id",
                schema: "admin",
                table: "analytics_join_key");

            migrationBuilder.DropForeignKey(
                name: "fk_company_db_config_company_company_id",
                schema: "admin",
                table: "company_db_config");

            migrationBuilder.DropForeignKey(
                name: "fk_company_key_company_company_id",
                schema: "admin",
                table: "company_key");

            migrationBuilder.DropForeignKey(
                name: "fk_company_user_company_company_id",
                schema: "admin",
                table: "company_user");

            migrationBuilder.DropForeignKey(
                name: "fk_company_user_role_company_company_id",
                schema: "admin",
                table: "company_user_role");

            migrationBuilder.DropForeignKey(
                name: "fk_filter_company_company_id",
                schema: "admin",
                table: "filter");

            migrationBuilder.DropForeignKey(
                name: "fk_layout_company_company_id",
                schema: "admin",
                table: "layout");

            migrationBuilder.DropForeignKey(
                name: "fk_layout_section_company_company_id",
                schema: "admin",
                table: "layout_section");

            migrationBuilder.DropForeignKey(
                name: "fk_layout_section_row_company_company_id",
                schema: "admin",
                table: "layout_section_row");

            migrationBuilder.DropForeignKey(
                name: "fk_licensed_modules_company_id",
                schema: "admin",
                table: "licensed_modules");

            migrationBuilder.DropForeignKey(
                name: "fk_notification_company_company_id",
                schema: "admin",
                table: "notification");

            migrationBuilder.DropForeignKey(
                name: "fk_notification_recipient_company_company_id",
                schema: "admin",
                table: "notification_recipient");

            migrationBuilder.DropForeignKey(
                name: "fk_account_name_company_company_id",
                schema: "engage",
                table: "account_name");

            migrationBuilder.DropForeignKey(
                name: "fk_account_priority_company_company_id",
                schema: "engage",
                table: "account_priority");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_company_company_id",
                schema: "engage",
                table: "activity");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_assignment_company_company_id",
                schema: "engage",
                table: "activity_assignment");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_board_company_company_id",
                schema: "engage",
                table: "activity_board");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_contact_company_company_id",
                schema: "engage",
                table: "activity_contact");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_custom_data_company_company_id",
                schema: "engage",
                table: "activity_custom_data");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_filter_company_company_id",
                schema: "engage",
                table: "activity_filter");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_label_company_company_id",
                schema: "engage",
                table: "activity_label");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_lane_company_company_id",
                schema: "engage",
                table: "activity_lane");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_population_company_company_id",
                schema: "engage",
                table: "activity_population");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_status_company_company_id",
                schema: "engage",
                table: "activity_status");

            migrationBuilder.DropForeignKey(
                name: "fk_activity_type_company_company_id",
                schema: "engage",
                table: "activity_type");

            migrationBuilder.DropForeignKey(
                name: "fk_analytics_join_key_company_company_id",
                schema: "engage",
                table: "analytics_join_key");

            migrationBuilder.DropForeignKey(
                name: "fk_checklist_company_company_id",
                schema: "engage",
                table: "checklist");

            migrationBuilder.DropForeignKey(
                name: "fk_checklist_model_company_company_id",
                schema: "engage",
                table: "checklist_model");

            migrationBuilder.DropForeignKey(
                name: "fk_color_company_company_id",
                schema: "engage",
                table: "color");

            migrationBuilder.DropForeignKey(
                name: "fk_company_key_company_company_id",
                schema: "engage",
                table: "company_key");

            migrationBuilder.DropForeignKey(
                name: "fk_contract_company_company_id",
                schema: "engage",
                table: "contract");

            migrationBuilder.DropForeignKey(
                name: "fk_contract_custom_data_company_company_id",
                schema: "engage",
                table: "contract_custom_data");

            migrationBuilder.DropForeignKey(
                name: "fk_contract_history_company_company_id",
                schema: "engage",
                table: "contract_history");

            migrationBuilder.DropForeignKey(
                name: "fk_contract_population_company_company_id",
                schema: "engage",
                table: "contract_population");

            migrationBuilder.DropForeignKey(
                name: "fk_engagement_company_company_id",
                schema: "engage",
                table: "engagement");

            migrationBuilder.DropForeignKey(
                name: "fk_engagement_model_company_company_id",
                schema: "engage",
                table: "engagement_model");

            migrationBuilder.DropForeignKey(
                name: "fk_engagement_status_company_company_id",
                schema: "engage",
                table: "engagement_status");

            migrationBuilder.DropForeignKey(
                name: "fk_expected_activity_company_company_id",
                schema: "engage",
                table: "expected_activity");

            migrationBuilder.DropForeignKey(
                name: "fk_integration_mapping_company_company_id",
                schema: "engage",
                table: "integration_mapping");

            migrationBuilder.DropForeignKey(
                name: "fk_integration_property_company_company_id",
                schema: "engage",
                table: "integration_property");

            migrationBuilder.DropForeignKey(
                name: "fk_invoice_payment_company_company_id",
                schema: "engage",
                table: "invoice_payment");

            migrationBuilder.DropForeignKey(
                name: "fk_invoice_payment_population_company_company_id",
                schema: "engage",
                table: "invoice_payment_population");

            migrationBuilder.DropForeignKey(
                name: "fk_label_company_company_id",
                schema: "engage",
                table: "label");

            migrationBuilder.DropForeignKey(
                name: "fk_layout_company_company_id",
                schema: "engage",
                table: "layout");

            migrationBuilder.DropForeignKey(
                name: "fk_layout_section_company_company_id",
                schema: "engage",
                table: "layout_section");

            migrationBuilder.DropForeignKey(
                name: "fk_layout_section_row_company_company_id",
                schema: "engage",
                table: "layout_section_row");

            migrationBuilder.DropForeignKey(
                name: "fk_milestone_company_company_id",
                schema: "engage",
                table: "milestone");

            migrationBuilder.DropForeignKey(
                name: "fk_milestone_model_company_company_id",
                schema: "engage",
                table: "milestone_model");

            migrationBuilder.DropForeignKey(
                name: "fk_time_entry_company_company_id",
                schema: "engage",
                table: "time_entry");

            migrationBuilder.DropForeignKey(
                name: "fk_time_entry_population_company_company_id",
                schema: "engage",
                table: "time_entry_population");

            migrationBuilder.DropForeignKey(
                name: "fk_container_company_company_id",
                schema: "events",
                table: "container");

            migrationBuilder.DropForeignKey(
                name: "fk_container_version_company_company_id",
                schema: "events",
                table: "container_version");

            migrationBuilder.DropForeignKey(
                name: "fk_container_version_active_history_company_company_id",
                schema: "events",
                table: "container_version_active_history");

            migrationBuilder.DropForeignKey(
                name: "fk_container_version_capability_company_company_id",
                schema: "events",
                table: "container_version_capability");

            migrationBuilder.DropForeignKey(
                name: "fk_container_version_log_company_company_id",
                schema: "events",
                table: "container_version_log");

            migrationBuilder.DropForeignKey(
                name: "fk_container_version_reference_company_company_id",
                schema: "events",
                table: "container_version_reference");

            migrationBuilder.DropForeignKey(
                name: "fk_sfdc_integration_company_company_id",
                schema: "events",
                table: "sfdc_integration");

            migrationBuilder.DropForeignKey(
                name: "fk_sfdc_integration_error_company_company_id",
                schema: "events",
                table: "sfdc_integration_error");

            migrationBuilder.DropForeignKey(
                name: "fk_sfdc_integration_object_company_company_id",
                schema: "events",
                table: "sfdc_integration_object");

            migrationBuilder.DropForeignKey(
                name: "fk_subscriber_company_company_id",
                schema: "events",
                table: "subscriber");

            migrationBuilder.DropForeignKey(
                name: "fk_attachment_company_company_id",
                schema: "file",
                table: "attachment");

            migrationBuilder.DropForeignKey(
                name: "fk_attachment_reference_company_company_id",
                schema: "file",
                table: "attachment_reference");

            migrationBuilder.DropForeignKey(
                name: "fk_comment_company_company_id",
                schema: "file",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "fk_comment_reference_company_company_id",
                schema: "file",
                table: "comment_reference");

            migrationBuilder.DropForeignKey(
                name: "fk_account_achievement_company_company_id",
                schema: "health",
                table: "account_achievement");

            migrationBuilder.DropForeignKey(
                name: "fk_account_health_setting_company_company_id",
                schema: "health",
                table: "account_health_setting");

            migrationBuilder.DropForeignKey(
                name: "fk_account_healthscore_company_company_id",
                schema: "health",
                table: "account_healthscore");

            migrationBuilder.DropForeignKey(
                name: "fk_account_healthscore_history_company_company_id",
                schema: "health",
                table: "account_healthscore_history");

            migrationBuilder.DropForeignKey(
                name: "fk_achievement_company_company_id",
                schema: "health",
                table: "achievement");

            migrationBuilder.DropForeignKey(
                name: "fk_healthscore_company_company_id",
                schema: "health",
                table: "healthscore");

            migrationBuilder.DropForeignKey(
                name: "fk_healthscore_component_company_company_id",
                schema: "health",
                table: "healthscore_component");

            migrationBuilder.DropForeignKey(
                name: "fk_lifecycle_company_company_id",
                schema: "health",
                table: "lifecycle");

            migrationBuilder.DropForeignKey(
                name: "fk_lifestage_company_company_id",
                schema: "health",
                table: "lifestage");

            migrationBuilder.DropForeignKey(
                name: "fk_analytic_source_company_company_id",
                schema: "triggers",
                table: "analytic_source");

            migrationBuilder.DropForeignKey(
                name: "fk_dashboard_company_company_id",
                schema: "triggers",
                table: "dashboard");

            migrationBuilder.DropForeignKey(
                name: "fk_report_company_company_id",
                schema: "triggers",
                table: "report");

            migrationBuilder.DropForeignKey(
                name: "fk_trigger_company_company_id",
                schema: "triggers",
                table: "trigger");

            migrationBuilder.DropIndex(
                name: "ix_trigger_company_id",
                schema: "triggers",
                table: "trigger");

            migrationBuilder.DropIndex(
                name: "ix_report_company_id",
                schema: "triggers",
                table: "report");

            migrationBuilder.DropIndex(
                name: "ix_dashboard_company_id",
                schema: "triggers",
                table: "dashboard");

            migrationBuilder.DropIndex(
                name: "ix_analytic_source_company_id",
                schema: "triggers",
                table: "analytic_source");

            migrationBuilder.DropIndex(
                name: "ix_lifestage_company_id",
                schema: "health",
                table: "lifestage");

            migrationBuilder.DropIndex(
                name: "ix_lifecycle_company_id",
                schema: "health",
                table: "lifecycle");

           
            migrationBuilder.DropIndex(
                name: "ix_healthscore_component_company_id",
                schema: "health",
                table: "healthscore_component");

            migrationBuilder.DropIndex(
                name: "ix_healthscore_company_id",
                schema: "health",
                table: "healthscore");

            migrationBuilder.DropIndex(
                name: "ix_achievement_company_id",
                schema: "health",
                table: "achievement");

            migrationBuilder.DropIndex(
                name: "ix_account_healthscore_history_company_id",
                schema: "health",
                table: "account_healthscore_history");

            migrationBuilder.DropIndex(
                name: "ix_account_healthscore_company_id",
                schema: "health",
                table: "account_healthscore");

            migrationBuilder.DropIndex(
                name: "ix_account_health_setting_company_id",
                schema: "health",
                table: "account_health_setting");

            migrationBuilder.DropIndex(
                name: "ix_account_achievement_company_id",
                schema: "health",
                table: "account_achievement");

 
            migrationBuilder.DropIndex(
                name: "ix_comment_reference_company_id",
                schema: "file",
                table: "comment_reference");

            migrationBuilder.DropIndex(
                name: "ix_comment_company_id",
                schema: "file",
                table: "comment");

            migrationBuilder.DropIndex(
                name: "ix_attachment_reference_company_id",
                schema: "file",
                table: "attachment_reference");

            migrationBuilder.DropIndex(
                name: "ix_attachment_company_id",
                schema: "file",
                table: "attachment");

            migrationBuilder.DropIndex(
                name: "ix_subscriber_company_id",
                schema: "events",
                table: "subscriber");

            migrationBuilder.DropIndex(
                name: "ix_sfdc_integration_object_company_id",
                schema: "events",
                table: "sfdc_integration_object");

            migrationBuilder.DropIndex(
                name: "ix_sfdc_integration_error_company_id",
                schema: "events",
                table: "sfdc_integration_error");

            migrationBuilder.DropIndex(
                name: "ix_sfdc_integration_company_id",
                schema: "events",
                table: "sfdc_integration");

            migrationBuilder.DropIndex(
                name: "ix_container_version_reference_company_id",
                schema: "events",
                table: "container_version_reference");

            migrationBuilder.DropIndex(
                name: "ix_container_version_log_company_id",
                schema: "events",
                table: "container_version_log");

            migrationBuilder.DropIndex(
                name: "ix_container_version_active_history_company_id",
                schema: "events",
                table: "container_version_active_history");

            migrationBuilder.DropIndex(
                name: "ix_container_version_company_id",
                schema: "events",
                table: "container_version");

            migrationBuilder.DropIndex(
                name: "ix_container_company_id",
                schema: "events",
                table: "container");

            migrationBuilder.DropIndex(
                name: "ix_time_entry_company_id",
                schema: "engage",
                table: "time_entry");

            migrationBuilder.DropIndex(
                name: "ix_milestone_model_company_id",
                schema: "engage",
                table: "milestone_model");

            migrationBuilder.DropIndex(
                name: "ix_milestone_company_id",
                schema: "engage",
                table: "milestone");

            migrationBuilder.DropIndex(
                name: "ix_layout_section_row_company_id",
                schema: "engage",
                table: "layout_section_row");

            migrationBuilder.DropIndex(
                name: "ix_layout_section_company_id",
                schema: "engage",
                table: "layout_section");

            migrationBuilder.DropIndex(
                name: "ix_layout_company_id",
                schema: "engage",
                table: "layout");

            migrationBuilder.DropIndex(
                name: "ix_label_company_id",
                schema: "engage",
                table: "label");

            migrationBuilder.DropIndex(
                name: "ix_invoice_payment_company_id",
                schema: "engage",
                table: "invoice_payment");

            migrationBuilder.DropIndex(
                name: "ix_integration_property_company_id",
                schema: "engage",
                table: "integration_property");

            migrationBuilder.DropIndex(
                name: "ix_integration_mapping_company_id",
                schema: "engage",
                table: "integration_mapping");

            migrationBuilder.DropIndex(
                name: "ix_expected_activity_company_id",
                schema: "engage",
                table: "expected_activity");

            migrationBuilder.DropIndex(
                name: "ix_engagement_status_company_id",
                schema: "engage",
                table: "engagement_status");

            migrationBuilder.DropIndex(
                name: "ix_engagement_model_company_id",
                schema: "engage",
                table: "engagement_model");

            migrationBuilder.DropIndex(
                name: "ix_engagement_company_id",
                schema: "engage",
                table: "engagement");

            migrationBuilder.DropIndex(
                name: "ix_contract_history_company_id",
                schema: "engage",
                table: "contract_history");

            migrationBuilder.DropIndex(
                name: "ix_contract_custom_data_company_id",
                schema: "engage",
                table: "contract_custom_data");

            migrationBuilder.DropIndex(
                name: "ix_contract_company_id",
                schema: "engage",
                table: "contract");

            migrationBuilder.DropIndex(
                name: "ix_color_company_id",
                schema: "engage",
                table: "color");

            migrationBuilder.DropIndex(
                name: "ix_checklist_model_company_id",
                schema: "engage",
                table: "checklist_model");

            migrationBuilder.DropIndex(
                name: "ix_checklist_company_id",
                schema: "engage",
                table: "checklist");

            migrationBuilder.DropIndex(
                name: "ix_analytics_join_key_company_id",
                schema: "engage",
                table: "analytics_join_key");

            migrationBuilder.DropIndex(
                name: "ix_activity_type_company_id",
                schema: "engage",
                table: "activity_type");

            migrationBuilder.DropIndex(
                name: "ix_activity_status_company_id",
                schema: "engage",
                table: "activity_status");

            migrationBuilder.DropIndex(
                name: "ix_activity_lane_company_id",
                schema: "engage",
                table: "activity_lane");

            migrationBuilder.DropIndex(
                name: "ix_activity_label_company_id",
                schema: "engage",
                table: "activity_label");

            migrationBuilder.DropIndex(
                name: "ix_activity_custom_data_company_id",
                schema: "engage",
                table: "activity_custom_data");

            migrationBuilder.DropIndex(
                name: "ix_activity_contact_company_id",
                schema: "engage",
                table: "activity_contact");

            migrationBuilder.DropIndex(
                name: "ix_activity_board_company_id",
                schema: "engage",
                table: "activity_board");

            migrationBuilder.DropIndex(
                name: "ix_activity_assignment_company_id",
                schema: "engage",
                table: "activity_assignment");

            migrationBuilder.DropIndex(
                name: "ix_activity_company_id",
                schema: "engage",
                table: "activity");

            migrationBuilder.DropIndex(
                name: "ix_account_priority_company_id",
                schema: "engage",
                table: "account_priority");

            migrationBuilder.DropIndex(
                name: "ix_account_name_company_id",
                schema: "engage",
                table: "account_name");

            migrationBuilder.DropIndex(
                name: "ix_notification_recipient_company_id",
                schema: "admin",
                table: "notification_recipient");

            migrationBuilder.DropIndex(
                name: "ix_notification_company_id",
                schema: "admin",
                table: "notification");

            migrationBuilder.DropIndex(
                name: "ix_licensed_modules_company_id",
                schema: "admin",
                table: "licensed_modules");

            migrationBuilder.DropIndex(
                name: "ix_layout_section_row_company_id",
                schema: "admin",
                table: "layout_section_row");

            migrationBuilder.DropIndex(
                name: "ix_layout_section_company_id",
                schema: "admin",
                table: "layout_section");

            migrationBuilder.DropIndex(
                name: "ix_layout_company_id",
                schema: "admin",
                table: "layout");

            migrationBuilder.DropIndex(
                name: "ix_filter_company_id",
                schema: "admin",
                table: "filter");

            migrationBuilder.DropIndex(
                name: "ix_company_user_role_company_id",
                schema: "admin",
                table: "company_user_role");

            migrationBuilder.DropIndex(
                name: "ix_company_key_company_id",
                schema: "admin",
                table: "company_key");

            migrationBuilder.DropIndex(
                name: "ix_company_db_config_company_id",
                schema: "admin",
                table: "company_db_config");

            migrationBuilder.DropIndex(
                name: "ix_analytics_join_key_company_id",
                schema: "admin",
                table: "analytics_join_key");

            migrationBuilder.DropIndex(
                name: "ix_account_user_custom_data_company_id",
                schema: "admin",
                table: "account_user_custom_data");

            migrationBuilder.DropIndex(
                name: "ix_account_user_company_id",
                schema: "admin",
                table: "account_user");

            migrationBuilder.DropIndex(
                name: "ix_account_population_company_id",
                schema: "admin",
                table: "account_population");

            migrationBuilder.DropIndex(
                name: "ix_account_filter_company_id",
                schema: "admin",
                table: "account_filter");

            migrationBuilder.DropIndex(
                name: "ix_account_custom_data_company_id",
                schema: "admin",
                table: "account_custom_data");

            migrationBuilder.DropIndex(
                name: "ix_account_company_id",
                schema: "admin",
                table: "account");

            migrationBuilder.DropIndex(
                name: "ix_access_log_company_id",
                schema: "admin",
                table: "access_log");
        }
    }
}
