import { Component, OnInit } from '@angular/core';

import { ListMgrItem } from '../../models/list-mgr-item';
import { ListMgrItemService } from '../../services/list-mgr-item-service';

@Component({
  selector: 'app-list-mgr-items',
  templateUrl: './list-mgr-items.component.html',
  styleUrls: ['./list-mgr-items.component.css']
})
export class ListMgrItemsComponent implements OnInit {
  listMgrItems: ListMgrItem[];

  constructor(private listMgrItemService: ListMgrItemService) { }

  ngOnInit() {
    this.getListMgrItems();
  }

  getListMgrItems(): void {
    this.listMgrItemService.getListMgrItems()
    .subscribe(listMgrItems => this.listMgrItems = listMgrItems);
  }

  add(description: string): void {
    description = description.trim();
    if (!description) { return; }
    this.listMgrItemService.addListMgrItem({ description } as ListMgrItem)
      .subscribe(listMgrItem => {
        this.listMgrItems.push(listMgrItem);
      });
  }

  delete(listMgrItem: ListMgrItem): void {
    this.listMgrItems = this.listMgrItems.filter(h => h !== listMgrItem);
    this.listMgrItemService.deleteListMgrItem(listMgrItem).subscribe();
  }

}