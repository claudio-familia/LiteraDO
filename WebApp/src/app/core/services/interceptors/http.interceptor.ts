import { Injectable } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import {
    HttpEvent, HttpInterceptor, HttpHandler, HttpRequest
} from '@angular/common/http';

import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { LoadingService } from '../loading.service';

@Injectable()
export class NoopInterceptor implements HttpInterceptor {

    constructor(private loadingService: LoadingService){
    }

    intercept(req: HttpRequest<any>, next: HttpHandler):
        Observable<HttpEvent<any>> {
        this.loadingService.showLoading();
        const token = localStorage.getItem('literado-token');
        req.headers.set('Authorization', `Bearer ${token}`);
        return next.handle(req).pipe(
            finalize(() => {
                this.loadingService.hideLoading();
            })
          );;
    }
}

export const HttpInterceptorProviders = [
    { provide: HTTP_INTERCEPTORS, useClass: NoopInterceptor, multi: true },
];