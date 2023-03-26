import { Component } from '@angular/core';
import { ContactsService } from '../../services/contacts.service';
import { Contact } from '../../interfaces/contacts.interface';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
export class ListComponent {
  contacts: Contact[] = [];

  constructor(private contactsService: ContactsService) {}

  ngOnInit() {
    this.contactsService.getContacts().subscribe((contacts) => {
      this.contacts = contacts;
    });
  }
}
