using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class ModifyAccountHealthscoreTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"CREATE OR REPLACE FUNCTION health.update_account_healthscore_current_value_trigger()
	                        RETURNS TRIGGER
                        AS $$
                        DECLARE
                            hs health.healthscore%rowtype;
                            newrange text;
                        begin
                            if new.current_value != old.current_value or
                                (old.current_value is null and new.current_value is not null) or
                                (old.current_value is not null and new.current_value is null) then
                                -- get healthscore record
                                select * from health.healthscore into hs where id = new.healthscore_id;
                                newrange = health.healthScoreRange(new.current_value, hs.range_low, hs.range_bad, hs.range_good, hs.range_high);
                               	if (newrange != new.range) or 
                               		(newrange is null and new.range is not null) or 
                               		(newrange is not null and new.range is null) then
                                	update health.account_healthscore
                                    	set range = newrange
                                    	where id = new.id;
                                end if;
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
