using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class AddUserTable
    {
        private void MigrateCompanyUserToUserTable(MigrationBuilder migrationBuilder)
        {
            string sql = @"INSERT INTO admin.user (
                    id,
                    created_by,
                    created_at,
                    last_modified_by,
                    last_modified_at,
                    email,
                    first_name,
                    last_name,
                    color,
                    is_saas_admin,
                    is_service_user
                )
                SELECT
                    id,
                    created_by,
                    created_at,
                    last_modified_by,
                    last_modified_at,
                    email,
                    first_name,
                    last_name,
                    color,
                    is_saas_admin,
                    is_service_user
                FROM admin.company_user";
            migrationBuilder.Sql(sql);
        }

        private void UpdateCompanyUserTable(MigrationBuilder migrationBuilder)
        {
            string sql = @"UPDATE admin.company_user set user_id = id";
            migrationBuilder.Sql(sql);
        }
    }
}
