using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;

using GoBHHC.Repository;
using GoBHHC.Shared.Interfaces;

namespace GoBHHC.ViewModels {

    public class MainWindowViewModel : INotifyPropertyChanged {

        private IListMgrRepository _repository;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel(IListMgrRepository repository) {
            _repository = repository;
            LoadListMgrItemsList();
        }
        protected void OnPropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void LoadListMgrItemsList() {
            ListMgrItemsList = _repository.GetListMgrItems();
            ListMgrItemsCollectionViewSource = new CollectionViewSource();
            ListMgrItemsCollectionViewSource.Source = ListMgrItemsList;
            OnPropertyChanged("ListMgrItemsCollectionViewSource");
        }

        private List<IListMgrItem> ListMgrItemsList { get; set; }

        public CollectionViewSource ListMgrItemsCollectionViewSource { get; private set;}

    }
}
