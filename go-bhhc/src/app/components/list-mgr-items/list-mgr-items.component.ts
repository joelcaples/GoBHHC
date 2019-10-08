import { Component, OnInit } from '@angular/core';

import { ListMgrItem } from '../../models/list-mgr-item';
import { ListMgrItemService } from '../../services/list-mgr-item-service';

@Component({
  selector: 'app-list-mgr-items',
  templateUrl: './list-mgr-items.component.html',
  styleUrls: ['./list-mgr-items.component.css']
})
export class ListMgrItemsComponent implements OnInit {

  selectedListMgrItem: ListMgrItem;

  listMgrItems: ListMgrItem[];

  constructor(private listMgrItemService: ListMgrItemService) { }

  ngOnInit() {
    this.getListMgrItems();
  }

  onSelect(listMgrItem: ListMgrItem): void {
    this.selectedListMgrItem = listMgrItem;
  }

  getListMgrItems(): void {
    this.listMgrItemService.getListMgrItems()
        .subscribe(listMgrItems => this.listMgrItems = listMgrItems);
  }
}