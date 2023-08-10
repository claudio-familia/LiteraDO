import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService<any> {
    
  constructor(public httpClient: HttpClient) {
    super(environment.urls.users, httpClient);
  }

  getInformation() {
    return this.httpClient.get<any>(`${this._apiUrl}/profile`, {headers: this._headers});
  }

  updateProfile(values: any) {
    return this.httpClient.put<any>(`${this._apiUrl}/profile`, values, {headers: this._headers});
  }
}
