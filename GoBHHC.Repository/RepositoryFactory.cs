using System.Data.SQLite;
using System.IO;

namespace GoBHHC.Repository {
    public static class RepositoryFactory {

        private const string DB_PATH = "database.db";

        public static IListMgrRepository GetRepository() {

            var doCreate = false;

            if (!File.Exists(DB_PATH))
                doCreate = true;

            // Create a new database connection:
            var connection = new SQLiteConnection(@"Data Source=" + DB_PATH + ";Version=3;Compress=True;");

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
