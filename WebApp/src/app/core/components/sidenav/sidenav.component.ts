import { Component, OnInit } from '@angular/core';
import { MenuItem } from '../../models/menu-item';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'literado-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {
  menu: MenuItem[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<MenuItem[]>("assets/menus/sidenav.json").subscribe(data => {
      this.menu = data;
    });
  }
}
