using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

using Dapper;
using GoBHHC.Shared;
using GoBHHC.Shared.Interfaces;
using GoBHHC.Shared.Models;

namespace GoBHHC.Repository {

    public class ListMgrRepository : IListMgrRepository {

        protected SQLiteConnection _connection;

        public ListMgrRepository(SQLiteConnection connection) {
            _connection = connection;
        }


        public IListMgrItem AddListMgrItem(IListMgrItem listMgrItem) {
            var sql = @"
                INSERT INTO ListMgrItems (Description) VALUES (@Description);
                SELECT last_insert_rowid()";

            var newId = _connection.Query<int>(sql, listMgrItem).Single();

            return GetListMgrItem(newId);
        }

        public int DeleteListMgrItem(int listMgrID) {
            var sql = @"DELETE FROM ListMgrItems WHERE ListMgrID = @ListMgrID";

            var affectedRows = _connection.Execute(
                sql,
                new ListMgrItem() {
                    ListMgrID = listMgrID
                });

            if (affectedRows == 0)
                throw new NotFoundException();

            return affectedRows;
        }

        public List<IListMgrItem> GetListMgrItems() {

            var sql = "SELECT ListMgrID, Description FROM ListMgrItems ORDER BY Description";

            var result = _connection.Query<ListMgrItem>(sql).ToList<IListMgrItem>();

            return result;
        }

        public IListMgrItem GetListMgrItem(int listMgrID) {

            var sql = "SELECT ListMgrID, Description FROM ListMgrItems WHERE ListMgrID = @ListMgrID";

            var result = _connection.Query<ListMgrItem>(
                sql, 
                new ListMgrItem() { 
                    ListMgrID = listMgrID 
                }).Single();

            return result;
        }

        public int UpdateListMgrItem(IListMgrItem listMgrItem) {

            var sql = @"UPDATE ListMgrItems SET Description = @Description WHERE ListMgrID = @ListMgrID";

            var affectedRows = _connection.Execute(sql, listMgrItem);

            if (affectedRows == 0)
                throw new NotFoundException();

            return affectedRows;
        }

        public void BuildSchema() {

            SQLiteCommand cmd;
            cmd = _connection.CreateCommand();

            cmd.CommandText = "CREATE TABLE ListMgrItems (ListMgrID INTEGER PRIMARY KEY AUTOINCREMENT, Description VARCHAR(255))";
            cmd.ExecuteNonQuery();
        }

        public void InsertDemoData() {

            SQLiteCommand cmd;
            cmd = _connection.CreateCommand();

            cmd.CommandText = "DELETE FROM ListMgrItems;";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO ListMgrItems (Description) VALUES ('FREE BEER');";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO ListMgrItems (Description) VALUES ('LIFETIME SUBSCRIPTION TO OK MAGAZINE');";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO ListMgrItems (Description) VALUES ('GET TO SHARE AN OFFICE WITH WARREN');";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO ListMgrItems (Description) VALUES ('LOCATION CLOSE TO QUAINT EATERIES');";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO ListMgrItems (Description) VALUES ('BECAUSE REASONS');";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO ListMgrItems (Description) VALUES ('THE DEAFENING SILENCE');";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO ListMgrItems (Description) VALUES ('OMAHA - It''s not for everyone');";
            cmd.ExecuteNonQuery();
        }
    }
}
