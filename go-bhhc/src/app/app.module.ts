import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'; // <-- NgModel lives here

import { AppComponent } from './components/app/app.component';
import { ListMgrItemsComponent } from './components/list-mgr-items/list-mgr-items.component';
import { MessagesComponent } from './components/messages/messages.component';
import { ListMgrItemDetailComponent } from './components/list-mgr-item-detail/list-mgr-item-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    ListMgrItemsComponent,
    MessagesComponent,
    ListMgrItemDetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }