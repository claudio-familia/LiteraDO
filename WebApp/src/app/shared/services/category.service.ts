import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Category } from 'src/app/features/story/models/category';

@Injectable({
  providedIn: 'root',
})
export class CategoryService extends BaseService<Category> {
    constructor(private _http: HttpClient) {
        super(environment.urls.category, _http)
    }
}