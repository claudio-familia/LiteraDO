import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignInPage } from './pages/sign-in/sign-in.page';
import { LoginPage } from './pages/login/login.page';
import { AuthRoutingModule } from './auth-routing.module';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';



@NgModule({
  declarations: [
    SignInPage,
    LoginPage
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    MatButtonModule,
    MatInputModule,
    MatSelectModule,
    MatRadioModule,
    ReactiveFormsModule,
    MatIconModule,
    MatDatepickerModule, 
    MatNativeDateModule
  ]
})
export class AuthModule { }
