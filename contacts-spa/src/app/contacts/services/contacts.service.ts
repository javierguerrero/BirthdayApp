import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from '../interfaces/contacts.interface';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ContactsService {
  private baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) {}

  getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>(`${this.baseUrl}/contacts`);
  }

  getContactById(id: number): Observable<Contact> {
    return this.http.get<Contact>(`${this.baseUrl}/contacts/${id}`);
  }

  getSuggestions(term: string): Observable<Contact[]> {
    return this.http.get<Contact[]>(
      `${this.baseUrl}/contacts?q=${term}&_limit=6`
    );
  }

  addContact(contact: Contact): Observable<Contact> {
    return this.http.post<Contact>(`${this.baseUrl}/contacts`, contact);
  }
}
