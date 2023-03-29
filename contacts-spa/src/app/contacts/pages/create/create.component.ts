import { Component } from '@angular/core';
import { Contact } from '../../interfaces/contacts.interface';
import { ContactsService } from '../../services/contacts.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
})
export class CreateComponent {
  genders = [
    { id: 1, description: 'Male' },
    { id: 2, description: 'Female' },
  ];

  contact: Contact = {
    name: '',
    lastname: '',
    email: '',
    phonenumber: '',
  };

  constructor(private contactService: ContactsService) {}

  save() {
    console.log(this.contact);

    if (this.contact.name.trim().length === 0) {
      return;
    }
    if (this.contact.phonenumber.trim().length === 0) {
      return;
    }

    this.contactService
      .addContact(this.contact)
      .subscribe((resp) => console.log('Respuesta', resp));
  }
}
