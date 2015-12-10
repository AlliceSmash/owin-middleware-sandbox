using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using testkatana.Properties;
using Simple.Data;

namespace testkatana
{
    public class Bootstrap
    {
        public void InstallDatabase()
        {
            var connStr =
                ConfigurationManager.ConnectionStrings["katana-db"].ConnectionString;
            this.InstallDatabase(connStr);
            InitiateDBEntries(connStr);
        }

        public void InstallDatabase(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            builder.InitialCatalog = "Master";
            using (var conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    var schemaSql = Resources.TestKatanaDbSchema;
                    foreach (var sql in schemaSql.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void InitiateDBEntries(string connectionString)
        {
            var db = Database.OpenConnection(connectionString);
            db.Company.Insert(Id: "1", Name: "Microsoft");
        }

        public void UninstallDatabase()
        {
            var connStr =
                ConfigurationManager.ConnectionStrings["running-journal"].ConnectionString;
            this.UninstallDatabase(connStr);
        }

        public void UninstallDatabase(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            builder.InitialCatalog = "Master";
            using (var conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();

                var dropCmd = @"
                    IF EXISTS (SELECT name
                               FROM master.dbo.sysdatabases
                               WHERE name = N'RunningJournal')
                    DROP DATABASE [RunningJournal];";
                using (var cmd = new SqlCommand(dropCmd, conn))
                    cmd.ExecuteNonQuery();
            }
        }
    }
}
