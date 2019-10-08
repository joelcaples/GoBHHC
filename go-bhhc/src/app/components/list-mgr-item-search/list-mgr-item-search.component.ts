import { Component, OnInit } from '@angular/core';

import { Observable, Subject } from 'rxjs';

import {
   debounceTime, distinctUntilChanged, switchMap
 } from 'rxjs/operators';

import { ListMgrItem } from '../../models/list-mgr-item';
import { ListMgrItemService } from '../../services/list-mgr-item-service';

@Component({
  selector: 'list-mgr-item-search',
  templateUrl: './list-mgr-item-search.component.html',
  styleUrls: [ './list-mgr-item-search.component.css' ]
})
export class ListMgrItemSearchComponent implements OnInit {
  listMgrItems$: Observable<ListMgrItem[]>;
  private searchTerms = new Subject<string>();

  constructor(private listMgrItemService: ListMgrItemService) {}

  // Push a search term into the observable stream.
  search(term: string): void {
    this.searchTerms.next(term);
  }

  ngOnInit(): void {
    this.listMgrItems$ = this.searchTerms.pipe(
      // wait 300ms after each keystroke before considering the term
      debounceTime(300),

      // ignore new term if same as previous term
      distinctUntilChanged(),

      // switch to new search observable each time the term changes
      switchMap((term: string) => this.listMgrItemService.searchListMgrItems(term)),
    );
  }
}