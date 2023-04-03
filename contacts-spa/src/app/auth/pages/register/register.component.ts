import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  myForm: FormGroup = this.formBuilder.group({
    name: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: [Validators.required, Validators.minLength(6)],
  });

  constructor(private formBuilder: FormBuilder) {}

  register() {
    console.log(this.myForm.value);
    console.log(this.myForm.valid);
  }
}
