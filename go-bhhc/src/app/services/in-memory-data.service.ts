import { InMemoryDbService } from 'angular-in-memory-web-api';
import { ListMgrItem } from '../models/list-mgr-item';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const listMgrItems = [
      {
        "id": 5,
        "description": "BECAUSE REASONS"
      },
      {
          "id": 1,
          "description": "FREE BEER"
      },
      {
          "id": 3,
          "description": "GET TO SHARE AN OFFICE WITH WARREN"
      },
      {
          "id": 2,
          "description": "LIFETIME SUBSCRIPTION TO OK MAGAZINE"
      },
      {
          "id": 4,
          "description": "LOCATION CLOSE TO QUAINT EATERIES"
      },
      {
          "id": 7,
          "description": "OMAHA - It's not for everyone"
      },
      {
          "id": 6,
          "description": "THE DEAFENING SILENCE"
      }
    ];
    return {listMgrItems};
  }

  // Overrides the genId method to ensure that a listMgrItem always has an id.
  // If the listMgrItems array is empty,
  // the method below returns the initial number (11).
  // if the listMgrItems array is not empty, the method below returns the highest
  // listMgrItem id + 1.
  genId(listMgrItems: ListMgrItem[]): number {
    return listMgrItems.length > 0 ? Math.max(...listMgrItems.map(listMgrItem => listMgrItem.id)) + 1 : 11;
  }
}