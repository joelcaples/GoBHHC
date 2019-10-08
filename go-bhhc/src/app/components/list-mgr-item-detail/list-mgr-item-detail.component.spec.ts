import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListMgrItemDetailComponent } from './list-mgr-item-detail.component';

describe('ListMgrItemDetailComponent', () => {
  let component: ListMgrItemDetailComponent;
  let fixture: ComponentFixture<ListMgrItemDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListMgrItemDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListMgrItemDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
