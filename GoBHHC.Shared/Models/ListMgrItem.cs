using GoBHHC.Shared.Interfaces;

namespace GoBHHC.Shared.Models {
    public class ListMgrItem : IListMgrItem {
        public int ListMgrID { get; set; }
        public string Description { get; set; }
    }
}
