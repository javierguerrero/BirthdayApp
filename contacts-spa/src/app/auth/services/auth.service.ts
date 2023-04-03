import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { AuthResponse, User } from '../interfaces/auth.interface';
import { tap, map } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private _auth: AuthResponse | undefined;

  constructor(private http: HttpClient) {}

  get auth() {
    return { ...this._auth };
  }

  verifyAuth(): Observable<boolean> {
    if (!localStorage.getItem('token')) {
      return of(false);
    }

    var info = this.parseJwt(localStorage.getItem('token'));
    this._auth = {
      id: '',
      email: '',
      username: info.name,
    };
    return of(true);
  }

  parseJwt(token: any) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(
      window
        .atob(base64)
        .split('')
        .map(function (c) {
          return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        })
        .join('')
    );

    return JSON.parse(jsonPayload);
  }

  validateToken() {
    //https://developers.google.com/identity/protocols/oauth2#expiration
  }

  logout() {
    localStorage.clear();
  }
}
