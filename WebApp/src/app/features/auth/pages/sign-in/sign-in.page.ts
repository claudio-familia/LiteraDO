import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Country } from 'src/app/shared/models/country';
import { CountryService } from 'src/app/shared/services/country.service';
import { SignInModel } from '../../models/sign-in';
import { AuthService } from '../../services/auth.service';
import { AlertService } from 'src/app/core/services/alert.service';

@Component({
  selector: 'literado-sign-in',
  templateUrl: './sign-in.page.html',
  styleUrls: ['./sign-in.page.scss']
})
export class SignInPage implements OnInit {
  countries: Country[] = []
  constructor(
    private fb: FormBuilder, 
    private authService: AuthService, 
    private alertService: AlertService,
    private countryService: CountryService) {}

  ngOnInit(): void {
    this.countryService.get().subscribe(res => {
      this.countries = res;
    });
  }
  userForm = this.fb.group({
    username: [null, Validators.required],
    password: [null, [Validators.required, Validators.minLength(4)]],
    confirmPassword: [null, [Validators.required, Validators.minLength(4)]],
    firstName: [null, Validators.required],
    lastName: [null],
    email: [null, [Validators.required, Validators.email]],
    birthdate: null,
    gender: [null, Validators.required],
    countryId: [null, Validators.required],
    targetPreference: [null]
  });

  getControl(controlName: 
    "username" | 
    "password" | 
    "confirmPassword" |
    "firstName" |
    "lastName" |
    "email" |
    "gender" |
    "countryId" |
    "birthdate" |
    "email" |
    "targetPreference"): FormControl {
    return this.userForm.controls[controlName];
  }

  passwordMustConfirm(): boolean {
    const password = this.userForm.controls['password'];
    const confirmPassword = this.userForm.controls['confirmPassword'];
    return password.dirty && confirmPassword.dirty && confirmPassword.valid && password.valid && password.value === confirmPassword.value;
  }

  onSubmit(): void {
    if (this.userForm.valid) {
      const values = this.userForm.value as SignInModel;
      this.authService.signIn(values).subscribe(() => {
        this.alertService.ModalNotification("Correcto", "Usuario creado exitosamente", "success").then(async () => {
          this.authService.login({username: values.UserName, password: values.Password});
        });
      });
    }
  }
}
