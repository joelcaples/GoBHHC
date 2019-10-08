import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { ListMgrItem } from 'src/app/models/list-mgr-item';
import { ListMgrItemService} from 'src/app/services/list-mgr-item-service'

@Component({
  selector: 'app-list-mgr-item-detail',
  templateUrl: './list-mgr-item-detail.component.html',
  styleUrls: ['./list-mgr-item-detail.component.css']
})
export class ListMgrItemDetailComponent implements OnInit {
  'listMgrItem': ListMgrItem;

  constructor(
    private route: ActivatedRoute,
    private listMgrItemService: ListMgrItemService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getListMgrItem();
  }

  getListMgrItem(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.listMgrItemService.getListMgrItem(id)
      .subscribe(listMgrItem => this.listMgrItem = listMgrItem);
  }

  goBack(): void {
    this.location.back();
  }
}