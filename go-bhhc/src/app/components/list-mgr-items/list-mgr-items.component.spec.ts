import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListMgrItemsComponent } from './list-mgr-items.component';

describe('ListMgrItemsComponent', () => {
  let component: ListMgrItemsComponent;
  let fixture: ComponentFixture<ListMgrItemsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListMgrItemsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListMgrItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
