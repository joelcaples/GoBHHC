import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }    from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';

import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService }  from './services/in-memory-data.service';

import { AppComponent } from './components/app/app.component';
import { MessagesComponent } from './components/messages/messages.component';
import { ListMgrItemsComponent } from './components/list-mgr-items/list-mgr-items.component';
import { ListMgrItemDetailComponent } from './components/list-mgr-item-detail/list-mgr-item-detail.component';
import { DashboardComponent } from './dashboard/dashboard.component';

import { AppRoutingModule } from './app-routing.module';
import { ListMgrItemSearchComponent } from './components/list-mgr-item-search/list-mgr-item-search.component';

@NgModule({
  declarations: [
    AppComponent,
    MessagesComponent,
    ListMgrItemsComponent,
    ListMgrItemDetailComponent,
    DashboardComponent,
    ListMgrItemSearchComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,

    // The HttpClientInMemoryWebApiModule module intercepts HTTP requests
    // and returns simulated server responses.
    // Remove it when a real server is ready to receive requests.
    HttpClientInMemoryWebApiModule.forRoot(
      InMemoryDataService, { dataEncapsulation: false }
    )
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }