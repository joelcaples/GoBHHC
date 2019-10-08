import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListMgrItemSearchComponent } from './list-mgr-item-search.component';

describe('ListMgrItemSearchComponent', () => {
  let component: ListMgrItemSearchComponent;
  let fixture: ComponentFixture<ListMgrItemSearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListMgrItemSearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListMgrItemSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
