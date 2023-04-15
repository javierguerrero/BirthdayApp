import { Component, Input } from '@angular/core';
import { Contact } from '../../interfaces/contact.interface';

@Component({
  selector: 'app-contact-card',
  templateUrl: './contact-card.component.html',
  styleUrls: ['./contact-card.component.css'],
})
export class ContactCardComponent {
  @Input() contact!: Contact; //Con el signo de admiración indico que siempre tendrá un valor.
}
