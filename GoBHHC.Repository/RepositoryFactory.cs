﻿using Microsoft.Extensions.Configuration;
using System;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace GoBHHC.Repository {

    public enum ListMgrEnvironment {
        Production,
        Test
    }

    public static class RepositoryFactory {

        public static IListMgrRepository GetRepository(ListMgrEnvironment environment) {

            var doCreate = false;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var csBuilder = new DbConnectionStringBuilder {
                ConnectionString = configuration.GetConnectionString(Enum.GetName(typeof(ListMgrEnvironment), environment))
            };

            if (!File.Exists((string)csBuilder["Data Source"]))
                doCreate = true;


            // Create a new database connection:
            var connection = new SQLiteConnection(csBuilder.ConnectionString);

            // Open the connection:
            connection.Open();

            var repo = new ListMgrRepository(connection);

            if (doCreate) {
                repo.BuildSchema();
                repo.InsertDemoData();
            }

            return repo;
        }
    }
}
