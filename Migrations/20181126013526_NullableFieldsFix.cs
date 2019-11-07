using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolstra.Migrations
{
    public partial class NullableFieldsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Do nothing, generated code is removed because no DB change is desired.
            // This migration is fixing Model/DB mismatached for nullable fields
            // which could cause "Column is Null" error when retrieve data from DB using EF
            // in cases where Model has non-nullable property while DB field is nullable
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Do nothing.
        }
    }
}