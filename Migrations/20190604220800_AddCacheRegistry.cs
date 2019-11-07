using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bolstra.Migrations
{
    public partial class AddCacheRegistry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "cache_registry",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    table_schema = table.Column<string>(nullable: true),
                    table_name = table.Column<string>(nullable: true),
                    action = table.Column<string>(nullable: true),
                    company_id = table.Column<long>(nullable: true),
                    last_modified_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("cache_registry_pkey", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cache_registry_table_name_table_schema",
                schema: "public",
                table: "cache_registry",
                columns: new[] { "table_name", "table_schema" },
                unique: true);

            CreateTriggers(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            DropTriggers(migrationBuilder);

            migrationBuilder.DropTable(
                name: "cache_registry",
                schema: "public");
        }

        private void CreateTriggers(MigrationBuilder migrationBuilder)
        {
            string sql = @"CREATE OR REPLACE FUNCTION public.update_cache_registry_trigger()
                        RETURNS TRIGGER
                    AS $$
                    DECLARE cid INT8 = 0;
                    BEGIN
                        IF TG_OP = 'INSERT' THEN
                            cid = NEW.company_id;
                        ELSEIF OLD.company_id IS NOT NULL then
                            cid = OLD.company_id;
                        END IF;

                        update public.cache_registry 
                        set last_modified_at = 'now', action = TG_OP, company_id = cid  
                        where table_name = TG_TABLE_NAME and table_schema = TG_TABLE_SCHEMA;

                        RETURN NULL;
                    END;
                    $$
                    LANGUAGE plpgsql;";

            migrationBuilder.Sql(sql);

            sql = @"CREATE OR REPLACE FUNCTION public.register_cache_trigger()
                        RETURNS TRIGGER
                    AS $$
                    BEGIN
                        IF tg_op = 'INSERT' THEN
                            EXECUTE format('create trigger cache_trigger after insert
                                or delete
                                or update
                                on
                                %s for each row execute procedure update_cache_registry_trigger()', new.table_schema || '.' || new.table_name);
                        ELSIF tg_op = 'DELETE' THEN
                            EXECUTE format('drop trigger cache_trigger on %s', old.table_schema || '.' || old.table_name);
                        ELSE
                            EXECUTE pg_notify('CacheChannel', new.table_schema || '.' || new.table_name || '.' || new.company_id);
                        END IF;

                        RETURN NULL;
                    END;
                    $$
                    LANGUAGE plpgsql;";

            migrationBuilder.Sql(sql);

            sql = @"create trigger cache_registry_change after insert
                or delete
                or update
                on
                public.cache_registry for each row execute procedure register_cache_trigger();";

            migrationBuilder.Sql(sql);

            // Add Cache Registry for the given tableschema and tablename
            sql = @"CREATE OR REPLACE FUNCTION public.add_cache_registry_func(tableschema text, tablename text)
                    RETURNS text
                    AS $$
                    DECLARE cnt int = 0;
                    BEGIN
                        SELECT count(*) into cnt
                        FROM information_schema.tables
                        WHERE table_schema = tableschema AND table_name = tablename
                        AND table_type='BASE TABLE';
                       
                        IF cnt > 0 THEN
                            INSERT INTO public.cache_registry (table_schema, table_name)           
                            SELECT tableschema, tablename
                            WHERE NOT EXISTS (
                            SELECT 1 from public.cache_registry WHERE table_schema = tableschema and table_name = tablename);
                        END IF;

                        RETURN NULL;
                    END;
                    $$
                    LANGUAGE plpgsql;";

            migrationBuilder.Sql(sql);

            AddCacheRegistries(migrationBuilder);

        }

        private void AddCacheRegistries(MigrationBuilder migrationBuilder)
        {
            // Add Cache Registry
            migrationBuilder.Sql("SELECT public.add_cache_registry_func('engage', 'activity_type')");
            migrationBuilder.Sql("SELECT public.add_cache_registry_func('engage', 'activity_status')");
            migrationBuilder.Sql("SELECT public.add_cache_registry_func('admin', 'account')");
            migrationBuilder.Sql("SELECT public.add_cache_registry_func('admin', 'account_custom_attribute')");
            migrationBuilder.Sql("SELECT public.add_cache_registry_func('admin', 'account_user_custom_attribute')");
            migrationBuilder.Sql("SELECT public.add_cache_registry_func('engage', 'activity_custom_attribute')");
            migrationBuilder.Sql("SELECT public.add_cache_registry_func('engage', 'contract_custom_attribute')");
        }

        private void DropTriggers(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.cache_registry");

            migrationBuilder.Sql("drop TRIGGER if exists cache_registry_change on public.cache_registry");
            migrationBuilder.Sql("drop FUNCTION if exists public.add_cache_registry_func()");
            migrationBuilder.Sql("drop FUNCTION if exists public.register_cache_trigger()");
            migrationBuilder.Sql("drop FUNCTION if exists public.update_cache_registry_trigger()");
        }
    }
}
