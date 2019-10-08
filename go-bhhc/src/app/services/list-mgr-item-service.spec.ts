import { TestBed } from '@angular/core/testing';

import { ListMgrItemService } from './list-mgr-item-service';

describe('ListMgrItemsServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ListMgrItemService = TestBed.get(ListMgrItemService);
    expect(service).toBeTruthy();
  });
});
