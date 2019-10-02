using System;
using System.Collections.Generic;

using GoBHHC.Shared.Interfaces;

namespace GoBHHC.Repository {
    public interface IListMgrRepository {

        public IListMgrItem AddListMgrItem(IListMgrItem listMgrItem);

        public int DeleteListMgrItem(int listMgrID);

        public List<IListMgrItem> GetListMgrItems();

        public IListMgrItem GetListMgrItem(int listMgrID);

        public int UpdateListMgrItem(IListMgrItem listMgrItem);

        public void InsertDemoData();

    }
}
