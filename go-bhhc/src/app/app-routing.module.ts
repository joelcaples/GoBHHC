import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent }   from './dashboard/dashboard.component';
import { ListMgrItemsComponent }      from './components/list-mgr-items/list-mgr-items.component';
import { ListMgrItemDetailComponent }  from './components/list-mgr-item-detail/list-mgr-item-detail.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'detail/:id', component: ListMgrItemDetailComponent },
  { path: 'list-mgr-items', component: ListMgrItemsComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}