using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AccountHSTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            this.DropTrigger(migrationBuilder);
            this.CreateTrigger(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            this.DropTrigger(migrationBuilder);
        }

        private void CreateTrigger(MigrationBuilder migrationBuilder)
        {
            string sql = @"CREATE OR REPLACE FUNCTION health.update_account_healthscore_current_value_trigger()
	                        RETURNS TRIGGER
                        AS $$
                        DECLARE
                            hs health.healthscore%rowtype;
                        begin
                            if new.current_value != old.current_value then
                                -- get healthscore record
                                select * from health.healthscore into hs where id = new.healthscore_id;
                                update health.account_healthscore
                                    set range = health.healthScoreRange(new.current_value, hs.range_low, hs.range_bad, hs.range_good, hs.range_high)
                                    where id = new.id;
                            end if;

                            RETURN NULL;
                        END;
                        $$
                        LANGUAGE plpgsql;";

            migrationBuilder.Sql(sql);

            sql = @"CREATE TRIGGER update_account_healthscore_range_on_current_value_change 
                    AFTER UPDATE 
                    ON health.account_healthscore FOR EACH ROW 
                    EXECUTE procedure health.update_account_healthscore_current_value_trigger()";

            migrationBuilder.Sql(sql);
        }

        private void DropTrigger(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop TRIGGER if exists update_account_healthscore_range_on_current_value_change on health.account_healthscore");
            migrationBuilder.Sql("drop FUNCTION if exists health.update_account_healthscore_current_value_trigger()");
        }
    }
}
