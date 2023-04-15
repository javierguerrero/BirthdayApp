import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../auth/services/auth.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css'],
})
export class LayoutComponent {
  get auth() {
    return this.authService.auth;
  }

  user: any = {};

  constructor(private router: Router, private authService: AuthService) {}

  logout() {
    this.router.navigate(['./auth']);
    this.authService.logout();
  }
}
