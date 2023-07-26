import { Injectable } from '@angular/core';
import { AuthModel } from '../models/auth';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginResponse } from '../models/login-response';
import { SignInModel } from '../models/sign-in';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  logout(): void {
    throw new Error('Method not implemented.');
  }
  isLoggedIn$: any;
  user$: any;
  url: string = environment.urls.auth;

  constructor(private http: HttpClient) { }

  login(auth: AuthModel): void {
    this.http.post<LoginResponse>(`${environment.ApiUrl}${this.url}/login`, auth).subscribe(res => {
      localStorage.setItem("literado-token", res.accessToken);
      window.location.replace("/home");
    });
  }

  signIn(user: SignInModel): Observable<any> {
    return this.http.post<LoginResponse>(`${environment.ApiUrl}users`, user);
  }
}
