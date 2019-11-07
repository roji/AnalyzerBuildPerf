using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class FixAccountHealthScoreTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"CREATE OR REPLACE FUNCTION health.update_account_healthscore_current_value_trigger()
	                        RETURNS TRIGGER
                        AS $$
                        DECLARE
                            hs health.healthscore%rowtype;
                        begin
                            if new.current_value != old.current_value or old.current_value is null then
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
