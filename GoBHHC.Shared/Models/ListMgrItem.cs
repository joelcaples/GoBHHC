using GoBHHC.Shared.Interfaces;
using System.ComponentModel;

namespace GoBHHC.Shared.Models {
    public class ListMgrItem : IListMgrItem, INotifyPropertyChanged {
        public int ListMgrID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string _description;
        public string Description {
            get {
                return _description;
            }
            set {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
    }
}
