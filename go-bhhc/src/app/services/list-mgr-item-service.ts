import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';

import { ListMgrItem } from '../models/list-mgr-item';
import { LISTMGRITEMS } from '../mocks/mock-list-mgr-items';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root',
})
export class ListMgrItemService {

  constructor(private messageService: MessageService) { }

  getListMgrItems(): Observable<ListMgrItem[]> {
    this.messageService.add('ListMgrItemsService: fetched List Mgr Items');
    return of(LISTMGRITEMS);
  }

  getListMgrItem(id: number): Observable<ListMgrItem> {
    this.messageService.add(`ListMgrItemService: fetched List Mgr Item id=${id}`);
    return of(LISTMGRITEMS.find(listMgrItem => listMgrItem.id === id));
  }
}