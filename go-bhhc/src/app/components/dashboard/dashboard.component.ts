import { Component, OnInit } from '@angular/core';
import { ListMgrItem } from '../../models/list-mgr-item';
import { ListMgrItemService } from '../../services/list-mgr-item-service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: [ './dashboard.component.css' ]
})
export class DashboardComponent implements OnInit {
  listMgrItems: ListMgrItem[] = [];

  constructor(private listMgrItemService: ListMgrItemService) { }

  ngOnInit() {
    this.getListMgrItems();
  }

  getListMgrItems(): void {
    this.listMgrItemService.getListMgrItems()
      .subscribe(listMgrItems => this.listMgrItems = listMgrItems.slice(1, 5));
  }
}