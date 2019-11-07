using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class ResetUserIdSequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Reset user_id seq so next id is not start from 1
            string sql = @"SELECT setval('admin.user_id_seq', (SELECT last_value FROM admin.company_user_id_seq))";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
