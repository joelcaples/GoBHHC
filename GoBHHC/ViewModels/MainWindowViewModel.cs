﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using GoBHHC.Commands;
using GoBHHC.Repository;
using GoBHHC.Shared.Interfaces;
using GoBHHC.Shared.Models;

namespace GoBHHC.ViewModels {

    public class MainWindowViewModel : INotifyPropertyChanged {

        private readonly IListMgrRepository _repository;

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

            foreach(var item in ListMgrItemsList) {
                item.PropertyChanged += ListMgrItemUpdated;
            }

            ListMgrItemsCollectionViewSource = new CollectionViewSource {
                Source = ListMgrItemsList
            };
            OnPropertyChanged("ListMgrItemsCollectionViewSource");
        }

        private void ListMgrItemUpdated(object sender, PropertyChangedEventArgs e) {
            _repository.UpdateListMgrItem((IListMgrItem)sender);
        }

        public List<IListMgrItem> ListMgrItemsList { get; private set; }

        public CollectionViewSource ListMgrItemsCollectionViewSource { get; private set;}

        private ICommand _refreshDataCommand;
        public ICommand RefreshDataCommand {
            get {
                return _refreshDataCommand ?? (_refreshDataCommand = new RelayCommand(lmi => {
                    LoadListMgrItemsList();
                }));
            }
        }


        private ICommand _deleteCommand;
        public ICommand DeleteCommand {
            get {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(lmi => {
                    _repository.DeleteListMgrItem(((IListMgrItem)lmi).ListMgrID);
                    LoadListMgrItemsList();
                }));
            }
        }

        private ICommand _addItemCommand;
        public ICommand AddItemCommand {
            get {
                return _addItemCommand ?? (_addItemCommand = new RelayCommand(lmi => {
                    _repository.AddListMgrItem(new ListMgrItem() { Description = "New Item" });
                    LoadListMgrItemsList();
                }));
            }
        }

        private ICommand _buildDemoDataCommand;
        public ICommand BuildDemoDataCommand {
            get {
                return _buildDemoDataCommand ?? (_buildDemoDataCommand = new RelayCommand(lmi => {
                    _repository.InsertDemoData();
                    LoadListMgrItemsList();
                }));
            }
        }
    }
}
