import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LoadingService {
    isLoading: Subject<boolean> = new Subject();

    hideLoading() {
        this.isLoading.next(false);
    }
    showLoading() {
        this.isLoading.next(true);
    }
}

