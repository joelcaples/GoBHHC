using GoBHHC.Shared.Models;
using System;
using System.Collections.Generic;

namespace GoBHHC.Repository {
    public interface IListMgrRepository {

        public List<IListMgrItem> GetListMgrItems(string listKey);

        public bool UpdateListMgrItem(IListMgrItem listMgrItem);

        public bool DeleteListMgrItem(string listKey);

        public bool AddListMgrItem(IListMgrItem listMgrItem);
    }
}
