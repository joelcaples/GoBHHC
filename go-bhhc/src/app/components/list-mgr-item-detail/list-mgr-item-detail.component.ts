import { Component, OnInit, Input } from '@angular/core';
import { ListMgrItem } from 'src/app/models/list-mgr-item';

@Component({
  selector: 'app-list-mgr-item-detail',
  templateUrl: './list-mgr-item-detail.component.html',
  styleUrls: ['./list-mgr-item-detail.component.css']
})
export class ListMgrItemDetailComponent implements OnInit {
  @Input() 'list-mgr-item': ListMgrItem;

  constructor() { }

  ngOnInit() {
  }

}
