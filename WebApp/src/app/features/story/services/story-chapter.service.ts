import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class StoryChapterService extends BaseService<any> {
    getStoryName(id: string) {
        return this._http.get(`${this._apiUrl}/${id}/story-title`, {headers: this._headers});
    }
    constructor(private _http: HttpClient) {
        super(environment.urls.storyChapter, _http)
    }
}