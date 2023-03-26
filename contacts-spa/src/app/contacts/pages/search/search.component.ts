import { Component } from '@angular/core';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { Contact } from '../../interfaces/contacts.interface';
import { ContactsService } from '../../services/contacts.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
})
export class SearchComponent {
  term: string = '';
  contacts: Contact[] = [];
  selectedContact!: Contact | undefined;

  constructor(private contactsService: ContactsService) {}

  sarching() {
    this.contactsService
      .getSuggestions(this.term.trim())
      .subscribe((contacts) => (this.contacts = contacts));
  }

  selectedOption(event: MatAutocompleteSelectedEvent) {
    if (!event.option.value) {
      this.selectedContact = undefined;
      return;
    }

    const contact: Contact = event.option.value;
    this.term = contact.name;

    this.contactsService
      .getContactById(contact.id!)
      .subscribe((contact) => (this.selectedContact = contact));
  }
}
