import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Contact } from '../../interfaces/contact.interface';
import { ContactsService } from '../../services/contacts.service';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css'],
})
export class ContactComponent {
  contact!: Contact;

  constructor(
    private activatedRoute: ActivatedRoute,
    private contactsService: ContactsService,
    private router: Router
  ) {}

  ngOnInit() {
    this.activatedRoute.params
      .pipe(
        switchMap(({ id }) => this.contactsService.getContactById(id))
      )
      .subscribe((contact) => (this.contact = contact));
  }

  back() {
    this.router.navigate(['/contacts/list']);
  }

}