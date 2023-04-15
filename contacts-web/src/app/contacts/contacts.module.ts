import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchComponent } from './pages/search/search.component';
import { ContactComponent } from './pages/contact/contact.component';
import { LayoutComponent } from './pages/layout/layout.component';
import { ListComponent } from './pages/list/list.component';
import { ContactsRoutingModule } from './contacts-routing.module';
import { MaterialModule } from '../material/material.module';
import { ContactCardComponent } from './components/contact-card/contact-card.component';
import { FormsModule } from '@angular/forms';
import { UpsertComponent } from './pages/upsert/upsert.component';
import { ConfirmComponent } from './components/confirm/confirm.component';

@NgModule({
  declarations: [
    UpsertComponent,
    SearchComponent,
    ContactComponent,
    LayoutComponent,
    ListComponent,
    ContactCardComponent,
    ConfirmComponent,
  ],
  imports: [CommonModule, ContactsRoutingModule, MaterialModule, FormsModule],
})
export class ContactsModule {}
