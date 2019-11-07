using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class FixUpdateAccountArrMrrBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"CREATE OR REPLACE FUNCTION update_account_arr_mrr_func(aid INT8)
                RETURNS INT8
                AS $$
                declare val FLOAT:= 0;
                BEGIN
                    val:= COALESCE((select sum(mrr_value)
                                       from engage.contract
                                       where is_expired = false
                                       and started_at <= now() 
                                       and type ilike 'recurring%'
                                       and account_id = aid
                                       group by account_id)
                                , 0);
                    UPDATE admin.ACCOUNT SET MRR_SUM = val, ARR_SUM = 12 * val WHERE id = aid;
                    RETURN aid;
                END;
                $$ LANGUAGE plpgsql;";

            migrationBuilder.Sql(sql);

            MigrateData(migrationBuilder);
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
                declare val FLOAT:= 0;
                BEGIN
                    val:= COALESCE((select sum(mrr_value)
                                       from engage.contract
                                       where is_expired = false and type ilike 'recurring%' and account_id = aid
                                       group by account_id)
                                , 0);
                    UPDATE admin.ACCOUNT SET MRR_SUM = val, ARR_SUM = 12 * val WHERE id = aid;
                    RETURN aid;
                END;
                $$ LANGUAGE plpgsql;";

            migrationBuilder.Sql(sql);
            MigrateData(migrationBuilder);
        }
    }
}
