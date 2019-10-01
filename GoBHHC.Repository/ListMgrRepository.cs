using System;
using System.Collections.Generic;
using System.Data.SQLite;

using GoBHHC.Shared.Models;

namespace GoBHHC.Repository {

    public class ListMgrRepository : IListMgrRepository {

        protected SQLiteConnection _context;

        public ListMgrRepository(SQLiteConnection context) {
            _context = context;
        }


        public bool AddListMgrItem(IListMgrItem listMgrItem) {
            throw new NotImplementedException();
        }

        public bool DeleteListMgrItem(string listKey) {
            throw new NotImplementedException();
        }

        public List<IListMgrItem> GetListMgrItems(string listKey) {
            throw new NotImplementedException();
        }

        public bool UpdateListMgrItem(IListMgrItem listMgrItem) {
            throw new NotImplementedException();
        }
    }
}
