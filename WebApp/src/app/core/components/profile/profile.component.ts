import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SettingsComponent } from '../settings/settings.component';
// import { HeaderComponent } from '../header/header.component';
@Component({
  selector: 'literado-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  constructor( private dialog: MatDialog ) { }
  
  logout(): void {
    localStorage.removeItem("literado-token");
    window.location.reload();
  }
  openDialog(): void {
    this.dialog.open(SettingsComponent, {
      data: {
        title: 'Settings',
        message: 'Settings de la app!',
      },
    });
  }
}
