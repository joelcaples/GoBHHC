﻿using System.Data.SQLite;
using System.IO;

using NUnit.Framework;

using GoBHHC.Shared.Models;

namespace GoBHHC.Tests {

    [SetUpFixture]
    public abstract class BaseTestFixture {

        private const string DB_PATH = "test-database.db";

        protected SQLiteConnection _connection;

        [OneTimeSetUp]
        public void GlobalSetup() {
            _connection = CreateConnection();
        }

        private SQLiteConnection CreateConnection() {

            var doCreate = false;

            if (!File.Exists(DB_PATH)) {
                doCreate = true;
            }

            // Create a new database connection:
            var connection = new SQLiteConnection(@"Data Source=" + DB_PATH + ";Version=3;Compress=True;");

            // Open the connection:
            connection.Open();

            if (doCreate) {
                CreateDb(connection);
            }

            return connection;
        }

        private void CreateDb(SQLiteConnection connection) {
            SQLiteCommand sqlite_cmd;
            string sql = "CREATE TABLE ListMgrItems (ListMgrID INTEGER PRIMARY KEY AUTOINCREMENT, Description VARCHAR(255))";
            sqlite_cmd = connection.CreateCommand();
            sqlite_cmd.CommandText = sql;
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO ListMgrItems (Description) VALUES ('FREE BEER');";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO ListMgrItems (Description) VALUES ('LIFETIME SUBSCRIPTION TO OK MAGAZINE');";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO ListMgrItems (Description) VALUES ('GET TO SHARE AN OFFICE WITH WARREN');";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO ListMgrItems (Description) VALUES ('LOCATION CLOSE TO QUAINT EATERIES');";
            sqlite_cmd.ExecuteNonQuery();
        }
    }
}