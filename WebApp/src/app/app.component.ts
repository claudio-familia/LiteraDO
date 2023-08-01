import { AfterViewInit, Component } from '@angular/core';
import { Router } from '@angular/router';
import { Store, select } from '@ngrx/store';
import { Observable, delay } from 'rxjs';
import { LoadingService } from './core/services/loading.service';

@Component({
  selector: 'literado-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements AfterViewInit {
  title = 'litera-do';
  isAuthenticated: boolean = false; 
  isLoading: boolean = false;;
  
  constructor(
      private router: Router,
      private loadingService: LoadingService
    ) {     
    const token = localStorage.getItem('literado-token');    
    this.isAuthenticated = token != null;
  }
  ngAfterViewInit(): void {
    this.loadingService.isLoading.subscribe(loadingState => {
      this.isLoading = loadingState;
  });
  }
  ngOnInit(): void {
    if(!this.isAuthenticated) 
      this.router.navigateByUrl('/login');
  }
}
