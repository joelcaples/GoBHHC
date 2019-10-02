using System;
using System.ComponentModel;

namespace GoBHHC.Shared.Interfaces {

    public interface IListMgrItem : INotifyPropertyChanged {
        int ListMgrID { get; set; }
        string Description { get; set; }
    }
}
