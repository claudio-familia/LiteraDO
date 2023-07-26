import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { Country } from '../models/country';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class CountryService extends BaseService<Country> {
    constructor(private _http: HttpClient) {
        super(environment.urls.country, _http)
    }
}