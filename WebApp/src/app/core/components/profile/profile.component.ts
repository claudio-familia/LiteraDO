import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SettingsComponent } from '../settings/settings.component';
import jwt_decode from "jwt-decode";
import { ProfileInformationComponent } from '../profile-information/profile-information.component';

@Component({
  selector: 'literado-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  userName: string = 'Admin';

  constructor( private dialog: MatDialog ) {
    const token = localStorage.getItem('literado-token') || "";    
    this.userName = jwt_decode<any>(token)["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
  }
  
  logout(): void {
    localStorage.removeItem("literado-token");
    window.location.reload();
  }
  openProfileDialog(): void {
    this.dialog.open(ProfileInformationComponent, {
      data: {
        title: 'Profile info'
      },
      width: '80%',
      height: '60%'
    });
  }

  openSettingsDialog(): void {
    this.dialog.open(SettingsComponent, {
      data: {
        title: 'Settings',
        message: 'Settings de la app!',
      },
    });
  }
}
