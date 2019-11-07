using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class NextRenewalDataTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ModifyTriggerFunc(migrationBuilder);

            MigrateData(migrationBuilder);
        }

        private void ModifyTriggerFunc(MigrationBuilder migrationBuilder)
        {
            string sql = @"CREATE OR REPLACE FUNCTION update_account_arr_mrr_func(aid INT8)
                RETURNS INT8
                AS $$
                declare mrr FLOAT:= 0;
                declare nextrenewal Date;
                BEGIN
                    mrr:= COALESCE((select sum(mrr_value)
                                       from engage.contract
                                       where is_expired = false and type ilike 'recurring%' and account_id = aid
                                       group by account_id)
                                , 0);
                               
                    nextrenewal:= COALESCE((select renewed_at from engage.contract 
                              where is_expired = false and type ilike 'recurring%' and account_id = aid
                              and renewed_at > 'now' order by renewed_at limit 1)
                              , null);
                             
                    UPDATE admin.ACCOUNT SET MRR_SUM = mrr, ARR_SUM = 12 * mrr, next_renewal_date = nextrenewal WHERE id = aid;
                    RETURN aid;
                END;
                $$ LANGUAGE plpgsql;";

            migrationBuilder.Sql(sql);
        }

        private void MigrateData(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT public.update_account_arr_mrr_func(id) from admin.account";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sql = @"CREATE OR REPLACE FUNCTION update_account_arr_mrr_func(aid INT8)
                RETURNS INT8
                AS $$
                declare mrr FLOAT:= 0;
                BEGIN
                    mrr:= COALESCE((select sum(mrr_value)
                                       from engage.contract
                                       where is_expired = false and type ilike 'recurring%' and account_id = aid
                                       group by account_id)
                                , 0);

                    UPDATE admin.ACCOUNT SET MRR_SUM = mrr, ARR_SUM = 12 * mrr WHERE id = aid;
                    RETURN aid;
                END;
                $$ LANGUAGE plpgsql;";

            migrationBuilder.Sql(sql);
        }
    }
}
