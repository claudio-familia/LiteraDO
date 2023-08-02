import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { AuthModel } from '../../models/auth';

@Component({
  selector: 'literado-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss']
})
export class LoginPage {
  
  constructor(
    private fb: FormBuilder, 
    private authService: AuthService) {
    const token = localStorage.getItem("literado-token");
    if (token && token !== "") {
      localStorage.removeItem("literado-token");
      window.location.reload();
    }
  }
  
  loginForm = this.fb.group({
    username: [null, Validators.required],
    password: [null, Validators.required],
  });

  onSubmit(): void {
    if (this.loginForm.valid && this.loginForm.value.username && this.loginForm.value.password) {
      const payload: AuthModel = {
        username: this.loginForm.value.username,
        password: this.loginForm.value.password
      }
      this.authService.login(payload);
    }
  }
}
