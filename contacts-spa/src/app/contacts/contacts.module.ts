import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchComponent } from './pages/search/search.component';
import { ContactComponent } from './pages/contact/contact.component';
import { HomeComponent } from './pages/home/home.component';
import { ListComponent } from './pages/list/list.component';
import { ContactsRoutingModule } from './contacts-routing.module';
import { MaterialModule } from '../material/material.module';

@NgModule({
  declarations: [
    SearchComponent,
    ContactComponent,
    HomeComponent,
    ListComponent,
  ],
  imports: [
    CommonModule, 
    ContactsRoutingModule, 
    MaterialModule
  ],
})
export class ContactsModule {}
