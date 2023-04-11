import { Component } from '@angular/core';
import { Contact } from '../../interfaces/contacts.interface';
import { ContactsService } from '../../services/contacts.service';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmComponent } from '../../components/confirm/confirm.component';

@Component({
  selector: 'app-upsert',
  templateUrl: './upsert.component.html',
  styleUrls: ['./upsert.component.css'],
})
export class UpsertComponent {
  genders = [
    { id: 1, description: 'Male' },
    { id: 2, description: 'Female' },
  ];

  contact: Contact = {
    name: '',
    lastName: '',
    email: '',
    phoneNumber: '',
  };

  constructor(
    private contactService: ContactsService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar,
    private dialog: MatDialog
  ) {}

  ngOnInit() {
    this.activatedRoute.params
      .pipe(switchMap(({ id }) => this.contactService.getContactById(id)))
      .subscribe((contact) => (this.contact = contact));
  }

  save() {
    if (this.contact.name.trim().length === 0) {
      return;
    }
    if (this.contact.phoneNumber.trim().length === 0) {
      return;
    }

    if (this.contact.id) {
      //update
      this.contactService.updateContact(this.contact).subscribe((contact) => {
        this.showSnackBar('Updated');
      });
    } else {
      //create
      this.contactService.addContact(this.contact).subscribe((contact) => {
        this.router.navigate(['/contacts/edit', contact.id]);
        this.showSnackBar('Created');
      });
    }
  }

  delete() {
    const dialog = this.dialog.open(ConfirmComponent, {
      width: '250px',
      data: this.contact,
    });

    dialog.afterClosed().subscribe((result) => {
      if (result) {
        this.contactService
          .deleteContact(this.contact.id!)
          .subscribe((resp) => {
            this.router.navigate(['contacts']);
          });
      }
    });
  }

  showSnackBar(message: string): void {
    this.snackBar.open(message, 'Ok', {
      duration: 2500,
    });
  }
}
