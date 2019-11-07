using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddUserIdColumnToCompanyUser
    {
        private void UpdateCompanyUserTable(MigrationBuilder migrationBuilder)
        {
            string sql = @"UPDATE admin.company_user set user_id = id";
            migrationBuilder.Sql(sql);
        }
    }
}
