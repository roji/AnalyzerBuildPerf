using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class FixUpdateAccountArrMrrTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            DropTrigger(migrationBuilder);
            CreateTrigger(migrationBuilder);
        }

        private void CreateTrigger(MigrationBuilder migrationBuilder)
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

            sql = @"CREATE OR REPLACE FUNCTION update_account_arr_mrr_trigger()
                RETURNS TRIGGER
                AS $$
                DECLARE
                     aid INT8 := 0;
                BEGIN
                    IF tg_op = 'INSERT' THEN
                        aid := NEW.account_id;
                    ELSE
                        aid := OLD.account_id;
                    END IF;

                    PERFORM public.update_account_arr_mrr_func(aid);

                    RETURN NULL;
                END;
                $$
                LANGUAGE plpgsql;";

            migrationBuilder.Sql(sql);

            sql = @"CREATE TRIGGER update_account_arr_mrr 
                    AFTER INSERT OR UPDATE OR DELETE 
                    ON engage.contract FOR EACH ROW 
                    EXECUTE PROCEDURE update_account_arr_mrr_trigger()";

            migrationBuilder.Sql(sql);

            MigrateData(migrationBuilder);
        }

        private void MigrateData(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT public.update_account_arr_mrr_func(id) from admin.account";
            migrationBuilder.Sql(sql);
        }

        private void DropTrigger(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS calculate_account_arr_mrr_trigger()");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS calculate_account_arr_mrr_func(INT8)");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS update_account_arr_mrr on engage.contract");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            DropTrigger(migrationBuilder);
        }
    }
}
