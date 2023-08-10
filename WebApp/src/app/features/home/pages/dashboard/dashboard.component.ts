import { Component, inject } from '@angular/core';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { map } from 'rxjs/operators';

@Component({
  selector: 'literado-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
  private breakpointObserver = inject(BreakpointObserver);

  /** Based on the screen size, switch from standard to one column per row */
  cards = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
    map(({ matches }) => {
      if (matches) {
        return [
          { title: 'Consejo 1', advice: 'Un joven que lee, será un adulto que piensa.', cols: 1, rows: 1 },
          { title: 'Consejo 2', advice: 'En un buen libro, lo mejor está entre lineas.', cols: 1, rows: 1 },
          { title: 'Consejo 3', advice: 'Leer nos abre una ventana al mundo.',cols: 1, rows: 1 },
          { title: 'Consejo 4', advice: 'Yo no estudio para saber más, sino para ignorar menos.',cols: 1, rows: 1 }
        ];
      }

      return [
        { title: 'Consejo 1', advice: 'Un joven que lee, será un adulto que piensa.', cols: 2, rows: 1 },
        { title: 'Consejo 2', advice: 'En un buen libro, lo mejor está entre lineas.',cols: 1, rows: 1 },
        { title: 'Consejo 3', advice: 'Leer nos abre una ventana al mundo.',cols: 1, rows: 2 },
        { title: 'Consejo 4', advice: 'Yo no estudio para saber más, sino para ignorar menos.',cols: 1, rows: 1 }
      ];
    })
  );
}
