import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class StoryService extends BaseService<any> {
    getReadingBooks() {
      return this._http.get<any>(`${this._apiUrl}/stories/my-story/reading`, {headers: this._headers});
    }
    saveReadingInformation(id: any, chapterId: any) {
      return this._http.post(`${this._apiUrl}/${id}/chapterinfo/chapter/${chapterId}`, {}, {headers: this._headers});
    }

    createReadingInformation(id: any) {
      return this._http.post(`${this._apiUrl}/${id}/chapterinfo/mark-read`, {}, {headers: this._headers});
    }

    getReadingInformation(storyId: any) {
      return this._http.get(`${this._apiUrl}/${storyId}/chapterinfo`, {headers: this._headers});
    }

    publishStory(storyId: any) {
      return this._http.post(`${this._apiUrl}/${storyId}/publish`, {}, {headers: this._headers});
    }

    getPublished() {
      return this._http.get(`${this._apiUrl}/published`, {headers: this._headers});
    }

    updateStory(data: FormData) {
      return this._http.put(`${this._apiUrl}/update`, data, {headers: this._headers});
    }

    constructor(private _http: HttpClient) {
        super(environment.urls.story, _http)
    }

    createStory(data: FormData) {
      return this._http.post(`${this._apiUrl}/create`, data, {headers: this._headers});
    }
}