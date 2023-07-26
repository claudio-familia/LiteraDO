import { Component, Input, OnInit } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Observable } from 'rxjs';

@Component({
  selector: 'literado-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Input({ required: true }) isHandset$!: Observable<boolean>;
  @Input({ required: true }) drawer!: MatSidenav;
  
  appName: string = 'litera-do';
  darkTheme: string = 'Dark theme';

  ngOnInit(): void {
  }

  changeTheme(event: any): void {
    const evt = event as MatSlideToggleChange;

    if(evt.checked)
      document.body.classList.add("dark-theme");
    else
      document.body.classList.remove("dark-theme");
  }
}
