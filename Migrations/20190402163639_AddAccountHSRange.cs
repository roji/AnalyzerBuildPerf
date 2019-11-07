using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddAccountHSRange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "range",
                schema: "health",
                table: "account_healthscore",
                maxLength: 15,
                nullable: true);

            this.DropTrigger(migrationBuilder);
            this.CreateTrigger(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "range",
                schema: "health",
                table: "account_healthscore");

            DropTrigger(migrationBuilder);
        }

        private void CreateTrigger(MigrationBuilder migrationBuilder)
        {
            string sql = @"create or replace function health.healthScoreRange(currentValue float8, rangeLow float8, rangeBad float8, rangeGood float8, rangeHigh float8)
	                            returns text
                            as
                            $$
                            DECLARE 
                            begin
	                            if currentValue is null then
		                            return 'N/A';
	                            end if;    

                                if rangeLow < rangeHigh then
                                    -- increasing value
                                    if currentValue >= rangeGood then
                                        return 'High';
                                    elseif currentValue >= rangeBad then
                                        return 'Medium';
                                    else
                                        return 'Low';
                                    end if;
                                else
                                    -- increasing value
                                    if currentValue <= rangeGood then
                                        return 'High';
                                    elseif currentValue <= rangeBad then
                                        return 'Medium';
                                    else
                                        return 'Low';
                                    end if;
                                end if;
                            END;
                            $$ 
                            LANGUAGE plpgsql;";

            migrationBuilder.Sql(sql);

            sql = @"CREATE OR REPLACE FUNCTION health.UpdateAccountHealthScore(healthscoreId int8) 
                      RETURNS VOID 
                    AS
                    $$
                    DECLARE 
                       hs health.healthscore%rowtype;
                       ahs health.account_healthscore%rowtype;
                    begin
                        select * from health.healthscore into hs where id = healthscoreId;
	
                        FOR ahs in SELECT * FROM health.account_healthscore where healthscore_id = healthscoreId loop
		                    update health.account_healthscore 
			                    set range = health.healthScoreRange(ahs.current_value, hs.range_low, hs.range_bad, hs.range_good, hs.range_high)
		                    where id = ahs.id;
                        END LOOP;
                    END;
                    $$ 
                    LANGUAGE plpgsql;";

            migrationBuilder.Sql(sql);

            sql = @"CREATE OR REPLACE FUNCTION health.update_account_healthscore_trigger()
	                    RETURNS TRIGGER
                    AS $$
                    DECLARE
                    begin
                        PERFORM health.UpdateAccountHealthScore(OLD.id);

                        RETURN NULL;
                    END;
                    $$
                    LANGUAGE plpgsql;";

            migrationBuilder.Sql(sql);

            sql = @"CREATE TRIGGER update_account_healthscore_range 
                    AFTER UPDATE 
                    ON health.healthscore FOR EACH ROW 
                    EXECUTE procedure health.update_account_healthscore_trigger()";

            migrationBuilder.Sql(sql);

            MigrateData(migrationBuilder);
        }

        private void MigrateData(MigrationBuilder migrationBuilder)
        {
            string sql = @"CREATE OR REPLACE FUNCTION health.MigrateAccountHealthScore() 
                              RETURNS VOID 
                            AS
                            $$
                            DECLARE 
                               hs health.healthscore%rowtype;
                            begin
                                FOR hs in SELECT * FROM health.healthscore loop
	                                PERFORM health.UpdateAccountHealthScore(hs.id);
                                END LOOP;
                            END;
                            $$ 
                            LANGUAGE plpgsql;";

            migrationBuilder.Sql(sql);

            sql = @"select health.MigrateAccountHealthScore()";
            migrationBuilder.Sql(sql);

            sql = @"drop function health.MigrateAccountHealthScore()";
            migrationBuilder.Sql(sql);
        }

        private void DropTrigger(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop trigger if exists update_account_healthscore_range on health.healthscore");
            migrationBuilder.Sql("drop function if exists health.update_account_healthscore_trigger()");
            migrationBuilder.Sql("drop function if exists health.UpdateAccountHealthScore(int8)");
            migrationBuilder.Sql("drop function if exists health.healthScoreRange(float8, float8, float8, float8, float8)");
        }
    }
}
