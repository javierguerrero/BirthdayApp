import { AfterViewInit, Component } from '@angular/core';
import { environment } from 'src/environments/environment';
declare var google: any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements AfterViewInit {
  private googleClientId: string = environment.googleClientId;

  ngAfterViewInit(): void {
    this.googleAuthInit();
    this.googleRenderButton();
  }

  googleAuthInit() {
    google.accounts.id.initialize({
      client_id: this.googleClientId,
      callback: this.handleCredentialResponse,
    });
  }

  googleRenderButton() {
    google.accounts.id.renderButton(
      document.getElementById('buttonDiv'),
      { theme: 'outline', size: 'large' } // customization attributes
    );
    google.accounts.id.prompt(); // also display the One Tap dialog
  }

  handleCredentialResponse(response: any) {
    console.log('Encoded JWT ID token: ' + response.credential);

    if (response.credential) {
      localStorage.setItem('token', response.credential);
      document.location.href = '/contacts';
    }
  }
}
