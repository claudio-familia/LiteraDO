import { Component, OnInit } from '@angular/core';
import { MenuItem } from '../../models/menu-item';
import { HttpClient } from '@angular/common/http';
import { UserService } from 'src/app/features/auth/services/user.service';

@Component({
  selector: 'literado-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {
  menu: MenuItem[] = [];
  role: number = 2;

  constructor(private http: HttpClient, private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getInformation().subscribe(res => {
      this.role = Number(res.targetPreference)
    });
    this.http.get<MenuItem[]>("assets/menus/sidenav.json").subscribe(data => {
      this.menu = data;
    });
  }

  validate(option: any): boolean {

    if (this.role === 2) return true;

    if (option === 2) return true;

    if(option === this.role) return true;

    return false;
  }
}
