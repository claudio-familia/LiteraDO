import { Component } from '@angular/core';

@Component({
  selector: 'literado-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  logout(): void {
    localStorage.removeItem("literado-token");
    window.location.reload();
  }
}
