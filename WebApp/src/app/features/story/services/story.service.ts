import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Story } from '../models/story';

@Injectable({
  providedIn: 'root',
})
export class StoryService extends BaseService<Story> {
    constructor(private _http: HttpClient) {
        super(environment.urls.story, _http)
    }
}