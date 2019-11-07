using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class HealthscoreFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            this.DropFunction(migrationBuilder);
            this.CreateFunction(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            this.DropFunction(migrationBuilder);
        }

        private void CreateFunction(MigrationBuilder migrationBuilder)
        {
            string sql = @"CREATE OR REPLACE FUNCTION health.getHealthscoreRange(value double precision, hsId int8)
                             RETURNS text
                             LANGUAGE plpgsql
                            AS $function$
                                DECLARE
                                    hs health.healthscore%rowtype;
                                begin
                                    -- get healthscore record
                                    select * from health.healthscore into hs where id = hsId;
                                    return health.healthScoreRange(value, hs.range_low, hs.range_bad, hs.range_good, hs.range_high);
                                END;
                            $function$;";

            migrationBuilder.Sql(sql);
        }

        private void DropFunction(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop FUNCTION if exists health.getHealthscoreRange()");
        }
    }
}
